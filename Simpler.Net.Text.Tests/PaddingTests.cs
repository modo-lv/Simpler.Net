using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simpler.Net.Text.Tests
{
    [TestClass]
    public class PaddingTests
    {
        [TestMethod]
        public void BasicPadding()
        {
            // Arrange
            const String input = "ABC DEF";
            const String pad = "-";
            const Int32 length = 10;
            var expect = new[] {"ABC DEF---", "---ABC DEF", "-ABC DEF--"};

            // Act
            var result = new[]
            {
                new SimplerTextPadder(input, pad) {Length = length, TextAlignment = SimplerTextAlignment.Left}
                    .GetPadded(),
                new SimplerTextPadder(input, pad) {Length = length, TextAlignment = SimplerTextAlignment.Right}
                    .GetPadded(),
                new SimplerTextPadder(input, pad) {Length = length, TextAlignment = SimplerTextAlignment.Center}
                    .GetPadded(),
            };

            // Assert
            for (var a = 0; a < expect.Length; a++)
                Assert.AreEqual(expect[a], result[a]);
        }
    }
}
