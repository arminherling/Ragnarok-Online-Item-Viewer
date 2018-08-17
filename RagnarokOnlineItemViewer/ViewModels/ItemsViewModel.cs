using RagnarokOnlineItemViewer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            Items.Add( new Item( id: 1, name: "test", description: "description" ) );
            Items.Add( new Item( id: 2, name: "test", description: "description" ) );
            Items.Add( new Item( id: 3, name: "test", description: "description" ) );
            Items.Add( new Item( id: 4, name: "test", description: "description" ) );
        }

        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        private string _searchInput;
        public string SearchInput
        {
            get => _searchInput;
            set => SetProperty( ref _searchInput, value );
        }

        private Item _selectedItem;
        public Item SelectedItem
        {
            get => _selectedItem;
            set => SetProperty( ref _selectedItem, value );
        }

        private ItemDetailsViewModel _itemDetailsViewModel;
        public ItemDetailsViewModel ItemDetailsViewModel
        {
            get => _itemDetailsViewModel;
            set => SetProperty( ref _itemDetailsViewModel, value );
        }
    }
}
