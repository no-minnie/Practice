namespace HotelBookingApp.Models
{
    public enum UserRole { Guest, Admin } 

    public class UserModel
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Guest; 
    }
}