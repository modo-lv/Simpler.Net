using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Simpler.Net.Events.Logging
{
    /// <summary>
    /// Interface for a simple event logger implementation
    /// </summary>
    public interface ISimplerEventLogger
    {
        /// <summary>
        /// List of log entries.
        /// </summary>
        IList<SimplerEventLogEntry> Entries { get; set; }
            
        /// <summary>
        /// Add a new entry to the event log and return it.
        /// </summary>
        /// <param name="message">Entry message.</param>
        /// <param name="severity">Entry severity.</param>
        /// <param name="time">Date and time when the event was logged.</param>
        /// <param name="data">Additional data.</param>
        /// <returns>Newly created event log.</returns>
        SimplerEventLogEntry AddNewEntry(String message = null, TraceLevel severity = TraceLevel.Info,
            DateTime time = default(DateTime), Object data = null);

        /// <summary>
        /// Add a prepared log entry.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        SimplerEventLogEntry AddNewEntry(SimplerEventLogEntry entry);

        /// <summary>
        /// Add a new entry with Error severity to the event log and return it.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="time">Date and time when the error occured.</param>
        /// <param name="data">Additional data.</param>
        /// <returns>Newly created error log entry.</returns>
        SimplerEventLogEntry AddNewError(String message = null, DateTime time = default(DateTime), Object data = null);

        /// <summary>
        /// Add a new entry with Informational severity to the event log and return it.
        /// </summary>
        /// <param name="message">Information message.</param>
        /// <param name="time">Date and time when the event occured.</param>
        /// <param name="data">Additional data.</param>
        /// <returns>Newly created info log entry.</returns>
        SimplerEventLogEntry AddNewInfo(String message = null, DateTime time = default(DateTime), Object data = null);
   }
}
