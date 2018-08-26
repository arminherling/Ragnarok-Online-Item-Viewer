using System.Windows.Media;

namespace RagnarokOnlineItemViewer
{
    public class ColoredStringSegment
    {
        public ColoredStringSegment( string text, Brush color )
        {
            Text = text;
            Color = color;
        }

        public string Text { get; }
        public Brush Color { get; }
    }
}
