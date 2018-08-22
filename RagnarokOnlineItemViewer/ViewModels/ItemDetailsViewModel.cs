using System;
using RagnarokOnlineItemViewer.Models;

namespace RagnarokOnlineItemViewer.ViewModels
{
    public class ItemDetailsViewModel : BindableBase
    {
        private Item _item;
 
        public void SetItem( Item item )
        {
            if( item == null )
                return;

            _item = item;
            OnPropertyChanged( nameof( ID ) );
            OnPropertyChanged( nameof( Name ) );
            OnPropertyChanged( nameof( Description ) );
        }

        public string ID => _item?.ID.ToString() ?? String.Empty;
        public string Name => _item?.Name ?? String.Empty;
        public string Description => _item?.Description ?? String.Empty;
    }
}
