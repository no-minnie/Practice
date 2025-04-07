using System.IO;
using System.IO.Pipes;
using System.Text;

namespace HotelBookingApp.Services 
{
    public class ChatService : IDisposable
    {
        private NamedPipeServerStream? _pipeServer;
        private NamedPipeClientStream? _pipeClient;
        private readonly string _pipeName = "HotelChatPipe";
        private Stream? _stream;
        private bool _isDisposed = false;
        public async Task StartServerAsync(CancellationToken cancellationToken = default)
        {
            CloseServer();
            _pipeServer = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
            System.Diagnostics.Debug.WriteLine("[ChatService - Сервер] Ожидание подключения клиента (async)...");
            await _pipeServer.WaitForConnectionAsync(cancellationToken);
            _stream = _pipeServer; 
            System.Diagnostics.Debug.WriteLine("[ChatService - Сервер] Клиент подключился.");
        }
        public async Task ConnectClientAsync(CancellationToken cancellationToken = default)
        {
            CloseClient();
            int connectionTimeout = 5000; 
            _pipeClient = new NamedPipeClientStream(".", _pipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
            System.Diagnostics.Debug.WriteLine("[ChatService - Клиент] Попытка подключения к серверу (async)...");
            try
            {
                await _pipeClient.ConnectAsync(connectionTimeout, cancellationToken);
                _stream = _pipeClient; 
                System.Diagnostics.Debug.WriteLine("[ChatService - Клиент] Подключение успешно.");
            }
            catch (TimeoutException tex) { System.Diagnostics.Debug.WriteLine($"[ChatService - Клиент] Ошибка подключения (таймаут): {tex.Message}"); CloseClient(); throw; }
            catch (OperationCanceledException) { System.Diagnostics.Debug.WriteLine($"[ChatService - Клиент] Подключение отменено."); CloseClient(); throw; }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"[ChatService - Клиент] Ошибка подключения: {ex.Message}"); CloseClient(); throw; }
        }

        public async Task SendMessageAsync(string message, CancellationToken cancellationToken = default)
        {
            if (_stream == null || !_stream.CanWrite)
            {
                System.Diagnostics.Debug.WriteLine("[ChatService] SendMessageAsync: Stream не доступен для записи.");
                throw new InvalidOperationException("Нет активного подключения для отправки.");
            }
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                System.Diagnostics.Debug.WriteLine($"[ChatService] Отправка async: {buffer.Length} байт");
                await _stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
                await _stream.FlushAsync(cancellationToken);
                System.Diagnostics.Debug.WriteLine("[ChatService] Отправка FlushAsync выполнен.");
            }
            catch (IOException ioex) { System.Diagnostics.Debug.WriteLine($"[ChatService] IOException при отправке: {ioex.Message}"); Close(); throw; }
            catch (OperationCanceledException) { System.Diagnostics.Debug.WriteLine($"[ChatService] Отправка отменена."); throw; }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"[ChatService] Ошибка при отправке: {ex.Message}"); throw; }
        }
        public async Task<string?> ReceiveMessageAsync(CancellationToken cancellationToken = default)
        {
            if (_stream == null || !_stream.CanRead)
            {
                System.Diagnostics.Debug.WriteLine("[ChatService] ReceiveMessageAsync: Stream не доступен для чтения.");
                try { await Task.Delay(200, cancellationToken); } catch (OperationCanceledException) { return null; }
                return null; 
            }
            byte[] buffer = new byte[1024];
            int bytesRead = 0;
            try
            {
                System.Diagnostics.Debug.WriteLine($"[ChatService] Ожидание чтения async...");
                bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                System.Diagnostics.Debug.WriteLine($"[ChatService] Прочитано async байт: {bytesRead}");
                if (bytesRead > 0)
                {
                    return Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[ChatService] ReadAsync вернул 0 байт, соединение закрыто?");
                    Close(); 
                    return null; 
                }
            }
            catch (IOException ioex) { System.Diagnostics.Debug.WriteLine($"[ChatService] IOException при чтении: {ioex.Message}"); Close(); throw; } 
            catch (OperationCanceledException) { System.Diagnostics.Debug.WriteLine($"[ChatService] Чтение отменено."); throw; }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"[ChatService] Ошибка при чтении: {ex.Message}"); Close(); throw; } 
        }
        public void Close()
        {
            CloseServer();
            CloseClient();
        }

        private void CloseServer()
        {
            if (_pipeServer != null)
            {
                System.Diagnostics.Debug.WriteLine("[ChatService - Сервер] Закрытие сервера...");
                Stream? currentStream = _stream;
                if (currentStream == _pipeServer) _stream = null; 
                try { if (_pipeServer.IsConnected) { } } catch { }
                try { _pipeServer.Close(); } catch { }
                try { _pipeServer.Dispose(); } catch { }
                _pipeServer = null;
                System.Diagnostics.Debug.WriteLine("[ChatService - Сервер] Сервер закрыт.");
            }
        }

        private void CloseClient()
        {
            if (_pipeClient != null)
            {
                System.Diagnostics.Debug.WriteLine("[ChatService - Клиент] Закрытие клиента...");
                Stream? currentStream = _stream;
                if (currentStream == _pipeClient) _stream = null; 
                try { _pipeClient.Close(); } catch { }
                try { _pipeClient.Dispose(); } catch { }
                _pipeClient = null;
                System.Diagnostics.Debug.WriteLine("[ChatService - Клиент] Клиент закрыт.");
            }
        }
        public void Dispose() { Dispose(true); GC.SuppressFinalize(this); }
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            System.Diagnostics.Debug.WriteLine($"[ChatService] Вызов Dispose(disposing={disposing})...");
            if (disposing)
            {
                Close(); 
            }
            _isDisposed = true;
            System.Diagnostics.Debug.WriteLine($"[ChatService] Ресурсы освобождены.");
        }
        ~ChatService() { Dispose(false); }
    }
}