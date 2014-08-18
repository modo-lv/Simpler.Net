using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simpler.Net.Text.Tests
{
    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void StringRepeat()
        {
            // Arrange
            const String input = "AB";
            const Int32 times = 3;
            const String expect = "ABABAB";

            // Act
            var result = input.Repeat(times);

            // Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void CharRepeat()
        {
            // Arrange
            const Char input = '?';
            const Int32 times = 5;
            const String expect = "?????";

            // Act
            var result = input.Repeat(times);

            // Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void StringDuplicate()
        {
            // Arrange
            const String input = "JUG";
            const Int32 times = 2;
            var expect = new[] {"JUG", "JUG"};

            // Act
            var result = input.Duplicate(times).ToArray();

            // Assert
            Assert.AreEqual(expect.Length, result.Length);
            for (var a = 0; a < expect.Length; a++)
                Assert.AreEqual(expect[a], result[a]);
        }

        [TestMethod]
        public void StringPad()
        {
            // Arrange
            const String input = "ABC";
            const Int32 length = 5;
            var expect = new[] {"ABC  ", "  ABC", " ABC "};

            // Act
            var result = new[]
            {
                input.Pad(length, SimplerTextAlignment.Left),
                input.Pad(length, SimplerTextAlignment.Right),
                input.Pad(length, SimplerTextAlignment.Center),
            };

            for (var a = 0; a < expect.Length; a++)
                Assert.AreEqual(expect[a], result[a]);
        }
    }
}
