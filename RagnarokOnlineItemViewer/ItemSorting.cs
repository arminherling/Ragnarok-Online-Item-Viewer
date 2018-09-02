using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace RagnarokOnlineItemViewer
{
    public class ItemSorting
    {
        private ListSortDirection _sortDirection = ListSortDirection.Descending;

        public void Sort(object columnHeader, CollectionView list )
        {
            string column = ( columnHeader as GridViewColumnHeader )?.Content?.ToString();
            if( column == null )
                return;

            if( _sortDirection == ListSortDirection.Descending )
                _sortDirection = ListSortDirection.Ascending;
            else
                _sortDirection = ListSortDirection.Descending;

            list.SortDescriptions.Clear();
            list.SortDescriptions.Add( new SortDescription( column, _sortDirection ) );
        }
    }
}
