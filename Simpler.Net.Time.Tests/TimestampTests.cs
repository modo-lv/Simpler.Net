using System;
using System.Globalization;
using Shouldly;
using Xunit;

namespace Simpler.Net.Time.Tests {
	[Trait("Category", "Time")]
	public class TimestampTests
	{
		[Fact]
		public void LocalDateTimeReturnsUtcTimestamp()
		{
			// ARRANGE
			var input = DateTime.Now;
			var expect = DateTime.UtcNow.DropMilliseconds();

			// ACT
			var stamp = input.ToUnixTimeStamp<Int64>();
			DateTime result = SimplerTime.UnixEpochStart.AddSeconds(stamp);

			// ASSERT
			result.ShouldBe(expect);
		}
	}
}