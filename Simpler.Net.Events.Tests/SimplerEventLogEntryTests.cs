using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simpler.Net.Events.Logging;

namespace Simpler.Net.Events.Tests
{
    [TestClass]
    public class SimplerEventLogEntryTests
    {
        [TestMethod]
        public void SimplerEventLogEntry_DefaultTimeIsNow()
        {
            // Act
            var result = new SimplerEventLogEntry();

            // Assert
            Assert.AreNotEqual(default(DateTime), result.Time);
            Assert.AreEqual(DateTime.Now.Day, result.Time.Day);
        }
    }
}
