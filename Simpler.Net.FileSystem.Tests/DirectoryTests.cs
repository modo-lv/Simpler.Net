using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simpler.Net.FileSystem.Tests
{
    [TestClass]
    public class DirectoryTests
    {
        [TestMethod]
        public void Directory_GetDirectoryTree_BasicFunctionality()
        {
            // Arrange
            var input = new List<String>
            {
                @"a",
                @"a/b",
                @"a\b\c",
                @"d",
                @"a/b",
                @"e\f",
                @"e\g",
                @"e\g\h",
                @"e\g/i",
            };

            // Act
            var result = SimplerDirectory.GetDirectoryTree(input);

            // Assert
            /* Expected output:
               a
               +-b
               | +-c
               +-d
               +-e
                 +-f
                 +-g
                   +-h
                   +-i
             */

            Assert.IsNotNull(result, "No result.");
            Assert.IsNotNull(result, "No result.");
            Assert.IsFalse(result.Children.Count < 1, "Result list is empty.");
            for (var a = 0; a < result.Children.Count; a++)
            {
                var item = result.Children[a];
                switch (a)
                {
                    case 0:
                        Assert.AreEqual("a", item.Name, true);
                        break;
                    case 1:
                        Assert.AreEqual("d", item.Name, true);
                        break;
                    case 2:
                        Assert.AreEqual("e", item.Name, true);
                        break;
                }
            }
            Assert.AreSame(result, result.Children[0].Parent);
        }
    }
}
