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
            Assert.AreEqual( input, result[0].Item1 );
            Assert.AreEqual( expectedBrush, result[0].Item2 );
        }

        [Test]
        public void Parse_ReturnsFullStringWithRedBrush_OnStringWithRedHexCodeAtTheStart()
        {
            var input = "^ff0000Some text about stuff";
            var expectedText = "Some text about stuff";
            var expectedCount = 1;
            var expectedBrush = (Brush)Brushes.Red;

            var result = ColoredStringParser.Parse( input );

            Assert.AreEqual( expectedCount, result.Count );
            Assert.AreEqual( expectedText, result[0].Item1 );
            Assert.AreEqual( expectedBrush.ToString(), result[0].Item2.ToString() );
        }

        [Test]
        public void Parse_ReturnsMultipleStringsWithCorrectBrush_OnStringWithMultipleHexCodes()
        {
            var input = "^FF0000Some text about stuff ^008000and different color in the second half";
            var expectedText1 = "Some text about stuff ";
            var expectedBrush1 = (Brush)Brushes.Red;
            var expectedText2 = "and different color in the second half";
            var expectedBrush2 = (Brush)Brushes.Green;
            var expectedCount = 2;

            var result = ColoredStringParser.Parse( input );

            Assert.AreEqual( expectedCount, result.Count );
            Assert.AreEqual( expectedText1, result[0].Item1 );
            Assert.AreEqual( expectedBrush1.ToString(), result[0].Item2.ToString() );
            Assert.AreEqual( expectedText2, result[1].Item1 );
            Assert.AreEqual( expectedBrush2.ToString(), result[1].Item2.ToString() );
        }

        [Test]
        public void Parse_ReturnsMultipleStringsWithCorrectBrush_OnStringWithRedHexCodeInTheMiddle()
        {
            var input = "Some text with a ^FF0000different color in the second half";
            var expectedText1 = "Some text with a ";
            var expectedBrush1 = (Brush)Brushes.Black;
            var expectedText2 = "different color in the second half";
            var expectedBrush2 = (Brush)Brushes.Red;
            var expectedCount = 2;

            var result = ColoredStringParser.Parse( input );

            Assert.AreEqual( expectedCount, result.Count );
            Assert.AreEqual( expectedText1, result[0].Item1 );
            Assert.AreEqual( expectedBrush1.ToString(), result[0].Item2.ToString() );
            Assert.AreEqual( expectedText2, result[1].Item1 );
            Assert.AreEqual( expectedBrush2.ToString(), result[1].Item2.ToString() );
        }
    }
}
