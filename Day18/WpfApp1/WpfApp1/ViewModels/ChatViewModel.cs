using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HotelBookingApp.Models;
using HotelBookingApp.Services;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace HotelBookingApp.ViewModels
{
    public partial class ChatViewModel : ObservableObject, IDisposable
    {
        private readonly ChatService _chatService;
        private readonly CancellationTokenSource _cts;
        private bool _isDisposed = false;
        private readonly Dispatcher _dispatcher;

        [ObservableProperty]
        private ObservableCollection<ChatMessageModel> _messages;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SendCommand))]
        private string _currentMessage = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SendCommand))]
        private bool _isConnected = false;

        [ObservableProperty]
        private string _connectionStatus = "Инициализация...";

        private readonly bool _isCurrentUserAdmin;

        public ChatViewModel(bool isCurrentUserAdmin)
        {
            _isCurrentUserAdmin = isCurrentUserAdmin;
            _dispatcher = Application.Current.Dispatcher;
            _chatService = new ChatService();
            Messages = new ObservableCollection<ChatMessageModel>();
            _cts = new CancellationTokenSource();
            _ = InitializeChatAsync(_cts.Token);
        }
        public ChatViewModel() : this(true) { }

        private async Task InitializeChatAsync(CancellationToken cancellationToken)
        {
            string role = _isCurrentUserAdmin ? "Сервер" : "Клиент";
            System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Начало InitializeChatAsync.");
            bool initSuccess = false;
            try
            {
                await SetConnectionStatusAsync(_isCurrentUserAdmin ? "Запуск сервера..." : "Подключение к серверу...");
                if (_isCurrentUserAdmin)
                {
                    await _chatService.StartServerAsync(cancellationToken);
                    await SetIsConnectedAsync(true);
                    await SetConnectionStatusAsync("Сервер запущен. Ожидание клиента...");
                }
                else
                {
                    await _chatService.ConnectClientAsync(cancellationToken);
                    await SetIsConnectedAsync(true);
                    await SetConnectionStatusAsync("Подключено");
                }
                initSuccess = true;
                System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Инициализация успешна.");

                if (!cancellationToken.IsCancellationRequested)
                {
                    System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Запуск цикла чтения...");
                    await ReceiveMessagesLoopAsync(cancellationToken);
                }
                System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Цикл чтения завершился или не был запущен.");

            }
            catch (OperationCanceledException) { await HandleCancellationAsync(role); }
            catch (Exception ex) { await HandleInitializationErrorAsync(role, ex); }
            finally
            {
                if (!initSuccess && !_isDisposed)
                {
                    await SetIsConnectedAsync(false);
                }
                System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Конец InitializeChatAsync.");
            }
        }

        [RelayCommand(CanExecute = nameof(CanSend))]
        private async Task SendAsync()
        {
            string role = _isCurrentUserAdmin ? "Сервер" : "Клиент";
            if (!IsConnected || string.IsNullOrWhiteSpace(CurrentMessage)) return;

            var messageText = CurrentMessage;
            CurrentMessage = string.Empty;

            var message = new ChatMessageModel
            {
                Sender = _isCurrentUserAdmin ? "Администратор" : "Вы",
                Message = messageText,
                Timestamp = DateTime.Now,
                IsSentByUser = true
            };
            System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Подготовка к отправке: '{messageText}'");
            await AddMessageToUIAsync(message);
            System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Сообщение добавлено в UI...");

            try
            {
                await _chatService.SendMessageAsync(message.Message, _cts.Token);
                System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] SendMessageAsync выполнен.");
            }
            catch (Exception ex) { await HandleSendErrorAsync(role, ex, message); }
        }
        private bool CanSend() => IsConnected && !string.IsNullOrWhiteSpace(CurrentMessage);

        private async Task ReceiveMessagesLoopAsync(CancellationToken cancellationToken)
        {
            string role = _isCurrentUserAdmin ? "Сервер" : "Клиент";
            System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Начинаем ASYNC цикл получения сообщений (с Task.Run)...");
            bool firstMessageReceivedByServer = !_isCurrentUserAdmin;

            try
            {
                while (!cancellationToken.IsCancellationRequested && IsConnected)
                {
                    string? receivedText = null;
                    System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Ожидание сообщения от ChatService (Task.Run)...");
                    try
                    {
                        receivedText = await Task.Run(async () => await _chatService.ReceiveMessageAsync(cancellationToken), cancellationToken);
                        System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Task.Run(ReceiveMessageAsync) вернул: '{receivedText ?? "<null>"}'");

                        if (receivedText == null)
                        {
                            System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Receive вернул null, разрыв соединения.");
                            SetConnectionStatusAndNotify("Соединение закрыто другой стороной.", false);
                            break;
                        }
                    }
                    catch (IOException ioex) { System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] IOException при чтении: {ioex.Message}"); SetConnectionStatusAndNotify("Канал связи закрыт.", false); break; }
                    catch (OperationCanceledException) { throw; }
                    catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Ошибка при вызове ReceiveMessage в Task.Run: {ex}"); SetConnectionStatusAndNotify($"Ошибка чтения: {ex.Message}", false); break; }


                    if (_isCurrentUserAdmin && !firstMessageReceivedByServer && !string.IsNullOrEmpty(receivedText))
                    {
                        System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Получено первое сообщение, клиент подключен (обновляем статус).");
                        firstMessageReceivedByServer = true;
                        SetConnectionStatusAndNotify("Клиент подключен", true);
                    }

                    if (!string.IsNullOrEmpty(receivedText))
                    {
                        System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Обработка полученного сообщения: {receivedText}");
                        var messageModel = new ChatMessageModel
                        {
                            Sender = _isCurrentUserAdmin ? "Клиент" : "Администратор",
                            Message = receivedText,
                            Timestamp = DateTime.Now,
                            IsSentByUser = false
                        };
                        await AddMessageToUIAsync(messageModel);
                    }
                    else if (receivedText != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Receive вернул пустую строку.");
                    }

                    await Task.Delay(50, cancellationToken);

                }
            }
            catch (OperationCanceledException) { await HandleCancellationAsync(role); }
            catch (Exception ex) { await HandleLoopErrorAsync(role, ex); }
            finally
            {
                System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Завершение цикла получения сообщений. IsDisposed: {_isDisposed}");
                if (!_isDisposed && IsConnected)
                {
                    SetConnectionStatusAndNotify("Соединение потеряно/завершено.", false);
                }
                System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Конец ReceiveMessagesLoopAsync.");
            }
        }

        private Task SetConnectionStatusAsync(string status) => _dispatcher.InvokeAsync(() => ConnectionStatus = status).Task;
        private Task SetIsConnectedAsync(bool isConnected) => _dispatcher.InvokeAsync(() => IsConnected = isConnected).Task;
        private void SetConnectionStatusAndNotify(string status, bool isConnected)
        { if (!_isDisposed) _dispatcher.InvokeAsync(() => { if (ConnectionStatus != status) ConnectionStatus = status; if (IsConnected != isConnected) IsConnected = isConnected; }); }
        private Task AddMessageToUIAsync(ChatMessageModel message) => _dispatcher.InvokeAsync(() => Messages.Add(message)).Task;

        private async Task HandleSendErrorAsync(string role, Exception ex, ChatMessageModel message)
        {
            System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Ошибка при отправке: {ex}");
            await _dispatcher.InvokeAsync(() => {
                if (Messages.Contains(message)) Messages.Remove(message);
                MessageBox.Show($"Ошибка отправки: {ex.Message}");
                if (string.IsNullOrEmpty(CurrentMessage)) CurrentMessage = message.Message;
            });
            await CheckConnectionAndDisconnectIfNeeded(role);
        }
        private async Task HandleCancellationAsync(string role)
        {
            System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Операция отменена (Initialize или Loop).");
            SetConnectionStatusAndNotify("Отменено.", false);
        }
        private async Task HandleInitializationErrorAsync(string role, Exception ex)
        {
            await SetConnectionStatusAsync(_isCurrentUserAdmin ? $"Ошибка запуска сервера: {ex.Message}" : $"Ошибка подключения: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Ошибка инициализации: {ex}");
            await SetIsConnectedAsync(false);
        }
        private async Task HandleLoopErrorAsync(string role, Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] КРИТИЧЕСКАЯ ОШИБКА в цикле чтения: {ex}");
            SetConnectionStatusAndNotify($"Критическая ошибка чата: {ex.Message}", false);
        }
        private async Task CheckConnectionAndDisconnectIfNeeded(string role) { await Task.Delay(50); if (!_isDisposed) { System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Ошибка отправки, обновляем статус соединения."); SetConnectionStatusAndNotify("Ошибка отправки. Соединение разорвано?", false); } }

        public void Dispose() { Dispose(true); GC.SuppressFinalize(this); }
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            string role = _isCurrentUserAdmin ? "Сервер" : "Клиент";
            System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Вызов Dispose(disposing={disposing})...");
            if (disposing)
            {
                try { _cts?.Cancel(); } catch (ObjectDisposedException) { }
                try { _cts?.Dispose(); } catch (ObjectDisposedException) { }
                try { _chatService?.Dispose(); } catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Ошибка при закрытии ChatService в Dispose: {ex.Message}"); }
            }
            try { SetConnectionStatusAndNotify("Отключено.", false); } catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Ошибка доступа к Dispatcher в Dispose: {ex.Message}"); }
            _isDisposed = true;
            System.Diagnostics.Debug.WriteLine($"[ChatViewModel - {role}] Ресурсы освобождены.");
        }
        ~ChatViewModel() { Dispose(false); }
    }
}