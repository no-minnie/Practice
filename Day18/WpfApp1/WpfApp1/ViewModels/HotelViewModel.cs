using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HotelBookingApp.Models;
using HotelBookingApp.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace HotelBookingApp.ViewModels
{
    public partial class HotelViewModel : ObservableObject
    {
        private readonly BookingService _bookingService;
        private readonly DataService _dataService;

        [ObservableProperty]
        private ObservableCollection<Models.RoomModel> _rooms;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(BookRoomCommand))]
        [NotifyCanExecuteChangedFor(nameof(CancelBookingCommand))]
        [NotifyCanExecuteChangedFor(nameof(EditBookingCommand))]
        private Models.RoomModel? _selectedRoom;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(BookRoomCommand))]
        [NotifyCanExecuteChangedFor(nameof(EditBookingCommand))]
        private string _guestName = "";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(BookRoomCommand))]
        [NotifyCanExecuteChangedFor(nameof(EditBookingCommand))]
        private DateTime? _checkInDate = DateTime.Today;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(BookRoomCommand))]
        [NotifyCanExecuteChangedFor(nameof(EditBookingCommand))]
        private DateTime? _checkOutDate = DateTime.Today.AddDays(1);

        [ObservableProperty]
        private bool _isBusy = false;

        [ObservableProperty]
        private bool _isBookingInfoVisible = false;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CancelBookingCommand))]
        [NotifyCanExecuteChangedFor(nameof(EditBookingCommand))]
        private BookingModel? _currentBookingForSelectedRoom;

        [ObservableProperty]
        private string _currentBookingGuestName = "";

        [ObservableProperty]
        private DateTime? _currentBookingCheckInDate;

        [ObservableProperty]
        private DateTime? _currentBookingCheckOutDate;

        public HotelViewModel(BookingService bookingService, DataService dataService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            Rooms = new ObservableCollection<Models.RoomModel>();
            LoadRooms();
            LoadBookingDetailsForSelectedRoom();
        }

        [RelayCommand(CanExecute = nameof(CanBookRoom))]
        private async Task BookRoomAsync()
        {
            if (!CanBookRoom())
            {
                if (CheckInDate.HasValue && CheckInDate.Value.Date < DateTime.Today)
                    MessageBox.Show("Дата заезда не может быть раньше сегодняшнего дня.");
                else if (CheckOutDate.HasValue && CheckInDate.HasValue && CheckOutDate.Value.Date <= CheckInDate.Value.Date)
                    MessageBox.Show("Дата выезда должна быть позже даты заезда.");
                else if (SelectedRoom?.Status != RoomStatus.Available)
                    MessageBox.Show("Этот номер не доступен для бронирования.");
                else
                    MessageBox.Show("Пожалуйста, выберите свободный номер и заполните все поля корректно.");
                return;
            }
            if (SelectedRoom == null || string.IsNullOrWhiteSpace(GuestName) || CheckInDate == null || CheckOutDate == null) return;

            IsBusy = true;
            try
            {
                BookingModel newBooking = await _bookingService.BookRoomAsync(SelectedRoom, GuestName, CheckInDate.Value, CheckOutDate.Value);
                MessageBox.Show("Номер успешно забронирован!");
                LoadBookingDetailsForSelectedRoom();
            }
            catch (InvalidOperationException ioex) { MessageBox.Show($"Ошибка: {ioex.Message}"); }
            catch (ArgumentException aex) { MessageBox.Show($"Ошибка ввода: {aex.Message}"); }
            catch (Exception ex) { MessageBox.Show($"Непредвиденная ошибка при бронировании: {ex.Message}"); }
            finally { IsBusy = false; NotifyAllCommands(); }
        }

        private bool CanBookRoom()
        {
            return SelectedRoom != null
                && SelectedRoom.Status == RoomStatus.Available
                && !string.IsNullOrWhiteSpace(GuestName)
                && CheckInDate != null
                && CheckOutDate != null
                && CheckOutDate.Value.Date > CheckInDate.Value.Date
                && CheckInDate.Value.Date >= DateTime.Today
                && !IsBusy;
        }

        [RelayCommand(CanExecute = nameof(CanCancelBooking))]
        private async Task CancelBookingAsync()
        {
            if (CurrentBookingForSelectedRoom == null || SelectedRoom == null)
            {
                MessageBox.Show("Не выбран номер с активным бронированием для отмены.");
                return;
            }

            IsBusy = true;
            try
            {
                bool success = await _bookingService.CancelBookingAsync(CurrentBookingForSelectedRoom);
                if (success)
                {
                    MessageBox.Show("Бронирование успешно отменено!");
                    SelectedRoom.Status = RoomStatus.Available;
                    LoadBookingDetailsForSelectedRoom();
                    ClearEditableFormFields();
                }
                else { MessageBox.Show("Не удалось отменить бронирование."); }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка при отмене: {ex.Message}"); }
            finally { IsBusy = false; NotifyAllCommands(); }
        }

        [RelayCommand(CanExecute = nameof(CanEditBooking))]
        private async Task EditBookingAsync()
        {
            if (!CanEditBooking())
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно для редактирования (имя, даты не в прошлом, выезд после заезда).");
                return;
            }
            if (CurrentBookingForSelectedRoom == null || string.IsNullOrWhiteSpace(GuestName) || CheckInDate == null || CheckOutDate == null) return;

            IsBusy = true;
            try
            {
                var updatedBooking = new BookingModel
                {
                    BookingId = CurrentBookingForSelectedRoom.BookingId,
                    RoomId = CurrentBookingForSelectedRoom.RoomId,
                    BookedRoom = CurrentBookingForSelectedRoom.BookedRoom,
                    GuestName = this.GuestName, 
                    CheckInDate = this.CheckInDate.Value.Date,
                    CheckOutDate = this.CheckOutDate.Value.Date
                };
                bool success = await _bookingService.EditBookingAsync(updatedBooking);
                if (success)
                {
                    MessageBox.Show("Бронирование успешно отредактировано!");
                    LoadBookingDetailsForSelectedRoom();
                }
                else { MessageBox.Show("Не удалось отредактировать бронирование."); }
            }
            catch (ArgumentException aex) { MessageBox.Show($"Ошибка ввода: {aex.Message}"); }
            catch (Exception ex) { MessageBox.Show($"Ошибка при редактировании: {ex.Message}"); }
            finally { IsBusy = false; NotifyAllCommands(); }
        }

        private bool CanCancelBooking() { return CurrentBookingForSelectedRoom != null && !IsBusy; }

        private bool CanEditBooking()
        {
            return CurrentBookingForSelectedRoom != null
                   && !string.IsNullOrWhiteSpace(GuestName) 
                   && CheckInDate != null
                   && CheckOutDate != null
                   && CheckOutDate.Value.Date > CheckInDate.Value.Date
                   && (CheckInDate.Value.Date >= DateTime.Today || CheckInDate.Value.Date == CurrentBookingForSelectedRoom?.CheckInDate.Date) 
                   && !IsBusy;
        }

        private void LoadRooms()
        {
            Rooms.Clear();
            var roomsData = _bookingService.GetAllRooms();
            foreach (var room in roomsData) { Rooms.Add(room); }
        }

        partial void OnSelectedRoomChanged(Models.RoomModel? oldValue, Models.RoomModel? newValue)
        {
            LoadBookingDetailsForSelectedRoom();
        }

        private void LoadBookingDetailsForSelectedRoom()
        {
            CurrentBookingForSelectedRoom = SelectedRoom != null ? _bookingService.GetBookingForRoom(SelectedRoom) : null;
            IsBookingInfoVisible = CurrentBookingForSelectedRoom != null;

            if (IsBookingInfoVisible && CurrentBookingForSelectedRoom != null)
            {
                CurrentBookingGuestName = CurrentBookingForSelectedRoom.GuestName;
                CurrentBookingCheckInDate = CurrentBookingForSelectedRoom.CheckInDate;
                CurrentBookingCheckOutDate = CurrentBookingForSelectedRoom.CheckOutDate;
                GuestName = CurrentBookingForSelectedRoom.GuestName; 
                CheckInDate = CurrentBookingForSelectedRoom.CheckInDate;
                CheckOutDate = CurrentBookingForSelectedRoom.CheckOutDate;
            }
            else
            {
                ClearBookingInfo();
            }
            NotifyAllCommands();
        }

        private void ClearBookingInfo() { CurrentBookingGuestName = ""; CurrentBookingCheckInDate = null; CurrentBookingCheckOutDate = null; }
        private void ClearEditableFormFields() { GuestName = ""; CheckInDate = DateTime.Today; CheckOutDate = DateTime.Today.AddDays(1); }
        private void NotifyAllCommands() { BookRoomCommand.NotifyCanExecuteChanged(); EditBookingCommand.NotifyCanExecuteChanged(); CancelBookingCommand.NotifyCanExecuteChanged(); }
    }
}