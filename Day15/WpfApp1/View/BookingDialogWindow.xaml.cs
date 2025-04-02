using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp1.Views
{
    public partial class BookingDialogWindow : Window
    {
        public BookingDialogWindow()
        {
            InitializeComponent();
        }

        public void CloseDialog(bool dialogResult)
        {
            try
            {
                this.DialogResult = dialogResult;
                this.Close();
            }
            catch (InvalidOperationException)
            {
                if (this.IsLoaded)
                {
                    this.Close();
                }
            }
        }
    }

    public class BoolToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isReadOnly && isReadOnly)
            {
                return new SolidColorBrush(Color.FromRgb(240, 240, 240));
            }
            return SystemColors.WindowBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringNullOrEmptyToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value as string);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}