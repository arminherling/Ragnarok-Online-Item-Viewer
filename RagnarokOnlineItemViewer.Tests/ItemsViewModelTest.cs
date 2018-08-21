using NUnit.Framework;
using RagnarokOnlineItemViewer.ViewModels;

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
