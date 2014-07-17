using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simpler.Net.FileSystem.Tests
{
    [TestClass]
    public class PathTests
    {
        protected String Input = @"\\\C:\\\Folder1/folder2\FOLDER3//someFile.txt\\\";

        [TestMethod]
        public void Path_Trim_BasicFunctionality()
        {
            // Arrange
            const String expectation = @"C:\\\Folder1/folder2\FOLDER3//someFile.txt";

            // Act
            var result = SimplerPath.Trim(Input);

            // Assert
            Assert.AreEqual(expectation, result);
        }

        [TestMethod]
        public void Path_Combine_BasicFunctionality()
        {
            // Arrange
            const string expectation = @"C:\folder1\folder2\folder3\someFile.txt";

            // Act
            var result = SimplerPath.Combine("nonFolder", @"C:\folder1\\\", @"\folder2", "folder3", "someFile.txt");

            // Assert
            Assert.AreEqual(expectation, result);
        }

        [TestMethod]
        public void Path_Split_BasicFunctionality()
        {
            // Arrange
            var expectation = new[]
            {
                "C:", "Folder1", "folder2", "FOLDER3", "someFile.txt"
            };

            // Act
            var result = SimplerPath.Split(Input);

            // Assert
            for (var a = 0; a < result.Count; a++)
                Assert.AreEqual(expectation[a], result[a], "Element {0}", a);
        }

        [TestMethod]
        public void Path_Clean_BasicFunctionality()
        {
            // Arrange
            const String expected = @"C:\Folder1/folder2\FOLDER3/someFile.txt";

            // Act
            var result = SimplerPath.Clean(Input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
