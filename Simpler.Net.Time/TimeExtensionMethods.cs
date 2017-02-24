using System;

namespace Simpler.Net.Time
{
	/// <summary>
	/// Miscellaneous methods to help working with dates and times.
	/// </summary>
	public static class TimeExtensionMethods
	{
		/// <summary>
		/// Convert a date and time into Unix timestamp (seconds since 1970-01-01 00:00:00).
		/// </summary>
		/// <param name="time">Date and time to convert.</param>
		/// <typeparam name="TInt">Type of result. MUST be a 32 or 64 bit integer.</typeparam>
		/// <returns>Seconds since the start of UNIX epoch.</returns>
		/// <exception cref="Exception">Thrown if a type other than a 32 or 64 bit integer is
		/// set as <typeparamref name="TInt"/>.</exception>
		public static TInt ToUnixTimeStamp<TInt>(this DateTime time)
		{
			DateTime origin = SimplerTime.UnixEpochStart;

			var stamp = Math.Floor((time.ToUniversalTime() - origin).TotalSeconds);
			dynamic result;

			switch (typeof(TInt).Name)
			{
				case nameof(Int32):
					result = Convert.ToInt32(stamp);
					break;
				case nameof(UInt32):
					result = Convert.ToUInt32(stamp);
					break;
				case nameof(Int64):
					result = Convert.ToInt64(stamp);
					break;
				case nameof(UInt64):
					result = Convert.ToUInt64(stamp);
					break;
				default:
					throw new Exception($"{nameof(TInt)} is not a valid type for a UNIX timestamp.");
			}

			return result;
		}

		/// <summary>
		/// Truncate a <see cref="DateTime"/> object to a given "precision".
		/// </summary>
		/// <remarks>
		/// From http://stackoverflow.com/questions/1004698/how-to-truncate-milliseconds-off-of-a-net-datetime
		/// 
		/// Similar to how <see cref="Math.Floor(decimal)"/> works, "rounds down" a <see cref="DateTime"/>
		/// by removing (setting to minimum value) the required time component.
		/// 
		/// Examples:
		/// <br />
		/// <code>
		/// // Round down to whole ms
		/// dateTime = dateTime.Truncate(TimeSpan.FromMilliseconds(1));
		/// // Round down to whole seconds
		/// dateTime = dateTime.Truncate(TimeSpan.FromSeconds(1));
		/// // Round down to whole minutes
		/// dateTime = dateTime.Truncate(TimeSpan.FromMinutes(1)); 
		/// // Round down to the nearest second that's a multiple of 5.
		/// dateTime = dateTime.Truncate(TimeSpan.FromSeconds(5)); 
		/// </code> 
		/// </remarks>
		/// <param name="time">Time to truncate</param>
		/// <param name="timeSpan">The time span to remove.</param>
		/// <returns></returns>
		public static DateTime Floor(this DateTime time, TimeSpan timeSpan)
		{
			if (timeSpan == null || timeSpan == TimeSpan.Zero)
				throw new ArgumentException($"DateTime truncation requires a TimeSpan ");

			return time.AddTicks(-(time.Ticks % timeSpan.Ticks));
		}

		/// <summary>
		/// Syntactic sugar for rounding a date down to its whole seconds, 
		/// by using <see cref="Floor"/>.
		/// </summary>
		public static DateTime DropMilliseconds(this DateTime time)
			=> time.Floor(TimeSpan.FromSeconds(1));
	}
}