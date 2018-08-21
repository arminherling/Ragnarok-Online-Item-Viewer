using NUnit.Framework;
using RagnarokOnlineItemViewer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnarokOnlineItemViewer.Tests
{
    [TestFixture]
    class ItemsViewModelTest
    {
        [Test]
        public void CurrentDetailsView_ReturnsItemsDetailsView_AfterCreatingNewItemsViewModel()
        {
            var itemsViewModel = new ItemsViewModel();
            var expectedType = typeof( ItemDetailsViewModel );

            var currentDetails = itemsViewModel.CurrentDetailsViewModel;

            Assert.IsAssignableFrom( expectedType, currentDetails );
        }
    }
}
