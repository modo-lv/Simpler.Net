using System;
using System.Globalization;
using FluentAssertions;
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
			result.ShouldBeEquivalentTo(expect);
		}

		[Fact]
		public void FractionalTimestampConvertedCorrectly()
		{
			// ARRANGE
			const Decimal input = 0.12M;
			DateTime expected = SimplerTime.UnixEpochStart.AddSeconds(0.12);

			// ACT
			DateTime time = input.ToDateTime();

			// ASSERT
			time.ShouldBeEquivalentTo(expected);
		}
	}
}