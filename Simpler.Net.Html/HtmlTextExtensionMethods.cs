using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;

namespace Simpler.Net.Html
{
	public static class HtmlTextExtensionMethods
	{
		/// <summary>
		/// Convert plain text into HTML paragraphs.
		/// </summary>
		/// <remarks>
		/// A single line break becomes &lt;br /&gt;, multiple line breaks in a row
		/// separate paragraphs.
		/// </remarks>
		/// <param name="text">Text to convert to HTML.</param>
		/// <returns>A list of HTML tags, one for each paragraph.</returns>
		public static IList<SimplerHtmlTag> ToHtmlParagraphs(this String text)
		{
			// Split into paragraphs
			var paras = Regex.Split(text, @"(?:\r\n|\r|\n){2,}", RegexOptions.Compiled);

			var result = new List<SimplerHtmlTag>();

			// Split each paragraph at line breaks
			foreach (var para in paras)
			{
				var tag = new SimplerHtmlTag("p");

				tag.Content.Add(
					new HtmlContentBuilder().AppendHtml(
						Regex.Replace(para, @"(?:\r\n|\r|\n)", "<br />")
					)
				);

				result.Add(tag);
			}

			return result;
		}
	}
}