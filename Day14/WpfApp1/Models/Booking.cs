using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Models
{
    public class Booking : INotifyPropertyChanged
    {
        private int _id;
        private string _clientName = string.Empty;
        private string _roomNumber = string.Empty;
        private DateTime _startDate;
        private DateTime _endDate;

        public int Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public string ClientName
        {
            get => _clientName;
            set
            {
                if (SetField(ref _clientName, value))
                {
                    OnPropertyChanged(nameof(BookingSummary));
                }
            }
        }

        public string RoomNumber
        {
            get => _roomNumber;
            set
            {
                if (SetField(ref _roomNumber, value))
                {
                    OnPropertyChanged(nameof(BookingSummary));
                }
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (SetField(ref _startDate, value))
                {
                    OnPropertyChanged(nameof(BookingSummary));
                }
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (SetField(ref _endDate, value))
                {
                    OnPropertyChanged(nameof(BookingSummary));
                }
            }
        }

        public string BookingSummary => $"Бронь №{Id}: {ClientName} (Комн.: {RoomNumber}) с {StartDate:dd.MM.yyyy} по {EndDate:dd.MM.yyyy}";

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
            return BookingSummary;
        }
    }
}