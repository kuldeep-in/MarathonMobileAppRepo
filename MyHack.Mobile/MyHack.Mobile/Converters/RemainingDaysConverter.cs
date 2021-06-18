using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyHack.Mobile.Converters
{
    public class RemainingDaysConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dateobj = DateTime.ParseExact(value.ToString(), "dd MMMM yyyy", CultureInfo.InvariantCulture);
            var daysdiff = (dateobj - DateTime.Now).TotalDays;

            return System.Convert.ToInt32(daysdiff);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}