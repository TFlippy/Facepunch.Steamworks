namespace Steamworks
{
	/// <summary>
	/// Functions for clients to access matchmaking services, favorites, and to operate on game lobbies
	/// </summary>
	public class SteamMatchmakingServers: SteamClientClass<SteamMatchmakingServers>
	{
		public static ISteamMatchmakingServers Internal => Interface as ISteamMatchmakingServers;

		public override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamMatchmakingServers(server));
		}

	}
}