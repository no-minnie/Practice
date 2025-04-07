using HotelBookingApp.ViewModels;
using HotelBookingApp.Services;
using System.Windows;

namespace HotelBookingApp.Views
{
    public partial class MainWindow : Window
    {
        private IDisposable? _chatViewModelDisposable;

        public MainWindow(BookingService bookingService, DataService dataService, bool isAdminRole)
        {
            InitializeComponent();

            var hotelViewModel = new HotelViewModel(bookingService, dataService);
            DataContext = hotelViewModel;

            var chatViewModel = new ChatViewModel(isAdminRole);
            _chatViewModelDisposable = chatViewModel as IDisposable;
            ChatViewInstance.DataContext = chatViewModel;

            this.Closed += MainWindow_Closed;
        }
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown(); 
            }
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            _chatViewModelDisposable?.Dispose();
            if (this.DataContext is IDisposable hotelViewModelDisposable)
            {
                hotelViewModelDisposable.Dispose();
            }
        }
    }
}