using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HotelBookingApp.Converters
{
    public class BoolToAlignmentConverter : IValueConverter
    {
        public HorizontalAlignment SentAlignment { get; set; } = HorizontalAlignment.Right;
        public HorizontalAlignment ReceivedAlignment { get; set; } = HorizontalAlignment.Left;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isSentByUser)
            {
                return isSentByUser ? SentAlignment : ReceivedAlignment;
            }
            return ReceivedAlignment;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}