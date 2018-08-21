using NUnit.Framework;
using RagnarokOnlineItemViewer.Tests.Fakes;
using RagnarokOnlineItemViewer.ViewModels;

namespace RagnarokOnlineItemViewer.Tests
{
    [TestFixture]
    class ItemsViewModelTest
    {
        [Test]
        public void CurrentDetailsView_ReturnsItemsDetailsView_AfterCreatingNewItemsViewModel()
        {
            var itemsViewModel = new ItemsViewModel(new FakeItemRepository());
            var expectedType = typeof( ItemDetailsViewModel );

            var currentDetails = itemsViewModel.CurrentDetailsViewModel;

            Assert.IsAssignableFrom( expectedType, currentDetails );
        }
    }
}
