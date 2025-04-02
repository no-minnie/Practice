using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Models
{
    public class Room : INotifyPropertyChanged
    {
        private string _roomNumber = string.Empty;
        private string _roomType = string.Empty;
        private decimal _price;
        private RoomStatus _status;

        public string RoomNumber
        {
            get => _roomNumber;
            set => SetField(ref _roomNumber, value);
        }

        public string RoomType
        {
            get => _roomType;
            set => SetField(ref _roomType, value);
        }

        public decimal Price
        {
            get => _price;
            set => SetField(ref _price, value);
        }

        public RoomStatus Status
        {
            get => _status;
            set => SetField(ref _status, value);
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

        public override string ToString()
        {
            return $"Комната {RoomNumber} ({RoomType}) - {Status}";
        }
    }
}