using System;
using Xamarin.Forms;

namespace MyHack.Mobile.Converters
{
    public class ImageResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString().Contains("walk"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.3walk.png");
            }
            else if (value.ToString().ToLower().Contains("sprint"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.5sprint.png");
            }
            else if (value.ToString().ToLower().Contains("pace"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.5sprint.png");
            }
            else if (value.ToString().Contains("cross"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.4cross.png");
            }
            else if (value.ToString().ToLower().Contains("rest"))
            {
                return ImageSource.FromResource("MyHack.Mobile.Images.1rest.png");
            }
            else
                return ImageSource.FromResource("MyHack.Mobile.Images.2run.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
