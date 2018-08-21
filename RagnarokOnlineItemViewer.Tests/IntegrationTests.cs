using NUnit.Framework;
using RagnarokOnlineItemViewer.Models;
using RagnarokOnlineItemViewer.Tests.Fakes;
using RagnarokOnlineItemViewer.ViewModels;

namespace RagnarokOnlineItemViewer.Tests
{
    [TestFixture]
    class IntegrationTests
    {
        [Test]
        public void CurrentDetailsView_ReturnsDetailsOfSelectedItem_AfterInvokingCurrentItemChangedCommand()
        {
            var expectedItem = new Item( 
                id: "501", 
                name: "Red Potion", 
                description: "A potion made from ground Red Herbs that restores about 45 HP." );
            var itemsViewModel = new ItemsViewModel(new FakeItemRepository());

            itemsViewModel.SelectedItem = expectedItem;
           
            Assert.AreEqual( expectedItem.ID, itemsViewModel.CurrentDetailsViewModel.ID );
            Assert.AreEqual( expectedItem.Name, itemsViewModel.CurrentDetailsViewModel.Name );
            Assert.AreEqual( expectedItem.Description, itemsViewModel.CurrentDetailsViewModel.Description );
        }
    }
}
