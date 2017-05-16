using System;
using System.Globalization;

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
		/// <typeparam name="TInt">Type of result. MUST be a signed 32 or 64 bit integer.</typeparam>
		/// <returns>Seconds since the start of UNIX epoch.</returns>
		/// <exception cref="Exception">Thrown if a type other than a signed 32 or 64 bit integer is
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
				case nameof(Int64):
					result = Convert.ToInt64(stamp);
					break;
				default:
					throw new Exception(
						$"{nameof(TInt)} is not a valid type for a UNIX timestamp, must be a signed integer.");
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


		/// <summary>
		/// Shorthand for outputting a culture-formatted date (short format, usually numbers only).
		/// </summary>
		/// <param name="date">Date to output</param>
		/// <param name="cultureInfo">Culture to use for determining format. Set to <c>null</c> to use
		/// <see cref="CultureInfo.CurrentCulture"/>.</param>
		/// <returns></returns>
		public static String ToShortDateString(this DateTime date, CultureInfo cultureInfo = null)
		{
			if (cultureInfo == null)
				cultureInfo = CultureInfo.CurrentCulture;

			return date.ToString(cultureInfo.DateTimeFormat.ShortDatePattern);
		}

		/// <summary>
		/// Output a date and time in localized short format, with single space as separator.
		/// </summary>
		/// <example>
		/// date.ToShortDateTimeString();
		/// // 31.12.2010 23:59
		/// </example>
		/// <param name="date"></param>
		/// <param name="cultureInfo">Culture to use for determining format. Set to <c>null</c> to 
		/// use <see cref="CultureInfo.CurrentCulture"/>.</param>
		/// <returns></returns>
		public static String ToShortDateTimeString(this DateTime date, CultureInfo cultureInfo = null)
		{
			if (cultureInfo == null)
				cultureInfo = CultureInfo.CurrentCulture;

			return date.ToString(
				$"{cultureInfo.DateTimeFormat.ShortDatePattern} {cultureInfo.DateTimeFormat.ShortTimePattern}");
		}


		/// <summary>
		/// Outputs a date and time in the ISO8601 format that is also valid for HTML5's <c>&lt;time&gt;</c> tag.
		/// </summary>
		/// <remarks>
		/// HTML5's <c>&lt;time&gt;</c> tag's <c>datetime</c> attribute only supports (considers valid)
		/// fractions of seconds that are no more than 3 digits. Use this method to output a standard ISO8601
		/// format date and time (almost identical to .NET's "o" format specifier) that observes this limit. 
		/// </remarks>
		/// <param name="time">Date and time to output.</param>
		/// <returns>Text representing the time in HTML5-compatible ISO8601 format.</returns>
		public static String ToIso8601HtmlString(this DateTime time)
		{
			return time.ToString("yyyy-MM-ddTHH:mm:ss.FFFK");
		}
	}
}