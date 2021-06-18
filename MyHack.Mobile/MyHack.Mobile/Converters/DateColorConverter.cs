using System;
using Xamarin.Forms;

namespace MyHack.Mobile.Converters
{
    public class DateColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string currentDate = DateTime.Now.ToString("MMMM dd, yyyy");

            if (value.ToString() == currentDate)
            {
                return Color.FromHex("#d0e4ed");
            }
            //else if (value.ToString() == currentDate)
            //{
            //    return Color.FromHex("#42E2A8");
            //}
            else
                return Color.FromHex("#d0e4ed");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
