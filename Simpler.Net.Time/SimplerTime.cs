using System;

namespace Simpler.Net.Time
{
	public class SimplerTime
	{
		/// <summary>
		/// Beginning of the Unix epoch (in UTC): 1970-01-01 00:00:00
		/// </summary>
		public static DateTime UnixEpochStart;

		static SimplerTime()
		{
			UnixEpochStart = new DateTime(
				year: 1970,
				month: 1,
				day: 1,
				hour: 0,
				minute: 0,
				second: 0,				
				kind: DateTimeKind.Utc);
		}
	}
}