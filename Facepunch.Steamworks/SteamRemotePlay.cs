using Steamworks.Data;
using System;

namespace Steamworks
{
	/// <summary>
	/// Functions that provide information about Steam Remote Play sessions, streaming your game content to another computer or to a Steam Link app or hardware.
	/// </summary>
	public class SteamRemotePlay: SteamClientClass<SteamRemotePlay>
	{
		public static ISteamRemotePlay Internal => Interface as ISteamRemotePlay;

		public override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamRemotePlay(server));

			this.InstallEvents(server);
		}

		public void InstallEvents(bool server)
		{
			Dispatch.Install<SteamRemotePlaySessionConnected_t>(x => OnSessionConnected?.Invoke(x.SessionID), server);
			Dispatch.Install<SteamRemotePlaySessionDisconnected_t>(x => OnSessionDisconnected?.Invoke(x.SessionID), server);
		}

		/// <summary>
		/// Called when a session is connected
		/// </summary>
		public static event Action<RemotePlaySession> OnSessionConnected;

		/// <summary>
		/// Called when a session becomes disconnected
		/// </summary>
		public static event Action<RemotePlaySession> OnSessionDisconnected;

		/// <summary>
		/// Get the number of currently connected Steam Remote Play sessions
		/// </summary>
		public static int SessionCount => (int)Internal.GetSessionCount();

		/// <summary>
		/// Get the currently connected Steam Remote Play session ID at the specified index.
		/// IsValid will return false if it's out of bounds
		/// </summary>
		public static RemotePlaySession GetSession(int index)
		{
			return (RemotePlaySession)Internal.GetSessionID(index).Value;
		}


		/// <summary>
		/// Invite a friend to Remote Play Together
		/// This returns false if the invite can't be sent
		/// </summary>
		public static bool SendInvite(SteamId steamid)
		{
			return Internal.BSendRemotePlayTogetherInvite(steamid);
		}
	}
}
