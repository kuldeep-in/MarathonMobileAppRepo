using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyHack.Mobile.Converters
{
    public class DateVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dateobj = DateTime.ParseExact(value.ToString(), "MMMM dd, yyyy", CultureInfo.InvariantCulture);

            if (dateobj < DateTime.Now)
            {
                return true;
            }
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
