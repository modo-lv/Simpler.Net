using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simpler.Net.Text.Tests
{
    [TestClass]
    public class WrapTests
    {
        [TestMethod]
        public void Simple_Line_Wraps_Correctly()
        {
            // Arrange
            var wrap = new SimplerTextWrapper(
                content: "This line should split before 'split'.",
                width: 20);
            var expect = new List<String> {@"This line should", @"split before 'split'."};

            // Act
            var result = wrap.GetWrappedLines();

            // Assert
            Assert.AreEqual(expect.ToList()[0], result.ToList()[0]);
            Assert.AreEqual(expect.ToList()[1], result.ToList()[1]);
        }

        [TestMethod]
        public void MultiLine_Wraps_Correctly()
        {
            // Arrange
            var wrap = new SimplerTextWrapper(
                content: @"Result should be
three lines.",
                width: 15);
            const string expect = @"Result should
be
three lines.";

            // Act
            var result = wrap.GetWrappedText();

            // Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void FullLength_DoesntWrap()
        {
            // Arrange
            const Int32 length = 80;
            var input = '-'.Repeat(length) + Environment.NewLine + '-'.Repeat(length);
            var expect = input;

            // Act
            var result = new SimplerTextWrapper(input, input.Length).GetWrappedText();

            // Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void SpacePaddedLines_WrapCorrectly()
        {
            // Arrange
            var input = @" Line1

 Line2";
            var expect = input;

            // Art
            var result = new SimplerTextWrapper(input, 6).GetWrappedText();

            // Assert
            Assert.AreEqual(expect, result);
        }
    }
}
    