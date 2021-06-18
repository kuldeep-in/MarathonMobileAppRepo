using System;
using Xamarin.Forms;

namespace MyHack.Mobile.Converters
{
    public class LevelColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string currentDate = DateTime.Now.ToString("MMMM dd, yyyy");

            if (value.ToString().Contains("Basic"))
            {
                return Color.FromHex("#FFFF80");
            }
            else if (value.ToString().Contains("Intermediate"))
            {
                return Color.FromHex("#A2EAFA");
            }
            else
                return Color.FromHex("#42E2A8");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
