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
    }
}
