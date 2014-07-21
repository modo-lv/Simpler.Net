using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Simpler.Net.Events.Logging
{
    /// <summary>
    /// A simple in-memory event logger.
    /// </summary>
    public class SimplerEventLogger : ISimplerEventLogger
    {
        public IList<SimplerEventLogEntry> Entries { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SimplerEventLogger()
        {
            Entries = new List<SimplerEventLogEntry>();
        }

        public virtual SimplerEventLogEntry AddNewEntry(string message = null, TraceLevel severity = TraceLevel.Info,
            DateTime time = new DateTime(), object data = null)
        {
            return AddNewEntry(new SimplerEventLogEntry(message: message, severity: severity, time: time, data: data));
        }

        public virtual SimplerEventLogEntry AddNewEntry(SimplerEventLogEntry entry)
        {
            Entries.Add(entry);
            return entry;
        }

        public virtual SimplerEventLogEntry AddNewError(string message = null, DateTime time = new DateTime(), object data = null)
        {
            return AddNewEntry(message: message, severity: TraceLevel.Error, time: time, data: data);
        }

        public virtual SimplerEventLogEntry AddNewInfo(string message = null, DateTime time = new DateTime(), object data = null)
        {
            return AddNewEntry(message: message, severity: TraceLevel.Info, time: time, data: data);
        }
    }
}