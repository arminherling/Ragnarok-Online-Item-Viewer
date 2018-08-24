using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RagnarokOnlineItemViewer.Tests
{
    [TestFixture]
    public class ColoredStringParserTests
    {
        [Test]
        public void Parse_ReturnsEmptyList_OnEmptyString()
        {
            var expected = new List<(string, Brush)>();

            var actual = ColoredStringParser.Parse( "" );

            Assert.AreEqual( expected, actual );
        }

        [Test]
        public void Parse_ReturnsFullStringWithBlackBrush_OnStringWithoutHexColors()
        {
            var input = "Some multi line\nstring without color data";
            var expectedCount = 1;
            var expectedBrush = Brushes.Black;

            var result = ColoredStringParser.Parse( input );

            Assert.AreEqual( expectedCount, result.Count );
            Assert.AreEqual( result[0].Item1, input );
            Assert.AreEqual( result[0].Item2, expectedBrush );
        }
    }
}
