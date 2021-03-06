﻿using RagnarokOnlineItemViewer.Service;

namespace RagnarokOnlineItemViewer.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private BindableBase _currentViewModel;

        public MainWindowViewModel()
        {
            var repository = new ItemRepository( "./Data/items.json" );
            CurrentViewModel = new ItemsViewModel( repository );
        }

        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetPropertyAndRaise( ref _currentViewModel, value );
        }
    }
}
