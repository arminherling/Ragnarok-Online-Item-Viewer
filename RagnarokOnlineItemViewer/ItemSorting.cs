using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace RagnarokOnlineItemViewer
{
    public class ItemSorting
    {
        private GridViewColumnHeader _sortHeader;
        private SortAdorner _sortAdorner;
        private ListSortDirection _sortDirection = ListSortDirection.Descending;

        public void Sort(object sender, CollectionView list )
        {
            var columnHeader = ( sender as GridViewColumnHeader );
            if( columnHeader == null )
                return;

            list.SortDescriptions.Clear();

            if(_sortHeader != null )
                AdornerLayer.GetAdornerLayer( _sortHeader ).Remove( _sortAdorner );

            if( _sortDirection == ListSortDirection.Descending )
                _sortDirection = ListSortDirection.Ascending;
            else
                _sortDirection = ListSortDirection.Descending;

            _sortHeader = columnHeader;

            _sortAdorner = new SortAdorner( _sortHeader, _sortDirection );
            AdornerLayer.GetAdornerLayer( _sortHeader ).Add( _sortAdorner );

            var column = columnHeader.Content.ToString();
            list.SortDescriptions.Add( new SortDescription( column, _sortDirection ) );
        }
    }
}
