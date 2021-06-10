using System;

namespace Steamworks
{
	/// <summary>
	/// Undocumented Parental Settings
	/// </summary>
	public class SteamVideo: SteamClientClass<SteamVideo>
	{
		public static ISteamVideo Internal => Interface as ISteamVideo;

		public override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamVideo(server));
			InstallEvents();
		}

		public static void InstallEvents()
		{
		}

		/// <summary>
		/// Return true if currently using Steam's live broadcasting
		/// </summary>
		public static bool IsBroadcasting
		{
			get
			{
				var viewers = 0;
				return Internal.IsBroadcasting(ref viewers);
			}
		}

		/// <summary>
		/// If we're broadcasting, will return the number of live viewers
		/// </summary>
		public static int NumViewers
		{
			get
			{
				var viewers = 0;

				if (!Internal.IsBroadcasting(ref viewers))
					return 0;

				return viewers;
			}
		}
	}
}