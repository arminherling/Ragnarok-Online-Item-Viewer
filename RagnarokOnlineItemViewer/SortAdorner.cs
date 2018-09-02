using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace RagnarokOnlineItemViewer
{
    public class SortAdorner : Adorner
    {
        private static Geometry _ascendingArrow = Geometry.Parse( "M 5,5 15,5 10,0 5,5" );
        private static Geometry _descendingArrow = Geometry.Parse( "M 5,0 10,5 15,0 5,0" );
        private readonly Geometry _geometry;

        public SortAdorner( UIElement adornedElement, ListSortDirection sortDirection ) 
            : base( adornedElement )
        {
            _geometry = ( sortDirection == ListSortDirection.Ascending ) 
                ? _ascendingArrow 
                : _descendingArrow;
        }

        protected override void OnRender( DrawingContext drawingContext )
        {
            var translateTransformation = new TranslateTransform( 
                AdornedElement.RenderSize.Width - 20, 
                ( AdornedElement.RenderSize.Height - 5 ) / 2 );

            if(translateTransformation.X >= 20 )
            {
                drawingContext.PushTransform( translateTransformation );
                drawingContext.DrawGeometry( Brushes.Black, null, _geometry );
                drawingContext.Pop();
            }
        }
    }
}
