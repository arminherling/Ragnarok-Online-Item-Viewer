using RagnarokOnlineItemViewer.Service;

namespace RagnarokOnlineItemViewer.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            var repository = new ItemRepository( "/Data/items.json" );
            CurrentViewModel = new ItemsViewModel( repository );
        }

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetPropertyAndRaise( ref _currentViewModel, value );
        }
    }
}
