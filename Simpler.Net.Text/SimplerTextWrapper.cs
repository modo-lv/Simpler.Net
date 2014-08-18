using System;
using System.Collections.Generic;
using System.Text;

namespace Simpler.Net.Text
{
    /// <summary>
    /// An object for word-wrapping a plain, monospaced text to a given length.
    /// </summary>
    public class SimplerTextWrapper
    {
        /// <summary>
        /// Text content to work with.
        /// </summary>
        public virtual String Content { get; set; }

        /// <summary>
        /// Maximum line width, in characters.
        /// </summary>
        public virtual Int32 Width { get; set; }

        public SimplerTextWrapper(string content, Int32? width = null)
        {
            Content = content;
            if (width.HasValue)
                Width = width.Value;
        }

        /// <summary>
        /// Get the content as word-wrapped text, each line as a separate string.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<String> GetWrappedLines()
        {
            var lines = Content.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);

            foreach (var rawLine in lines)
            {
                var line = new StringBuilder();
                var word = new StringBuilder();
                for (var a = 0; a < rawLine.Length; a++)
                {
                    var chr = rawLine[a];
                    var length = a % Width;

                    if (chr == ' ' || (a > 0 && length == 0))
                    {
                        // Check if the line ends
                        if (a > 0 && length == 0)
                        {
                            yield return line.ToString();
                            line = new StringBuilder(word.ToString().TrimStart(' '));
                            word = new StringBuilder();
                        }
                        else
                        {
                            line.Append(word);
                            word = new StringBuilder(chr.ToString());
                            continue;
                        }
                    }

                    word.Append(chr);
                }
                line.Append(word);
                yield return line.ToString();
            }
        }

        /// <summary>
        /// Get the content as word-wrapped text.
        /// </summary>
        /// <returns></returns>
        public virtual String GetWrappedText()
        {
            var lines = GetWrappedLines();
            return String.Join(Environment.NewLine, lines);
        }
    }
}