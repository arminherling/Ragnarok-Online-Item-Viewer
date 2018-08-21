using Newtonsoft.Json;
using RagnarokOnlineItemViewer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace RagnarokOnlineItemViewer.ViewModels
{
    public class ItemsViewModel : BindableBase
    {
        public ItemsViewModel()
        {
            CurrentDetailsViewModel = new ItemDetailsViewModel();

            //var json = File.ReadAllText( "./Data/items.json" );
            //var list = JsonConvert.DeserializeObject<List<Item>>( json);
            //foreach( var i in list )
            //    Items.Add( i );

            System.Console.WriteLine( Items.Count );
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
