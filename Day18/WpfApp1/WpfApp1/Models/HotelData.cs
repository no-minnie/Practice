namespace HotelBookingApp.Models
{
    public class HotelData
    {
        public List<RoomModel> Rooms { get; set; } = new List<RoomModel>();
        public List<BookingModel> Bookings { get; set; } = new List<BookingModel>();
        public List<ClientModel> Clients { get; set; } = new List<ClientModel>();
    }
}