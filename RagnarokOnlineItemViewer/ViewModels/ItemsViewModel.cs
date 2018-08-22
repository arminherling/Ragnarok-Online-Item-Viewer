﻿using RagnarokOnlineItemViewer.Models;
using RagnarokOnlineItemViewer.Service;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace RagnarokOnlineItemViewer.ViewModels
{
    public class ItemsViewModel : BindableBase
    {
        private ObservableCollection<Item> _itemCollection = new ObservableCollection<Item>();
        private CollectionViewSource _itemViewSource = new CollectionViewSource();
        private ItemDetailsViewModel _currentDetailsViewModel = new ItemDetailsViewModel();
        private IRepository<Item> _itemRepository;
        private string _searchInput;
        private Item _selectedItem;

        public ItemsViewModel( IRepository<Item> itemRepository )
        {
            _itemRepository = itemRepository;
            _itemViewSource.Source = _itemCollection;
            _itemViewSource.Filter += ApplyItemFilter;

            foreach( var item in _itemRepository.All() )
                _itemCollection.Add( item );
        }

        public ICollectionView Items => _itemViewSource.View;

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

        private void UpdateListViewFilter() => Items.Refresh();

        private void UpdateDetailsViewModel() => CurrentDetailsViewModel.SetItem( SelectedItem );
    }
}
