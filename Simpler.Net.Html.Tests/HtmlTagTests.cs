using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simpler.Net.Html.Tests
{
    [TestClass]
    public class HtmlTagTests
    {
        [TestMethod]
        public void SimpleHtmlTag_A()
        {
            // Arrange
            var input = new SimplerHtmlTag("a") {Text = "Example"}.Attr("href", "http://www.example.com");
            const string expect = "<a href=\"http://www.example.com\">Example</a>";

            // Act
            var result = input.ToString();

            // Assert
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void SimpleHtmlTag_List()
        {
            // Arrange
            var input = new SimplerHtmlTag("ul", new SimplerHtmlTagSettings(newLines:true))
                .AddChild(new SimplerHtmlTag("li") {Text = "Item1"})
                .AddChild(new SimplerHtmlTag("li") {Text = "Item2"});
            const string expect = @"<ul>
<li>Item1</li>
<li>Item2</li>
</ul>";

            // Act
            var result = input.ToString();

            // Assert
            Assert.AreEqual(expect, result);
        }
    }
}
