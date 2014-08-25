using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Simpler.Net.Html
{
    /// <summary>
    /// HTML tag.
    /// </summary>
    public class SimplerHtmlTag {
        /// <summary>
        /// Tag name.
        /// </summary>
        public virtual String TagName { get; set; }

        /// <summary>
        /// Textual content of the tag. Will be ignored in output if <see cref="Children"/>
        /// has any elements.
        /// </summary>
        public virtual String Text { get; set; }

        public virtual SimplerHtmlTagSettings Settings { get; set; }

        /// <summary>
        /// Child elements.
        /// </summary>
        public virtual IList<SimplerHtmlTag> Children { get; set; }

        /// <summary>
        /// HTML attributes.
        /// </summary>
        public virtual IDictionary<string, object> Attrs { get; set; } 

        public SimplerHtmlTag(String tagName, SimplerHtmlTagSettings settings = null)
        {
            TagName = tagName;
            Children = new List<SimplerHtmlTag>();
            Attrs = new Dictionary<string, object>();
            Settings = settings ?? new SimplerHtmlTagSettings();
        }

        /// <summary>
        /// Add an attribute / set an attribute's value.
        /// </summary>
        /// <param name="name">Name of the attribute.</param>
        /// <param name="value">Value of the attribute.</param>
        /// <returns></returns>
        public SimplerHtmlTag Attr(String name, String value)
        {
            Attrs[name] = value;
            return this;
        }

        /// <summary>
        /// Add an HTML tag as a child of this tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public SimplerHtmlTag AddChild(SimplerHtmlTag tag)
        {
            Children.Add(tag);
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append('<').Append(TagName);
            foreach (var attr in Attrs) {
                sb.Append(' ').Append(attr.Key);
                if (attr.Value != null && !(attr.Value is Boolean))
                    sb.Append("=\"").Append(attr.Value).Append("\"");
            }

            sb.Append('>');

            if (Children.Any()) {
                foreach (var child in Children) {
                    if (Settings.NewLines)
                        sb.AppendLine();
                    sb.Append(child);
                }
                if (Settings.NewLines)
                    sb.AppendLine();
            } else {
                sb.Append(HttpUtility.HtmlEncode(Text));
            }

            sb.Append("</").Append(TagName).Append('>');
            return sb.ToString();
        }
    }
}
