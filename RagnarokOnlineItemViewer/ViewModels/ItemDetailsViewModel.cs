using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RagnarokOnlineItemViewer.Models;

namespace RagnarokOnlineItemViewer.ViewModels
{
    public class ItemDetailsViewModel : BindableBase
    {
        public string ID => _item?.ID.ToString() ?? String.Empty;
        public string Name => _item?.Name ?? String.Empty;
        public string Description => _item?.Description ?? String.Empty;

        private Item _item;
 
        public void SetItem( Item item )
        {
            _item = item;
            OnPropertyChanged( nameof( ID ) );
            OnPropertyChanged( nameof( Name ) );
            OnPropertyChanged( nameof( Description ) );
        }
    }
}
