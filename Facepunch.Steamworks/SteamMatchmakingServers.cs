using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Functions for clients to access matchmaking services, favorites, and to operate on game lobbies
	/// </summary>
	public class SteamMatchmakingServers : SteamClientClass<SteamMatchmakingServers>
	{
		public static ISteamMatchmakingServers Internal => Interface as ISteamMatchmakingServers;

		public override void InitializeInterface( bool server )
		{
			SetInterface( server, new ISteamMatchmakingServers( server ) );
		}
	}
}