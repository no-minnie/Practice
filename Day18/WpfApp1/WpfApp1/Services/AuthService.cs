using HotelBookingApp.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace HotelBookingApp.Services
{
    public class AuthService
    {
        private readonly string _usersFilePath = "users.json";
        private List<UserModel> _users;

        public AuthService()
        {
            if (File.Exists(_usersFilePath))
            {
                string json = File.ReadAllText(_usersFilePath);
                _users = JsonConvert.DeserializeObject<List<UserModel>>(json) ?? new List<UserModel>();
            }
            else
            {
                _users = new List<UserModel>();
            }
        }

        public bool Register(string username, string password)
        {
            if (_users.Any(u => u.Username == username))
                return false;

            string passwordHash = HashPassword(password);
            _users.Add(new UserModel { Username = username, PasswordHash = passwordHash, Role = UserRole.Guest });
            SaveUsers();
            return true;
        }

        public UserModel? Login(string username, string password) 
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return user; 
            }
            return null;
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPassword(string password, string hash)
        {
            return hash == Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }

        private void SaveUsers()
        {
            string json = JsonConvert.SerializeObject(_users, Formatting.Indented);
            File.WriteAllText(_usersFilePath, json);
        }
    }
}