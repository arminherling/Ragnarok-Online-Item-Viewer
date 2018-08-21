using Newtonsoft.Json;
using RagnarokOnlineItemViewer.Models;
using RagnarokOnlineItemViewer.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace RagnarokOnlineItemViewer.ViewModels
{
    public class ItemsViewModel : BindableBase
    {
        public ItemsViewModel( IRepository<Item> itemRepository )
        {
            _itemRepository = itemRepository;
            CurrentDetailsViewModel = new ItemDetailsViewModel();

            var allItems = _itemRepository.All();
            foreach(var item in allItems )
            {
                Items.Add( item );
            }
        }

        private IRepository<Item> _itemRepository { get; }

        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        
        private string _searchInput;
        public string SearchInput
        {
            get => _searchInput;
            set => SetPropertyAndRaise( ref _searchInput, value );
        }

        private Item _selectedItem;
        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetPropertyAndRaise( ref _selectedItem, value );
                UpdateDetailsViewModel();
            }
        }

        private ItemDetailsViewModel _currentDetailsViewModel;
        public ItemDetailsViewModel CurrentDetailsViewModel
        {
            get => _currentDetailsViewModel;
            set => SetPropertyAndRaise( ref _currentDetailsViewModel, value );
        }

        private void UpdateDetailsViewModel()
        {
            CurrentDetailsViewModel.SetItem( SelectedItem );
        }
    }
}
