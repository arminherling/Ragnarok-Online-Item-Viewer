using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace RagnarokOnlineItemViewer.Controls
{
    public class ColoredRichTextBox : RichTextBox
    {
        public static readonly DependencyProperty RichTextProperty = DependencyProperty.Register(
            "Text",
            typeof( string ),
            typeof( ColoredRichTextBox ),
            new PropertyMetadata( null, ColoredRichTextPropertyChanged ) );

        public string Text
        {
            get => (string)GetValue( RichTextProperty );
            set => SetValue( RichTextProperty, value );
        }

        private static void ColoredRichTextPropertyChanged( DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs )
        {
            ColoredRichTextBox richTextBox = (ColoredRichTextBox)dependencyObject;
            richTextBox.Document.Blocks.Clear();

            var paragraph = new Paragraph();
            richTextBox.Document.Blocks.Add( paragraph );

            var text = (string)dependencyPropertyChangedEventArgs.NewValue;
            paragraph.Inlines.Add( new Run( text ) );
        }
    }
}
