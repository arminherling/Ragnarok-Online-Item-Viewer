using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set => SetProperty( ref _currentViewModel, value );
        }
    }
}
