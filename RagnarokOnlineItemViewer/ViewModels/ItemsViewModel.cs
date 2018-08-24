using RagnarokOnlineItemViewer.Models;
using RagnarokOnlineItemViewer.Service;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;

namespace RagnarokOnlineItemViewer.ViewModels
{
    public class ItemsViewModel : BindableBase
    {
        private Item _selectedItem;
        private string _searchInput;
        private int _totalItemCount;
        private int _filteredItemCount;
        private IRepository<Item> _itemRepository;
        private ObservableCollection<Item> _itemCollection = new ObservableCollection<Item>();
        private CollectionViewSource _itemViewSource = new CollectionViewSource();
        private ItemDetailsViewModel _currentDetailsViewModel = new ItemDetailsViewModel();

        public ItemsViewModel( IRepository<Item> itemRepository )
        {
            _itemRepository = itemRepository;
            _itemViewSource.Source = _itemCollection;
            _itemViewSource.Filter += ApplyItemFilter;

            foreach( var item in _itemRepository.All() )
                _itemCollection.Add( item );

            TotalItemCount = _itemCollection.Count;

            if( TotalItemCount >= 1 )
                SelectedItem = _itemCollection.First();
        }

        public ICollectionView Items => _itemViewSource.View;

        public bool SearchIsActive => !string.IsNullOrWhiteSpace( SearchInput );

        public int TotalItemCount
        {
            get => _totalItemCount;
            set => SetPropertyAndRaise( ref _totalItemCount, value );
        }

        public int FilteredItemCount
        {
            get => _filteredItemCount;
            set => SetPropertyAndRaise( ref _filteredItemCount, value );
        }

        public string SearchInput
        {
            get => _searchInput;
            set
            {
                SetPropertyAndRaise( ref _searchInput, value );
                UpdateListViewFilter();
            }
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

        private void ApplyItemFilter( object sender, FilterEventArgs e )
        {
            Item item = (Item)e.Item;
            if( string.IsNullOrWhiteSpace( SearchInput ) || SearchInput.Length == 0 )
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = item.ID.IndexOf( SearchInput, StringComparison.OrdinalIgnoreCase ) >= 0
                    || item.Name.IndexOf( SearchInput, StringComparison.OrdinalIgnoreCase ) >= 0;
            }
        }

        private void UpdateListViewFilter()
        {
            Items.Refresh();
            OnPropertyChanged( nameof( SearchIsActive ) );
            FilteredItemCount = Items.Cast<object>().Count();
        }

        private void UpdateDetailsViewModel() => CurrentDetailsViewModel.SetItem( SelectedItem );
    }
}
