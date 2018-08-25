using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace RagnarokOnlineItemViewer
{
    public static class ColoredStringParser
    {
        private static readonly string _pattern = @"\^[0-9a-f]{6}";
        private static readonly RegexOptions _options = RegexOptions.IgnoreCase;
        private static BrushConverter _converter = new BrushConverter();

        public static List<(string, Brush)> Parse( string input )
        {
            var result = new List<(string, Brush)>();

            if( !string.IsNullOrWhiteSpace( input ) )
            {
                var matches = Regex.Matches( input, _pattern, _options );
                var substringStart = -1;
                var substringEnd = -1;

                foreach( Match m in matches )
                {
                    // first match isn't at the start of the input, so we need 
                    // to add the text before that as result with the default color
                    if( substringStart == -1 && m.Index != 0 )
                        result.Add( (input.Substring( 0, m.Index ), Brushes.Black) );

                    substringStart = m.Index + m.Length;
                    if( m.NextMatch().Success )
                    {
                        substringEnd = m.NextMatch().Index;
                    }
                    else
                    {
                        // last match
                        substringEnd = input.Length;
                    }

                    var hex = m.Value.Replace( '^', '#' );
                    var brush = (Brush)_converter.ConvertFromString( hex );
                    result.Add( (input.Substring( substringStart, substringEnd - substringStart ), brush) );
                }

                if( matches.Count == 0 )
                    result.Add( (input, Brushes.Black) );
            }

            return result;
        }
    }
}
