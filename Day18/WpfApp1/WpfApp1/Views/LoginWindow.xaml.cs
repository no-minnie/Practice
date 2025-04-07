using HotelBookingApp.Models; 
using HotelBookingApp.Services;
using System.Windows;

namespace HotelBookingApp.Views 
{
    public partial class LoginWindow : Window
    {
        private readonly AuthService _authService;
        private readonly BookingService _bookingService;
        private readonly DataService _dataService;
        public LoginWindow(AuthService authService, BookingService bookingService, DataService dataService)
        {
            InitializeComponent(); 
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            UserModel? loggedInUser = _authService.Login(username, password);

            if (loggedInUser != null) 
            {
                bool isAdmin = (loggedInUser.Role == UserRole.Admin); 
                var mainWindow = new MainWindow(_bookingService, _dataService, isAdmin);
                mainWindow.Show();
                Close(); 
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_authService.Register(username, password))
            {
                MessageBox.Show("Регистрация успешна. Теперь войдите.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}