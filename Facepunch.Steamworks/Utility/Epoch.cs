﻿using System;

namespace Steamworks
{
	public static class Epoch
	{
		private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		/// <summary>
		/// Returns the current Unix Epoch
		/// </summary>
		public static int Current => (int)(DateTime.UtcNow.Subtract(epoch).TotalSeconds);

		/// <summary>
		/// Convert an epoch to a datetime
		/// </summary>
		public static DateTime ToDateTime(decimal unixTime)
		{
			return epoch.AddSeconds((long)unixTime);
		}

		/// <summary>
		/// Convert a DateTime to a unix time
		/// </summary>
		public static uint FromDateTime(DateTime dt)
		{
			return (uint)(dt.Subtract(epoch).TotalSeconds);
		}
	}
}
