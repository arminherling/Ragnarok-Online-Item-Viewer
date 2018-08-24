using System.Collections.Generic;
using System.Windows.Media;

namespace RagnarokOnlineItemViewer
{
    public class ColoredStringParser
    {
        public static List<(string, Brush)> Parse( string input )
        {
            var result = new List<(string, Brush)>();

            if( !string.IsNullOrWhiteSpace( input ) )
                result.Add( (input, Brushes.Black) );

            return result;
        }
    }
}
