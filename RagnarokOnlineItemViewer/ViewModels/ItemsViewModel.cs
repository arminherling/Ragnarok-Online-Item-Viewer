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
            Items.Add( new Item( id: "503", name: "Yellow Potion", description: "^FF0000[NPC Buyable]^000000\nA potion made from ground Red Herbs that restores ^000088about 45 HP ^000000.\n^ffffff_ ^000000\nWeight:^777777 7 ^000000\nID:^777777 501 ^000000" ) );
            Items.Add( new Item( id: "504", name: "White Potion", description: "description" ) );
        }

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
