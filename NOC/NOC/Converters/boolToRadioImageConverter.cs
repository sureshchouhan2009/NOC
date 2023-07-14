using System;
using System.Globalization;
using Xamarin.Forms;

namespace NOC.Converters
{
    public class boolToRadioImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool input = (bool)value;

            return input ? "selectedRadioButton.png" : "UnSelectedRadioButton.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
