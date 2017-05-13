using System;
using Xunit;
using Shouldly;

namespace Simpler.Net.Html.Tests
{
    public class AttributeTests
    {
        [Fact]
				
        public void NoValueAttribute_PrintsCorrectly()
        {
					// ARRANGE
	        var tag = new SimplerHtmlTag("input")

	        .SetAttribute("disabled");

					// ACT
	        var result = tag.ToString();

	        // ASSERT
	        result.ShouldBe("<input disabled />");
        }
    }
}
