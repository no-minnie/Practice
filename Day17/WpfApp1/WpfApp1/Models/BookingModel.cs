namespace HotelBookingApp.Models
{
    public class BookingModel
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; } 
        public string GuestName { get; set; } = string.Empty; 
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public RoomModel? BookedRoom { get; set; } 
    }
}