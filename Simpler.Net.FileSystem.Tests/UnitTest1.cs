using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simpler.Net.FileSystem.Tests
{
    [TestClass]
    public class PathTests
    {
        [TestMethod]
        public void Path_Combine_BasicFunctionality()
        {
            // Arrange
            const string expectation = @"C:\folder1\folder2\folder3\someFile.txt";

            // Act
            var result = SimplerPath.Combine("nonFolder", @"C:\folder1\\\", @"\folder2", "folder3", "someFile.txt");

            // Assert
            Assert.AreEqual(expectation.ToLowerInvariant(), result.ToLowerInvariant());
        }
    }
}
