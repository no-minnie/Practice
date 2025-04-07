namespace HotelBookingApp.Models
{
    public class ChatMessageModel
    {
        public string Sender { get; set; } = string.Empty; 
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public bool IsSentByUser { get; set; } 
    }
}