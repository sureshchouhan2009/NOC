using System;
using System.Globalization;
using Xamarin.Forms;

namespace NOC.Converters
{
    public class ConditionTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
              string condition= value.ToString();
                if (condition == "System")
                {
                    return Color.DarkGray;
                }
                else
                {
                    return Color.FromHex("#aa182c");
                }
            }
            catch (Exception ex)
            {

             return Color.DarkGray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
