using System;

namespace Simpler.Net.Html
{
    public class SimplerHtmlTagSettings
    {
        /// <summary>
        /// Put each child element on a seperate line?
        /// </summary>
        public virtual Boolean NewLines { get; set; }

        public SimplerHtmlTagSettings(Boolean newLines = false)
        {
            NewLines = newLines;
        }
    }
}
