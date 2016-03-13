using System;

namespace Simpler.Net.Time
{
	public static class TimeExtensionMethods
	{
		/// <summary>
		/// Get the UNIX timestamp of a given time.
		/// </summary>
		/// <param name="time">Time to convert to UNIX timestamp.</param>
		/// <returns></returns>
		public static Int32 ToUnixTimestampInt32(this DateTime time)
		{
			var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			return Convert.ToInt32(Math.Floor((time - origin).TotalSeconds));
		}
	}
}