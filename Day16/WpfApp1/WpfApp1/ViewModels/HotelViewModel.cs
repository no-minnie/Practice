using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HotelBookingApp.Models;
using HotelBookingApp.Services;
using System.Collections.ObjectModel;
using System.Windows; 
using System.Diagnostics; 

namespace HotelBookingApp.ViewModels
{
    public partial class HotelViewModel : ObservableObject
    {
        private readonly BookingService _bookingService;

        [ObservableProperty] private ObservableCollection<RoomModel> _rooms;
        [ObservableProperty][NotifyCanExecuteChangedFor(nameof(BookRoomCommand))][NotifyCanExecuteChangedFor(nameof(CancelBookingCommand))][NotifyCanExecuteChangedFor(nameof(EditBookingCommand))] private RoomModel? _selectedRoom;
        [ObservableProperty][NotifyCanExecuteChangedFor(nameof(BookRoomCommand))][NotifyCanExecuteChangedFor(nameof(CancelBookingCommand))][NotifyCanExecuteChangedFor(nameof(EditBookingCommand))] private bool _isBusy = false;

        [ObservableProperty][NotifyCanExecuteChangedFor(nameof(BookRoomCommand))][NotifyCanExecuteChangedFor(nameof(EditBookingCommand))] private string _guestName = "";
        [ObservableProperty][NotifyCanExecuteChangedFor(nameof(BookRoomCommand))][NotifyCanExecuteChangedFor(nameof(EditBookingCommand))] private DateTime? _checkInDate = DateTime.Today;
        [ObservableProperty][NotifyCanExecuteChangedFor(nameof(BookRoomCommand))][NotifyCanExecuteChangedFor(nameof(EditBookingCommand))] private DateTime? _checkOutDate = DateTime.Today.AddDays(1);

        [ObservableProperty] private string? _currentBookingGuestName;
        [ObservableProperty] private DateTime? _currentBookingCheckInDate;
        [ObservableProperty] private DateTime? _currentBookingCheckOutDate;
        [ObservableProperty] private bool _isBookingInfoVisible = false;

        public HotelViewModel(BookingService bookingService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
            Rooms = new ObservableCollection<RoomModel>();
            LoadRooms();
            UpdateBookingInfoVisibility();
        }
        public HotelViewModel() : this(new BookingService()) { if (IsInDesignMode) { LoadRooms(); SelectedRoom = Rooms.FirstOrDefault(r => r.Status == RoomStatus.Occupied); /* Используем свойства с большой буквы */ GuestName = "Design Guest"; } }
        private bool IsInDesignMode => System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());

        private void LoadRooms()
        {
            Rooms.Clear();
            Rooms.Add(new RoomModel(1, "101", 50.00m, RoomStatus.Available));
            Rooms.Add(new RoomModel(2, "102", 55.00m, RoomStatus.Available));
            Rooms.Add(new RoomModel(3, "201", 70.00m, RoomStatus.Occupied));
            Rooms.Add(new RoomModel(4, "202", 75.00m, RoomStatus.Available));
            Rooms.Add(new RoomModel(5, "301 Suite", 150.00m, RoomStatus.Maintenance));

            var room201 = Rooms.FirstOrDefault(r => r.RoomNumber == "201");
            if (room201 != null && !_bookingService.GetAllActiveBookings().Any(b => b.RoomId == room201.Id))
            {
                var demoBooking = new BookingModel
                {
                    BookingId = _bookingService.GetAllActiveBookings().Count() + 100, // Примерный ID
                    RoomId = room201.Id,
                    BookedRoom = room201,
                    GuestName = "Иван Иванов (Демо)",
                    CheckInDate = DateTime.Today.AddDays(-2),
                    CheckOutDate = DateTime.Today.AddDays(3)
                };
            }

            OnSelectedRoomChanged(null, SelectedRoom);
        }
        partial void OnSelectedRoomChanged(RoomModel? oldValue, RoomModel? newValue)
        {
            ClearBookingInfo();
            if (newValue != null && newValue.Status == RoomStatus.Occupied)
            {
                BookingModel? existingBooking = _bookingService.GetBookingForRoom(newValue);
                if (existingBooking != null)
                {
                    CurrentBookingGuestName = existingBooking.GuestName;
                    CurrentBookingCheckInDate = existingBooking.CheckInDate;
                    CurrentBookingCheckOutDate = existingBooking.CheckOutDate;
                    GuestName = existingBooking.GuestName;
                    CheckInDate = existingBooking.CheckInDate;
                    CheckOutDate = existingBooking.CheckOutDate;
                }
                else { ClearEditableFormFields(); }
            }
            else { ClearEditableFormFields(); }
            UpdateBookingInfoVisibility();
        }

        [RelayCommand]
        private void PrepareNewBooking()
        {
            Debug.WriteLine("PrepareNewBooking executed.");
            SelectedRoom = null;
            ClearEditableFormFields();
            ClearBookingInfo();
            UpdateBookingInfoVisibility();
        }

        [RelayCommand(CanExecute = nameof(CanBookRoom))]
        private async Task BookRoomAsync()
        {
            if (SelectedRoom == null || !CheckInDate.HasValue || !CheckOutDate.HasValue) return;
            IsBusy = true;
            try
            {
                BookingModel? booking = await _bookingService.BookRoomAsync(SelectedRoom, GuestName, CheckInDate.Value, CheckOutDate.Value);
                MessageBox.Show($"Номер {booking?.BookedRoom?.RoomNumber} успешно забронирован для {booking?.GuestName}!", "Бронирование подтверждено", MessageBoxButton.OK, MessageBoxImage.Information); 
                OnSelectedRoomChanged(null, SelectedRoom);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка бронирования: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally { IsBusy = false; }
        }
        private bool CanBookRoom() => SelectedRoom != null && SelectedRoom.Status == RoomStatus.Available && !string.IsNullOrWhiteSpace(GuestName) && CheckInDate.HasValue && CheckOutDate.HasValue && CheckOutDate.Value.Date > CheckInDate.Value.Date && !IsBusy;

        [RelayCommand(CanExecute = nameof(CanCancelOrEditCurrentBooking))]
        private async Task CancelBookingAsync()
        {
            if (SelectedRoom == null || SelectedRoom.Status != RoomStatus.Occupied) return;
            BookingModel? bookingToCancel = _bookingService.GetBookingForRoom(SelectedRoom);
            if (bookingToCancel == null) { MessageBox.Show("Не найдено связанное бронирование.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning); return; } 

            var confirmResult = MessageBox.Show($"Отменить бронирование для {bookingToCancel.GuestName} в номере {SelectedRoom.RoomNumber}?", "Подтверждение отмены", MessageBoxButton.YesNo, MessageBoxImage.Question); 
            if (confirmResult == MessageBoxResult.Yes)
            {
                IsBusy = true;
                try
                {
                    bool success = await _bookingService.CancelBookingAsync(bookingToCancel);
                    if (success)
                    {
                        MessageBox.Show("Бронирование успешно отменено.", "Отмена подтверждена", MessageBoxButton.OK, MessageBoxImage.Information); 
                        ClearEditableFormFields(); ClearBookingInfo(); UpdateBookingInfoVisibility();
                    }
                    else { MessageBox.Show("Не удалось отменить бронирование.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning); } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при отмене: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally { IsBusy = false; }
            }
        }

        [RelayCommand(CanExecute = nameof(CanCancelOrEditCurrentBooking))]
        private async Task EditBookingAsync()
        {
            if (SelectedRoom == null || SelectedRoom.Status != RoomStatus.Occupied) return;
            BookingModel? bookingToEdit = _bookingService.GetBookingForRoom(SelectedRoom);
            if (bookingToEdit == null) { MessageBox.Show("Не найдено связанное бронирование для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning); return; } 

            MessageBoxResult confirmResult = MessageBox.Show($"Обновить бронь №{bookingToEdit.BookingId} для номера {SelectedRoom.RoomNumber} данными из формы?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question); // Иконка Question
            if (confirmResult == MessageBoxResult.Yes && CheckInDate.HasValue && CheckOutDate.HasValue)
            {
                var updatedBooking = new BookingModel { BookingId = bookingToEdit.BookingId, RoomId = SelectedRoom.Id, BookedRoom = SelectedRoom, GuestName = GuestName, CheckInDate = CheckInDate.Value, CheckOutDate = CheckOutDate.Value };
                IsBusy = true;
                try
                {
                    if (updatedBooking.CheckOutDate.Date <= updatedBooking.CheckInDate.Date) throw new ArgumentException("Дата выезда должна быть после даты заезда.");
                    if (string.IsNullOrWhiteSpace(updatedBooking.GuestName)) throw new ArgumentException("Имя гостя не может быть пустым.");
                    bool success = await _bookingService.EditBookingAsync(updatedBooking);
                    if (success)
                    {
                        MessageBox.Show("Бронирование успешно обновлено.", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Information); 
                                                                                                                                                
                        CurrentBookingGuestName = updatedBooking.GuestName;
                        CurrentBookingCheckInDate = updatedBooking.CheckInDate;
                        CurrentBookingCheckOutDate = updatedBooking.CheckOutDate;
                    }
                    else { MessageBox.Show("Не удалось обновить бронирование.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning); } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при редактировании: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally { IsBusy = false; }
            }
        }
        private bool CanCancelOrEditCurrentBooking() => SelectedRoom != null && SelectedRoom.Status == RoomStatus.Occupied && !IsBusy;

        [RelayCommand] private void ExitApplication() { if (Application.Current != null) Application.Current.Shutdown(); }
        [RelayCommand] private void RefreshRooms() { LoadRooms(); OnSelectedRoomChanged(null, SelectedRoom); MessageBox.Show("Список обновлен.", "Обновление", MessageBoxButton.OK, MessageBoxImage.Information); }

        private void ClearEditableFormFields() { GuestName = ""; CheckInDate = DateTime.Today; CheckOutDate = DateTime.Today.AddDays(1); }
        private void ClearBookingInfo() { CurrentBookingGuestName = null; CurrentBookingCheckInDate = null; CurrentBookingCheckOutDate = null; }
        private void UpdateBookingInfoVisibility() { IsBookingInfoVisible = SelectedRoom != null && SelectedRoom.Status == RoomStatus.Occupied && !string.IsNullOrEmpty(CurrentBookingGuestName); }
    }
}