using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HotelBookingApp.Converters
{
    public class BoolToBrushConverter : IValueConverter
    {
        public Brush TrueBrush { get; set; } = new SolidColorBrush(Color.FromRgb(0xE1, 0xEA, 0xF5)); 
        public Brush FalseBrush { get; set; } = new SolidColorBrush(Color.FromRgb(0xF1, 0xF3, 0xF5)); 

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue) { return boolValue ? TrueBrush : FalseBrush; }
            return FalseBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { throw new NotSupportedException(); }
    }
}