using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RagnarokOnlineItemViewer.Converters
{
    public class BooleanToInvisibilityConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            bool result = false;
            if(value is bool b )
            {
                result = b;
            }
            return result ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}
