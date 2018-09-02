using NUnit.Framework;
using RagnarokOnlineItemViewer.Models;
using RagnarokOnlineItemViewer.Tests.Fakes;
using RagnarokOnlineItemViewer.ViewModels;
using System.Linq;

namespace RagnarokOnlineItemViewer.Tests
{
    [TestFixture]
    class ItemsViewModelTests
    {
        [Test]
        public void CurrentDetailsView_ReturnsItemsDetailsView_AfterCreatingNewItemsViewModel()
        {
            var itemsViewModel = new ItemsViewModel(new FakeItemRepository());
            var expectedType = typeof( ItemDetailsViewModel );

            var currentDetails = itemsViewModel.CurrentDetailsViewModel;

            Assert.IsAssignableFrom( expectedType, currentDetails );
        }

        [Test]
        public void AllItems_ReturnsFilteredItemView_AfterSettingFilterWithIdString()
        {
            var fakeRepo = new FakeItemRepository();
            fakeRepo.AddFake( new Item( 501, "Red Potion") );
            fakeRepo.AddFake( new Item( 502, "Orange Potion") );
            fakeRepo.AddFake( new Item( 503, "Yellow Potion") );
            fakeRepo.AddFake( new Item( 511, "Green Herb" ) );
            fakeRepo.AddFake( new Item( 512, "Apple") );
            var itemsViewModel = new ItemsViewModel( fakeRepo );
            var expectedCount = 3;
            itemsViewModel.SearchInput = "50";

            var filteredItemsCount = itemsViewModel.Items.Cast<object>().Count();

            Assert.AreEqual( expectedCount, filteredItemsCount );
        }

        [Test]
        public void AllItems_ReturnsFilteredItemView_AfterSettingFilterWithNameString()
        {
            var fakeRepo = new FakeItemRepository();
            fakeRepo.AddFake( new Item( 501, "Red Potion" ) );
            fakeRepo.AddFake( new Item( 502, "Orange Potion" ) );
            fakeRepo.AddFake( new Item( 503, "Yellow Potion" ) );
            fakeRepo.AddFake( new Item( 507, "Red Herb" ) );
            fakeRepo.AddFake( new Item( 512, "Apple" ) );
            var itemsViewModel = new ItemsViewModel( fakeRepo );
            var expectedCount = 2;
            itemsViewModel.SearchInput = "Red";

            var filteredItemsCount = itemsViewModel.Items.Cast<object>().Count();

            Assert.AreEqual( expectedCount, filteredItemsCount );
        }

        [Test]
        public void SearchIsActive_ReturnsTrue_AfterAssigningAStringToSearchInputOnViewModelWithoutItems()
        {
            var itemsViewModel = new ItemsViewModel( new FakeItemRepository() );
            var expected = true;

            itemsViewModel.SearchInput = "123";
            var actual = itemsViewModel.SearchIsActive;

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SearchIsActive_ReturnsTrue_AfterAssigningAStringToSearchInputOnViewModelWithItems()
        {
            var fakeRepo = new FakeItemRepository();
            fakeRepo.AddFake( new Item( 501, "Red Potion" ) );
            fakeRepo.AddFake( new Item( 502, "Orange Potion" ) );
            fakeRepo.AddFake( new Item( 503, "Yellow Potion" ) );
            fakeRepo.AddFake( new Item( 507, "Red Herb" ) );
            fakeRepo.AddFake( new Item( 512, "Apple" ) );
            var itemsViewModel = new ItemsViewModel( fakeRepo );
            var expected = true;

            itemsViewModel.SearchInput = "123";
            var actual = itemsViewModel.SearchIsActive;

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SearchIsActive_ReturnsFalse_OnViewModelWithoutItemsWithoutAssigningSearchInput()
        {
            var itemsViewModel = new ItemsViewModel( new FakeItemRepository() );
            var expected = false;

            var actual = itemsViewModel.SearchIsActive;

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void SearchIsActive_ReturnsFalse_OnViewModelWithItemsWithoutAssigningSearchInput()
        {
            var fakeRepo = new FakeItemRepository();
            fakeRepo.AddFake( new Item( 501, "Red Potion" ) );
            fakeRepo.AddFake( new Item( 502, "Orange Potion" ) );
            fakeRepo.AddFake( new Item( 503, "Yellow Potion" ) );
            fakeRepo.AddFake( new Item( 507, "Red Herb" ) );
            fakeRepo.AddFake( new Item( 512, "Apple" ) );
            var itemsViewModel = new ItemsViewModel( fakeRepo );
            var expected = false;

            var actual = itemsViewModel.SearchIsActive;

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void OnSortByListHeader_ReturnsSortedListByNameAscending_SortingByName()
        {
            var fakeRepo = new FakeItemRepository();
            fakeRepo.AddFake( new Item( 501, "Red Potion" ) );
            fakeRepo.AddFake( new Item( 502, "Orange Potion" ) );
            fakeRepo.AddFake( new Item( 503, "Yellow Potion" ) );
            fakeRepo.AddFake( new Item( 507, "Red Herb" ) );
            fakeRepo.AddFake( new Item( 512, "Apple" ) );
            var itemsViewModel = new ItemsViewModel( fakeRepo );

            itemsViewModel.ItemListHeaderClickCommand.Execute("Name");
            itemsViewModel.Items.MoveCurrentToFirst();
            var firstItem = (Item)itemsViewModel.Items.CurrentItem;
            itemsViewModel.Items.MoveCurrentToLast();
            var lastItem = (Item)itemsViewModel.Items.CurrentItem;

            Assert.AreEqual( "Apple", firstItem.Name );
            Assert.AreEqual( "Yellow Potion", lastItem.Name );
        }

        [Test]
        public void OnSortByListHeader_ReturnsSortedListByNameDescending_SortingByName()
        {
            var fakeRepo = new FakeItemRepository();
            fakeRepo.AddFake( new Item( 501, "Red Potion" ) );
            fakeRepo.AddFake( new Item( 502, "Orange Potion" ) );
            fakeRepo.AddFake( new Item( 503, "Yellow Potion" ) );
            fakeRepo.AddFake( new Item( 507, "Red Herb" ) );
            fakeRepo.AddFake( new Item( 512, "Apple" ) );
            var itemsViewModel = new ItemsViewModel( fakeRepo );

            itemsViewModel.ItemListHeaderClickCommand.Execute( "Name" );
            itemsViewModel.ItemListHeaderClickCommand.Execute( "Name" );
            itemsViewModel.Items.MoveCurrentToFirst();
            var firstItem = (Item)itemsViewModel.Items.CurrentItem;
            itemsViewModel.Items.MoveCurrentToLast();
            var lastItem = (Item)itemsViewModel.Items.CurrentItem;

            Assert.AreEqual( "Yellow Potion", firstItem.Name );
            Assert.AreEqual( "Apple", lastItem.Name );
        }

        [Test]
        public void OnSortByListHeader_ReturnsSortedListByNameAscending_SortingByID()
        {
            var fakeRepo = new FakeItemRepository();
            fakeRepo.AddFake( new Item( 1254 ) );
            fakeRepo.AddFake( new Item( 10 ) );
            fakeRepo.AddFake( new Item( 357) );
            var itemsViewModel = new ItemsViewModel( fakeRepo );

            itemsViewModel.ItemListHeaderClickCommand.Execute( "ID" );
            itemsViewModel.Items.MoveCurrentToFirst();
            var firstItem = (Item)itemsViewModel.Items.CurrentItem;
            itemsViewModel.Items.MoveCurrentToLast();
            var lastItem = (Item)itemsViewModel.Items.CurrentItem;

            Assert.AreEqual( 10, firstItem.ID );
            Assert.AreEqual( 1254, lastItem.ID );
        }
    }
}
