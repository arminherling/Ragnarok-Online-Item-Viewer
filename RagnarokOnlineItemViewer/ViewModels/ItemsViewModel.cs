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
        }

        private BindableBase _itemDetailsViewModel;
        public BindableBase ItemDetailsViewModel
        {
            get => _itemDetailsViewModel;
            set => SetProperty( ref _itemDetailsViewModel, value );
        }
    }
} 
