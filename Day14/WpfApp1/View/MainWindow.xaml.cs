using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using WpfApp1.Models;

namespace WpfApp1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class RoomStatusToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is RoomStatus status)
            {
                switch (status)
                {
                    case RoomStatus.Available: return "Доступен";
                    case RoomStatus.Occupied: return "Занят";
                    case RoomStatus.Maintenance: return "На обслуживании";
                    default: return status.ToString();
                }
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RoomStatusToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is RoomStatus status)
            {
                switch (status)
                {
                    case RoomStatus.Available: return new SolidColorBrush(Colors.MediumSeaGreen);
                    case RoomStatus.Occupied: return new SolidColorBrush(Colors.IndianRed);
                    case RoomStatus.Maintenance: return new SolidColorBrush(Colors.SlateGray);
                    default: return Brushes.Transparent;
                }
            }
            return Brushes.Transparent;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}