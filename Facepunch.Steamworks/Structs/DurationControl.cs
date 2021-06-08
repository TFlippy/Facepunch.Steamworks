using System;


namespace Steamworks.Data
{
	/// <summary>
	/// Sent for games with enabled anti indulgence / duration control, for enabled users. 
	/// Lets the game know whether persistent rewards or XP should be granted at normal rate, half rate, or zero rate.
	/// </summary>
	public struct DurationControl
	{
		public DurationControl_t _inner;

		/// <summary>
		/// appid generating playtime
		/// </summary>
		public AppId Appid => this._inner.Appid;

		/// <summary>
		/// is duration control applicable to user + game combination
		/// </summary>
		public bool Applicable => this._inner.Applicable;

		/// <summary>
		/// playtime since most recent 5 hour gap in playtime, only counting up to regulatory limit of playtime, in seconds
		/// </summary>
		public TimeSpan PlaytimeInLastFiveHours => TimeSpan.FromSeconds(this._inner.CsecsLast5h);

		/// <summary>
		/// playtime on current calendar day
		/// </summary>
		public TimeSpan PlaytimeToday => TimeSpan.FromSeconds(this._inner.CsecsLast5h);

		/// <summary>
		/// recommended progress
		/// </summary>
		public DurationControlProgress Progress => this._inner.Progress;
	}
}