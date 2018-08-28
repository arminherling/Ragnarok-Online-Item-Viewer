using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace RagnarokOnlineItemViewer.Converters
{
    public class IdToIconConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            var directoryPath = Path.GetDirectoryName( Process.GetCurrentProcess().MainModule.FileName );
            var split = ( parameter as string ).Split( '|' );
            var iconPath = Path.Combine( directoryPath, split[0], (string)value + split[1] );
            if( !File.Exists( iconPath ) )
                iconPath = null;

            return iconPath;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}
