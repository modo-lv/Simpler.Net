using System;
using System.IO;
using System.Linq;
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
            var input = new[] {"nonFolder", @"C:\folder1\\\", @"\folder2", "folder3", "someFile.txt"};

            // Act
            var result = SimplerPath.Combine(input);

            // Assert
            Assert.AreEqual(expectation, result);
        }

        [TestMethod]
        public void Path_Combine_HandleEmptyArray()
        {
            SimplerPath.Combine(new String[0]);
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
        public void Path_Split_SingleElement()
        {
            // Arrange
            const string input = "Folder";
            var expectation = new[] {input};

            // Act
            var result = SimplerPath.Split(input);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(expectation[0], result[0]);
        }

        [TestMethod]
        public void Path_Combine_DriveLetter()
        {
            // Arrange
            const string expected = @"C:\Folder1\folder2\FOLDER3\someFile.txt";

            // Act
            var result = SimplerPath.Combine(SimplerPath.Split(Input));

            // Assert
            Assert.AreEqual(expected, result);
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

        [TestMethod]
        public void Path_SplitPathAndName_BasicFunctionality()
        {
            // Arrange
            var expected = new PathAndName(@"C:\Folder1\folder2\FOLDER3", "someFile.txt");

            // Act
            var result = SimplerPath.SplitPathAndName(Input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
