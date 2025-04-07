using HotelBookingApp.Services;
using HotelBookingApp.Views;
using System.Windows;

namespace HotelBookingApp 
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var dataService = new DataService();
            var authService = new AuthService();
            var bookingService = new BookingService(dataService);
            var loginWindow = new LoginWindow(authService, bookingService, dataService);

            loginWindow.Show();
        }
    }
}