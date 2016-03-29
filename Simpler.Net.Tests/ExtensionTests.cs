using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simpler.Net.Tests
{
	[TestClass]
	public class ExtensionTests
	{
		[TestMethod]
		public void Extension_IfNotNull_CallsMethodIfNotNull()
		{
			// ARRANGE
			var obj = new Object();
			var expect = obj.ToString();

			// ACT
			var result = obj.IfNotNull(o => o.ToString());

			// ASSERT
			Assert.AreEqual(expect, result);
		}

		[TestMethod]
		public void Extension_IfNotNull_ReturnsFallbackValueIfNull()
		{
			// ARRANGE
			Object obj = null;
			const String expect = "Fallback value";

			// ACT
			// ReSharper disable once ExpressionIsAlwaysNull
			var result = obj.IfNotNull(o => o.ToString(), otherwise:expect);

			// ASSERT
			Assert.AreEqual(expect, result);
		}
	}
}
