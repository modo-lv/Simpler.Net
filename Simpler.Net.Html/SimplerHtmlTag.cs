using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

namespace Simpler.Net.Html
{
	/// <summary>
	/// A class for manipulating HTML tags.
	/// </summary>
	public class SimplerHtmlTag : IHtmlContent
	{
		/// <summary>
		/// List of tags that do not have a closing tag.
		/// </summary>
		public static readonly String[] VoidTags =
		{
			"area",
			"base",
			"br",
			"col",
			"command",
			"embed",
			"hr",
			"img",
			"input",
			"keygen",
			"link",
			"meta",
			"param",
			"source",
			"track",
			"wbr",
		};

		
		private String _tagName;

		
		/// <summary>
		/// Is the this tag void (has no closing tag)?
		/// </summary>
		public Boolean IsVoid { get; private set; }

		/// <summary>
		/// Name of the tag (not to be confused with "name" attribute).
		/// </summary>
		public String TagName
		{
			get => this._tagName;
			set
			{
				this._tagName = value;
				this.IsVoid = VoidTags.Contains(value);
			}
		}

		/// <summary>
		/// All HTML attributes of the tag.
		/// </summary>
		protected IDictionary<String, String> Attributes;

		/// <summary>
		/// Content of the tag, if the tag is not void.
		/// </summary>
		/// <remarks>
		/// <see cref="IHtmlContent"/> objects will be rendered as HTML (without escaping),
		/// everything else will be <see cref="object.ToString"/>-ed and HTML-escaped.
		/// </remarks>
		public IList<Object> Content;

		protected ISet<String> Classes;


		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="tagName"></param>
		public SimplerHtmlTag(String tagName)
		{
			this.TagName = tagName;
			this.Attributes = new Dictionary<String, String>();
			this.Classes = new HashSet<String>();
		}
		
		/// <summary>
		/// Set several attributes at once. Existing attributes values with matching keys will be overwritten.
		/// </summary>
		/// <param name="attributes"></param>
		/// <returns></returns>
		public SimplerHtmlTag SetAttributes(IDictionary<String, String> attributes)
		{
			foreach (var kv in attributes)
				this.Attributes[kv.Key] = kv.Value;
			return this;
		}

		/// <summary>
		/// Set several no-value attributes (such as "readonly") at once.
		/// </summary>
		/// <param name="attributes"></param>
		/// <returns></returns>
		public SimplerHtmlTag SetAttributes(params String[] attributes)
		{
			foreach (var attr in attributes)
				this.Attributes[attr] = null;
			return this;
		}

		/// <summary>
		/// Add/overwrite a single attribute.
		/// </summary>
		/// <param name="key">Attribute key.</param>
		/// <param name="value">Attribute value.</param>
		/// <returns></returns>
		public SimplerHtmlTag SetAttribute(String key, String value)
		{
			this.Attributes[key] = value;
			return this;
		}


		/// <summary>
		/// Set a value-less attribute, e.g. "readonly", "disabled".
		/// </summary>
		/// <param name="key">Attribute key.</param>
		/// <returns>Self for method chaining.</returns>
		public SimplerHtmlTag SetAttribute(String key)
		{
			this.Attributes[key] = null;
			return this;
		}

		/// <summary>
		/// Remove an attribute from this tag.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public SimplerHtmlTag RemoveAttribute(String key)
		{
			this.Attributes.Remove(key);
			return this;
		}

		/// <summary>
		/// Add a CSS class to the tag.
		/// </summary>
		/// <remarks>
		/// If the tag already has the class, will not add it again.
		/// </remarks>
		/// <param name="className">Name of the CSS class to add.</param>
		/// <returns>Self for method chaining.</returns>
		public SimplerHtmlTag AddClass(String className)
		{
			this.Classes.Add(className);
			return this;
		}

		/// <summary>
		/// Remove a CSS class from this tag.
		/// </summary>
		/// <remarks>
		/// Removes a CSS class from the list of CSS classes applied to this tag, if it contains it.
		/// </remarks>
		/// <param name="className">CSS class to remove.</param>
		/// <returns>Self for method chaining.</returns>
		public SimplerHtmlTag RemoveClass(String className)
		{
			this.Classes.Remove(className);
			return this;
		}

		/// <summary>
		/// See <see cref="IHtmlContent.WriteTo"/>.
		/// </summary>
		public void WriteTo(TextWriter writer, HtmlEncoder encoder)
		{
			IHtmlContentBuilder tag = new HtmlContentBuilder()
				.AppendHtml($"<{this.TagName}");

			// Regular attributes
			foreach (var attr in this.Attributes)
			{
				// Any CSS classes added by AddClass() override direct attribute
				if (attr.Key == "class" && this.Classes.Any())
					continue;

				tag.AppendHtml($" {attr.Key}");

				if (attr.Value != null)
					tag.AppendHtml("=\"").Append(attr.Value).AppendHtml("\"");
			}

			// CSS classes
			if (this.Classes.Any())
			{
				tag.AppendHtml(" class=\"")
					.Append(String.Join(" ", this.Classes))
					.AppendHtml("\"");
			}

			// Finish opening tag...
			tag.AppendHtml(this.IsVoid ? " />" : ">");
			tag.WriteTo(writer, encoder);
			// ...and any voids
			if (this.IsVoid)
				return;

			// Non-void tags
			foreach (Object item in this.Content)
			{
				// ReSharper disable once SuggestVarOrType_SimpleTypes
				var content = item as IHtmlContent
					?? new HtmlContentBuilder().Append(item.ToString());
				content.WriteTo(writer, encoder);
			}

			tag = new HtmlContentBuilder()
				.AppendHtml($"</{this.TagName}>");

			tag.WriteTo(writer, encoder);
		}

		/// <summary>
		/// Output the HTML code of the tag.
		/// </summary>
		public override String ToString() { return this.ToString(HtmlEncoder.Default); }

		/// <summary>
		/// Pass the tag through an HTML encoder to get its string output.
		/// </summary>
		/// <param name="encoder">Encoder</param>
		/// <returns>Encoder output after processing the tag.</returns>
		public String ToString(HtmlEncoder encoder)
		{
			var writer = new StringWriter();
			this.WriteTo(writer, encoder);

			return writer.ToString();

		}
	}
}