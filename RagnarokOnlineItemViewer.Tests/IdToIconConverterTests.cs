using NUnit.Framework;
using RagnarokOnlineItemViewer.Converters;
using System;

namespace RagnarokOnlineItemViewer.Tests
{
    [TestFixture]
    public class IdToIconConverterTests
    {
        [Test]
        public void IdToIconConverter_ReturnsIconForId_OnIdWithIconImageAndValidParameter()
        {
            var converter = new IdToIconConverter();
            var expected1 = "\\Data\\501.gif";
            var expected2 = "\\Data\\7897.gif";

            var actualPath1 = (string)converter.Convert( "501", null, "Data|.gif", null );
            var actualPath2 = (string)converter.Convert( "7897", null, "Data|.gif", null );

            Assert.IsTrue( actualPath1.EndsWith( expected1 ) );
            Assert.IsTrue( actualPath2.EndsWith( expected2 ) );
        }

        [Test]
        public void IdToIconConverter_ReturnsNull_OnIdWithIconImageButInvalidParameter()
        {
            var converter = new IdToIconConverter();

            var result = converter.Convert( "501", null, "InvalidFolder|.xyz", null );

            Assert.IsNull( result );
        }

        [Test]
        public void IdToIconConverter_ReturnsNull_OnIdWithoutIconImage()
        {
            var converter = new IdToIconConverter();

            var result = converter.Convert( "123456", null, "Data|.gif", null );

            Assert.IsNull( result );
        }

        [Test]
        public void IdToIconConverter_ThrowsException_OnIdWithIconImageButNullParameter()
        {
            var converter = new IdToIconConverter();

            Assert.Throws<ArgumentNullException>( () => { converter.Convert( "501", null, null, null ); } );
        }

        [Test]
        public void IdToIconConverter_ThrowsException_OnNullValue()
        {
            var converter = new IdToIconConverter();

            Assert.Throws<ArgumentNullException>( () => { converter.Convert( null, null, "Data|.gif", null ); } );
        }
    }
}
