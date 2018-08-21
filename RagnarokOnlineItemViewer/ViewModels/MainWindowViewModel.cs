namespace RagnarokOnlineItemViewer.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            CurrentViewModel = new ItemsViewModel();
        }

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetPropertyAndRaise( ref _currentViewModel, value );
        }
    }
}
