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
        public void CurrentDetailsView_ReturnsDetailsOfSelectedItem_AfterSettingNewSelectedItem()
        {
            var expectedItem = new Item(
                id: 501,
                name: "Red Potion",
                description: "A potion made from ground Red Herbs that restores about 45 HP." );
            var itemsViewModel = new ItemsViewModel( new FakeItemRepository() );

            itemsViewModel.SelectedItem = expectedItem;

            Assert.AreEqual( expectedItem.ID.ToString(), itemsViewModel.CurrentDetailsViewModel.ID );
            Assert.AreEqual( expectedItem.Name, itemsViewModel.CurrentDetailsViewModel.Name );
            Assert.AreEqual( expectedItem.Description, itemsViewModel.CurrentDetailsViewModel.Description );
        }

        [Test]
        public void CurrentDetailsView_ReturnsDetailsOfFirstItem_IfThereAreAnyItems()
        {
            var expectedItem = new Item(
                id: 501,
                name: "Red Potion",
                description: "A potion made from ground Red Herbs that restores about 45 HP." );
            var fakeRepo = new FakeItemRepository();
            fakeRepo.AddFake( expectedItem );

            var itemsViewModel = new ItemsViewModel( fakeRepo );

            Assert.AreEqual( expectedItem.ID.ToString(), itemsViewModel.CurrentDetailsViewModel.ID );
            Assert.AreEqual( expectedItem.Name, itemsViewModel.CurrentDetailsViewModel.Name );
            Assert.AreEqual( expectedItem.Description, itemsViewModel.CurrentDetailsViewModel.Description );
        }

        [Test]
        public void CurrentDetailsView_ReturnsEmptyStrings_IfThereAreNoItems()
        {
            var fakeRepo = new FakeItemRepository();

            var itemsViewModel = new ItemsViewModel( fakeRepo );

            Assert.IsEmpty( itemsViewModel.CurrentDetailsViewModel.ID );
            Assert.IsEmpty( itemsViewModel.CurrentDetailsViewModel.Name );
            Assert.IsEmpty( itemsViewModel.CurrentDetailsViewModel.Description );
        }
    }
}
