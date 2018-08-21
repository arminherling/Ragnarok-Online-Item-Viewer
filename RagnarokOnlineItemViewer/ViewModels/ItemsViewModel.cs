using RagnarokOnlineItemViewer.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RagnarokOnlineItemViewer.ViewModels
{
    public class ItemsViewModel : BindableBase
    {
        public ItemsViewModel()
        {
            CurrentDetailsViewModel = new ItemDetailsViewModel();

            Items.Add( new Item( id: "501", name: "Red Potion", description: "description" ) );
            Items.Add( new Item( id: "502", name: "Orange Potion", description: "description" ) );
            Items.Add( new Item( id: "503", name: "Yellow Potion", description: "long description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\nlong description\n" ) );
            Items.Add( new Item( id: "504", name: "White Potion", description: "description" ) );

            SelectedItemChangedCommand = new DelegateCommand( UpdateDetails );
        }

        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        public ICommand SelectedItemChangedCommand { get; }

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

        private ItemDetailsViewModel _currentDetailsViewModel;
        public ItemDetailsViewModel CurrentDetailsViewModel
        {
            get => _currentDetailsViewModel;
            set => SetProperty( ref _currentDetailsViewModel, value );
        }

        private void UpdateDetails()
        {
            CurrentDetailsViewModel.SetItem( SelectedItem );
        }
    }
}
