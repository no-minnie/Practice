using HotelBookingApp.Models;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HotelBookingApp.Converters 
{
    public class StatusToBrushConverter : IValueConverter
    {
        public Brush AvailableBrush { get; set; } = new SolidColorBrush(Colors.Green);
        public Brush OccupiedBrush { get; set; } = new SolidColorBrush(Colors.OrangeRed);
        public Brush MaintenanceBrush { get; set; } = new SolidColorBrush(Colors.Gray);
        public Brush DefaultBrush { get; set; } = Brushes.Black;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is RoomStatus status)
            {
                switch (status)
                {
                    case RoomStatus.Available: return AvailableBrush;
                    case RoomStatus.Occupied: return OccupiedBrush;
                    case RoomStatus.Maintenance: return MaintenanceBrush;
                    default: return DefaultBrush;
                }
            }
            return DefaultBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}