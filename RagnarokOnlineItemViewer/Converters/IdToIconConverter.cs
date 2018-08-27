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
            var iconPath = Path.Combine( directoryPath, String.Format( (string)parameter, value ) );
            if( File.Exists( iconPath ) )
                return iconPath;

            return Path.Combine( directoryPath, "Data\\unknown.png" );
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}
