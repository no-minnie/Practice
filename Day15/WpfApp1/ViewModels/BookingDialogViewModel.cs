using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    public class BookingDialogViewModel : INotifyPropertyChanged
    {
        private string _windowTitle = "Бронирование";
        private bool _isRoomNumberReadOnly = false;
        private string? _errorMessage;
        private Booking _bookingData;
        private readonly Action<Booking> _onSave;
        private readonly BookingDialogWindow _window;

        public string WindowTitle
        {
            get => _windowTitle;
            set => SetField(ref _windowTitle, value);
        }

        public string ClientName
        {
            get => _bookingData.ClientName;
            set
            {
                if (_bookingData.ClientName != value)
                {
                    _bookingData.ClientName = value;
                    OnPropertyChanged();
                    Validate();
                }
            }
        }

        public string RoomNumber
        {
            get => _bookingData.RoomNumber;
            set
            {
                if (_bookingData.RoomNumber != value)
                {
                    _bookingData.RoomNumber = value;
                    OnPropertyChanged();
                    Validate();
                }
            }
        }

        public DateTime StartDate
        {
            get => _bookingData.StartDate;
            set
            {
                if (_bookingData.StartDate != value)
                {
                    _bookingData.StartDate = value;
                    OnPropertyChanged();
                    Validate();
                }
            }
        }

        public DateTime EndDate
        {
            get => _bookingData.EndDate;
            set
            {
                if (_bookingData.EndDate != value)
                {
                    _bookingData.EndDate = value;
                    OnPropertyChanged();
                    Validate();
                }
            }
        }

        public string? ErrorMessage
        {
            get => _errorMessage;
            private set => SetField(ref _errorMessage, value);
        }

        public bool IsRoomNumberReadOnly
        {
            get => _isRoomNumberReadOnly;
            private set => SetField(ref _isRoomNumberReadOnly, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public BookingDialogViewModel(BookingDialogWindow window, Action<Booking> onSaveCallback, bool isEditing)
        {
            _window = window;
            _onSave = onSaveCallback;
            _bookingData = new Booking { StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1) };
            IsRoomNumberReadOnly = isEditing;
            WindowTitle = isEditing ? "Редактирование брони" : "Новое бронирование";
            SaveCommand = new RelayCommand(ExecuteSave, CanExecuteSave);
            CancelCommand = new RelayCommand(ExecuteCancel);
            Validate();
        }

        public BookingDialogViewModel(BookingDialogWindow window, Booking bookingToEditCopy, Action<Booking> onSaveCallback, bool isEditing)
            : this(window, onSaveCallback, isEditing)
        {
            _bookingData = bookingToEditCopy;
            WindowTitle = $"Редактирование брони №{_bookingData.Id}";
            OnPropertyChanged(nameof(ClientName));
            OnPropertyChanged(nameof(RoomNumber));
            OnPropertyChanged(nameof(StartDate));
            OnPropertyChanged(nameof(EndDate));
            Validate();
        }

        private void ExecuteSave(object? parameter)
        {
            if (!Validate()) return;
            _onSave(_bookingData);
            _window.CloseDialog(true);
        }

        private void ExecuteCancel(object? parameter)
        {
            _window.CloseDialog(false);
        }

        private bool CanExecuteSave(object? parameter)
        {
            return string.IsNullOrEmpty(ErrorMessage);
        }

        private bool Validate()
        {
            ErrorMessage = null;
            if (string.IsNullOrWhiteSpace(ClientName)) ErrorMessage = "Имя клиента не может быть пустым.";
            else if (!IsRoomNumberReadOnly && string.IsNullOrWhiteSpace(RoomNumber)) ErrorMessage = "Номер комнаты не может быть пустым.";
            else if (StartDate.Date < DateTime.Today && !IsRoomNumberReadOnly) ErrorMessage = "Дата заезда не может быть в прошлом.";
            else if (EndDate.Date <= StartDate.Date) ErrorMessage = "Дата выезда должна быть позже даты заезда.";

            (SaveCommand as RelayCommand)?.RaiseCanExecuteChanged();
            return string.IsNullOrEmpty(ErrorMessage);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}