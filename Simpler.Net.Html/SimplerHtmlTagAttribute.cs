using System;

namespace Simpler.Net.Html
{
	/// <summary>
	/// Represents an HTML tag attribute.
	/// </summary>
	public class SimplerHtmlTagAttribute
	{
		/// <summary>
		/// Attribute name.
		/// </summary>
		public virtual String Name { get; set; }

		/// <summary>
		/// Attribute value.
		/// </summary>
		public virtual String Value { get; set; }


		public SimplerHtmlTagAttribute() { }

		public SimplerHtmlTagAttribute(String name, String value)
		{
			this.Name = name;
			this.Value = value;
		}
	}
}