using System;
using FluentAssertions;
using Xunit;

namespace Simpler.Net.Html.Tests
{
	public class ContentTests
	{
		[Fact]
		public void TextToHtmlParagraphs_ConvertsCorrectly()
		{
			// ARRANGE
			const String text = "a\rb\n\r\nc\r\n\n\nd";

			// ACT
			var result = text.ToHtmlParagraphs();

			// ASSERT
			result.Count.ShouldBeEquivalentTo(3);
			result[0].ToString().ShouldBeEquivalentTo("<p>a<br />b</p>");
			result[1].ToString().ShouldBeEquivalentTo("<p>c</p>");
			result[2].ToString().ShouldBeEquivalentTo("<p>d</p>");
		}
	}
}