using RagnarokOnlineItemViewer.Models;
using RagnarokOnlineItemViewer.Service;
using System.Collections.ObjectModel;

namespace RagnarokOnlineItemViewer.ViewModels
{
    public class ItemsViewModel : BindableBase
    {
        private string _searchInput;
        private Item _selectedItem;
        private ItemDetailsViewModel _currentDetailsViewModel;
        private IRepository<Item> _itemRepository { get; }

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

        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        
        public string SearchInput
        {
            get => _searchInput;
            set => SetPropertyAndRaise( ref _searchInput, value );
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetPropertyAndRaise( ref _selectedItem, value );
                UpdateDetailsViewModel();
            }
        }

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
