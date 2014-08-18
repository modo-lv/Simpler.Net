using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simpler.Net.Text
{
    /// <summary>
    /// Class for padding strings.
    /// </summary>
    public class SimplerTextPadder
    {
        /// <summary>
        /// Text to pad.
        /// </summary>
        public virtual string Text { get; set; }

        public virtual String PadWith { get; set; }

        /// <summary>
        /// How to align the text within the new padded string.
        /// </summary>
        public virtual SimplerTextAlignment TextAlignment { get; set; }

        /// <summary>
        /// Which side to pad on. "Center" means "both".
        /// </summary>
        public virtual SimplerTextAlignment PaddingAlignment { get; set; }

        /// <summary>
        /// How wide should the result be (including padding).
        /// </summary>
        public virtual Int32 Length { get; set; }

        public SimplerTextPadder()
        {
            PadWith = " ";
        }

        public SimplerTextPadder(String text, String padWith = null) : this()
        {
            Text = text;
            if (padWith != null)
                PadWith = padWith;
        }

        /// <summary>
        /// Get the text padded.
        /// </summary>
        /// <returns></returns>
        public virtual String GetPadded()
        {
            var paddingLength = Length - Text.Length;

            var padLeft = TextAlignment == SimplerTextAlignment.Left ? 0 : paddingLength;
            var padRight = TextAlignment == SimplerTextAlignment.Right ? 0 : paddingLength;

            if (TextAlignment == SimplerTextAlignment.Center)
            {
                padLeft = (int)Math.Floor((Double)padLeft / 2);
                padRight = (int)Math.Ceiling((Double)padRight / 2);
            }

            return PadWith.Repeat(padLeft) + Text + PadWith.Repeat(padRight);
        }

        #region Backing fields

        #endregion

    }
}