using RagnarokOnlineItemViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnarokOnlineItemViewer.ViewModels
{
    class ItemsViewModel : BindableBase
    {
        public ItemsViewModel()
        {
            ItemDetailsViewModel = new ItemDetailsViewModel();
            ItemDetailsViewModel.SetItem( new Item( id: 123, name: "test", description: "description" ) );
        }

        private ItemDetailsViewModel _itemDetailsViewModel;
        public ItemDetailsViewModel ItemDetailsViewModel
        {
            get => _itemDetailsViewModel;
            set => SetProperty( ref _itemDetailsViewModel, value );
        }
    }
}
