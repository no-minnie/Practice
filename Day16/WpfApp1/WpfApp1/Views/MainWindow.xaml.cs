using HotelBookingApp.Services;
using HotelBookingApp.ViewModels;
using System.Windows;

namespace HotelBookingApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 

            var bookingService = new BookingService();
            var viewModel = new HotelViewModel(bookingService);
            this.DataContext = viewModel;
        }
    }
}