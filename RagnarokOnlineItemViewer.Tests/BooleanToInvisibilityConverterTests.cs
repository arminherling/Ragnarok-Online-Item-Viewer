using NUnit.Framework;
using RagnarokOnlineItemViewer.Converters;
using System.Windows;

namespace RagnarokOnlineItemViewer.Tests
{
    [TestFixture]
    class BooleanToInvisibilityConverterTests
    {
        [Test]
        public void Convert_ReturnsVisible_WhenPassingInFalse()
        {
            var converter = new BooleanToInvisibilityConverter();
            var expected = Visibility.Visible;

            var actual = converter.Convert( false, typeof( Visibility ), null, null );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void Convert_ReturnsCollapsed_WhenPassingInTrue()
        {
            var converter = new BooleanToInvisibilityConverter();
            var expected = Visibility.Collapsed;

            var actual = converter.Convert( true, typeof( Visibility ), null, null );

            Assert.AreEqual( expected, actual );
        }
    }
}
