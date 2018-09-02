using NUnit.Framework;
using RagnarokOnlineItemViewer.Models;
using RagnarokOnlineItemViewer.ViewModels;
namespace RagnarokOnlineItemViewer.Tests
{
    [TestFixture]
    public class ItemDetailsViewModelTests
    {
        [Test]
        public void AllProperties_ReturnEmptyStrings_BeforePassingAnItemIntoTheViewModel()
        {
            var viewModel = new ItemDetailsViewModel();

            var number = viewModel.ID;
            var name = viewModel.Name;
            var description = viewModel.Description;

            Assert.IsEmpty( number );
            Assert.IsEmpty( name );
            Assert.IsEmpty( description );
        }

        [Test]
        public void IDProperty_ReturnsModelsID_AfterPassingAnItemIntoTheViewModel()
        {
            var expectedNumber = 123;
            var viewModel = new ItemDetailsViewModel();
            viewModel.SetItem( new Item( id: expectedNumber ) );

            var number = viewModel.ID;

            Assert.AreEqual( expectedNumber.ToString(), number );
        }

        [Test]
        public void NameProperty_ReturnsModelsName_AfterPassingAnItemIntoTheViewModel()
        {
            var expectedName = "John";
            var viewModel = new ItemDetailsViewModel();
            viewModel.SetItem( new Item( name: expectedName ) );

            var name = viewModel.Name;

            Assert.AreEqual( expectedName, name );
        }

        [Test]
        public void DescriptionProperty_ReturnsModelsName_AfterPassingAnItemIntoTheViewModel()
        {
            var expectedDescription = "Some long description .......................";
            var viewModel = new ItemDetailsViewModel();
            viewModel.SetItem( new Item( description: expectedDescription ) );

            var description = viewModel.Description;

            Assert.AreEqual( expectedDescription, description );
        }

        [Test]
        public void ItemProperties_ReturnPreviousSetItem_AfterPassinInNull()
        {
            var expectedItem = new Item(
                id: 610,
                name: "Yggdrasil Leaf",
                description: "Leaf from the Yggdrasil tree which maintains the mortal coil. It can bring life to fallen characters." );
            var viewModel = new ItemDetailsViewModel();
            viewModel.SetItem( expectedItem );

            viewModel.SetItem( null );

            Assert.AreEqual( expectedItem.ID.ToString(), viewModel.ID );
            Assert.AreEqual( expectedItem.Name, viewModel.Name );
            Assert.AreEqual( expectedItem.Description, viewModel.Description );
        }
    }
}
