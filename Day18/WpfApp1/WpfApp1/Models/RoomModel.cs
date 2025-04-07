using CommunityToolkit.Mvvm.ComponentModel;

namespace HotelBookingApp.Models
{
    public partial class RoomModel : ObservableObject
    {
        [ObservableProperty]
        private int _id;

        [ObservableProperty]
        private string _roomNumber = "";

        [ObservableProperty]
        private decimal _pricePerNight;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(StatusDisplay))] 
        private RoomStatus _status;

        public string StatusDisplay => Status.ToString(); 

        public RoomModel(int id, string roomNumber, decimal price, RoomStatus status = RoomStatus.Available)
        {
            Id = id; 
            RoomNumber = roomNumber;
            PricePerNight = price;
            Status = status;
        }
        public RoomModel() : this(0, "N/A", 0, RoomStatus.Maintenance) { }
    }
}