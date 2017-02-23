using System;

namespace Simpler.Net.Time
{
	/// <summary>
	/// Miscellaneous methods to help working with dates and times.
	/// </summary>
	public static class TimeExtensionMethods
	{
		/// <summary>
		/// Get the UNIX timestamp of a given time.
		/// </summary>
		/// <param name="time">Time to convert to UNIX timestamp.</param>
		/// <returns></returns>
		public static Int32 ToUnixTimestampInt32(this DateTime time)
		{
			var origin = new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, millisecond: 0);
			return Convert.ToInt32(Math.Floor((time - origin).TotalSeconds));
		}

		/// <summary>
		/// Get the UNIX timestamp (in seconds) of a given time.
		/// </summary>
		/// <param name="time">Time to convert to UNIX timestamp.</param>
		/// <returns>Number of seconds since UNIX epoch (1970-01-01 00:00:00)</returns>
		public static Int64 ToUnixTimestampInt64(this DateTime time)
		{
			var origin = new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, millisecond: 0);
			return Convert.ToInt64(Math.Floor((time - origin).TotalSeconds));
		}
	}
}