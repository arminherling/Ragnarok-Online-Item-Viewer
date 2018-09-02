using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace RagnarokOnlineItemViewer
{
    public class ItemSortingBehavior : Behavior<ListView>
    {
        private ItemSorting _sorting;

        public ItemSortingBehavior()
        {
            _sorting = new ItemSorting();
        }

        protected override void OnAttached()
        {
            AssociatedObject.AddHandler( 
                GridViewColumnHeader.ClickEvent, 
                new RoutedEventHandler( OnColumnHeaderClicked ) );
        }

        protected override void OnDetaching()
        {
            AssociatedObject.RemoveHandler( 
                GridViewColumnHeader.ClickEvent, 
                new RoutedEventHandler( OnColumnHeaderClicked ) );
        }

        private void OnColumnHeaderClicked(object sender, RoutedEventArgs e )
        {
            if( !( sender is ListView listView ) )
                return;

            _sorting.Sort( e.OriginalSource, listView.Items );
        }
    }
}
