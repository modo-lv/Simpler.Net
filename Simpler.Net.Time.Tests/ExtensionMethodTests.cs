using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simpler.Net.Time.Tests
{
	[TestClass]
	public class ExtensionMethodTests
	{
		[TestMethod]
		public void ToUnixTimestampInt32_ConvertsCorrectly()
		{
			// ARRANGE
			var dt = new DateTime(2016, 01, 01, 01, 01, 01);
			
			// ACT
			var result = dt.ToUnixTimestampInt32();

			// ASSERT
			const Int32 expect = 1451610061;
			Assert.AreEqual(expect, result);
		}
	}
}
