using System;
using System.Globalization;
using Xamarin.Forms;

namespace NOC.Converters
{
    public class DecisionToStackholderTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          int decisionID= (int) value;

            string stackholderResponseText = "";
            if (decisionID == 1)
            {
               return stackholderResponseText = "Approved";
            }
            else if (decisionID == 2)
            {
                return stackholderResponseText = "Approved with Conditions";
            }
            else if (decisionID == 3)
            {
                return stackholderResponseText = "Rejected";
            }
            else
            {
                return stackholderResponseText = "";
            }
                
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
