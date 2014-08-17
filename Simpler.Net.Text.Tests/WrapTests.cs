﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simpler.Net.Text.Tests
{
    [TestClass]
    public class WrapTests
    {
        [TestMethod]
        public void Simple_Line_Wraps_Correctly()
        {
            // Arrange
            var wrap = new SimplerTextWrapper(
                content: "This line should split before 'split'.",
                width: 20);
            var expect = new List<String> {@"This line should", @"split before 'split'."};

            // Act
            var result = wrap.GetWrapped();

            // Assert
            Assert.AreEqual(expect.ToList()[0], result.ToList()[0]);
            Assert.AreEqual(expect.ToList()[1], result.ToList()[1]);
        }
    }
}
    