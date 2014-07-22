using System;
using System.Diagnostics;

namespace Simpler.Net.Events.Logging
{
    /// <summary>
    /// A simple class for holding log entries.
    /// </summary>
    public class SimplerEventLogEntry
    {
        /// <summary>
        /// Severity of the event.
        /// </summary>
        public TraceLevel Severity { get; set; }

        /// <summary>
        /// Text of the log entry.
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// Date and time when the event occured (was logged).
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Additional event log data.
        /// </summary>
        public Object Data { get; set; }

        /// <summary>
        /// Parametrized constructor.
        /// </summary>
        /// <param name="severity"></param>
        /// <param name="message"></param>
        /// <param name="time"></param>
        /// <param name="data"></param>
        public SimplerEventLogEntry(
            String message = null,
            TraceLevel severity = TraceLevel.Info,
            DateTime? time = null,
            Object data = null)
        {
            Severity = severity;
            Message = message;
            Time = time.HasValue ? time.Value : DateTime.Now;
            Data = data;
        }
    }
}
