using System;
using System.Globalization;
using Xamarin.Forms;

namespace NOC.Converters
{
    public class ReadStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool input = (bool)value;

            return input ? Color.DarkGray : Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
