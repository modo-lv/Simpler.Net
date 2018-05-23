using FluentAssertions;
using Xunit;

namespace Simpler.Net.Html.Tests
{
	public class TagAttributeTests
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
			result.ShouldBeEquivalentTo("<input disabled />");
		}
	}
}