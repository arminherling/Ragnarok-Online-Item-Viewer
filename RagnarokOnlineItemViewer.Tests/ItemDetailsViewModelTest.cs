using NUnit.Framework;
using RagnarokOnlineItemViewer.Models;
using RagnarokOnlineItemViewer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnarokOnlineItemViewer.Tests
{
    [TestFixture]
    public class ItemDetailsViewModelTest
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
    }
}
