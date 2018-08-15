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
    public class ItemDetailsViewModelTest
    {
        [Test]
        public void AllProperties_ReturnEmptyStrings_BeforePassingAnItemIntoTheViewModel()
        {
            var viewModel = new ItemDetailsViewModel();

            var number = viewModel.Number;
            var name = viewModel.Name;
            var description = viewModel.Description;

            Assert.IsEmpty( number );
            Assert.IsEmpty( name );
            Assert.IsEmpty( description );
        }
    }
}
