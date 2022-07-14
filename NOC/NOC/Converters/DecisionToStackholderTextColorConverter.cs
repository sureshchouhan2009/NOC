using System;
using System.Globalization;
using Xamarin.Forms;

namespace NOC.Converters
{
    public class DecisionToStackholderTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int decisionID = (int)value;

          
            if (decisionID == 1)
            {
                return Color.Green;
            }
            else if (decisionID == 2)
            {
                return Color.Orange;
            }
            else if (decisionID == 3)
            {
                return Color.Red;
            }
            else
            {
                return Color.Green;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
