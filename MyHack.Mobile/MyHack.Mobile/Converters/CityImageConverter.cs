using System;
using Xamarin.Forms;

namespace MyHack.Mobile.Converters
{
    public class CityImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString().Contains("Chennai"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.chennai.png");
            }
            else if (value.ToString().Contains("Delhi"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.delhi.png");
            }
            else if (value.ToString().Contains("Hyderabad"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.hyderabad.png");
            }
            else if (value.ToString().Contains("Mumbai") || value.ToString().Contains("Thane"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.mumbai.png");
            }
            else if (value.ToString().ToLower().Contains("pune"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.pune.png");
            }
            else if (value.ToString().ToLower().Contains("jaipur"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.jaipur.png");
            }
            else if (value.ToString().ToLower().Contains("benguluru") || value.ToString().ToLower().Contains("bengaluru"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.bangalore.png");
            }
            else if (value.ToString().ToLower().Contains("bangalore") )
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.bangalore.png");
            }
            else if (value.ToString().ToLower().Contains("kolkata"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.kolkata.png");
            }
            else if (value.ToString().ToLower().Contains("ahmedabad"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.ahmedabad.png");
            }
            else if (value.ToString().ToLower().Contains("vasco"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.goa.png");
            }
            else
                return ImageSource.FromResource("MyHack.Mobile.Images.all.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
