using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Steamworks
{
	public struct Friend
	{
		public SteamId Id;

		public Friend(SteamId steamid)
		{
			this.Id = steamid;
		}

		public override string ToString()
		{
			return $"{this.Name} ({this.Id.ToString()})";
		}


		/// <summary>
		/// Returns true if this is the local user
		/// </summary>
		public bool IsMe => this.Id == SteamClient.SteamId;

		/// <summary>
		/// Return true if this is a friend
		/// </summary>
		public bool IsFriend => this.Relationship == Relationship.Friend;

		/// <summary>
		/// Returns true if you have this user blocked
		/// </summary>
		public bool IsBlocked => this.Relationship == Relationship.Blocked;

		/// <summary>
		/// Return true if this user is playing the game we're running
		/// </summary>
		public bool IsPlayingThisGame => this.GameInfo?.GameID == SteamClient.AppId;

		/// <summary>
		/// Returns true if this friend is online
		/// </summary>
		public bool IsOnline => this.State != FriendState.Offline;

		/// <summary>
		/// Sometimes we don't know the user's name. This will wait until we have
		/// downloaded the information on this user.
		/// </summary>
		public async Task RequestInfoAsync()
		{
			await SteamFriends.CacheUserInformationAsync(this.Id, true);
		}

		/// <summary>
		/// Returns true if this friend is marked as away
		/// </summary>
		public bool IsAway => this.State == FriendState.Away;

		/// <summary>
		/// Returns true if this friend is marked as busy
		/// </summary>
		public bool IsBusy => this.State == FriendState.Busy;

		/// <summary>
		/// Returns true if this friend is marked as snoozing
		/// </summary>
		public bool IsSnoozing => this.State == FriendState.Snooze;



		public Relationship Relationship => SteamFriends.Internal.GetFriendRelationship(this.Id);
		public FriendState State => SteamFriends.Internal.GetFriendPersonaState(this.Id);
		public string Name => SteamFriends.Internal.GetFriendPersonaName(this.Id);
		public IEnumerable<string> NameHistory
		{
			get
			{
				for (var i = 0; i < 32; i++)
				{
					var n = SteamFriends.Internal.GetFriendPersonaNameHistory(this.Id, i);
					if (string.IsNullOrEmpty(n))
						break;

					yield return n;
				}
			}
		}

		public int SteamLevel => SteamFriends.Internal.GetFriendSteamLevel(this.Id);



		public FriendGameInfo? GameInfo
		{
			get
			{
				FriendGameInfo_t gameInfo = default;
				if (!SteamFriends.Internal.GetFriendGamePlayed(this.Id, ref gameInfo))
					return null;

				return FriendGameInfo.From(gameInfo);
			}
		}

		public bool IsIn(SteamId group_or_room)
		{
			return SteamFriends.Internal.IsUserInSource(this.Id, group_or_room);
		}

		public struct FriendGameInfo
		{
			public ulong GameID; // m_gameID class CGameID
			public uint GameIP; // m_unGameIP uint32
			public ulong SteamIDLobby; // m_steamIDLobby class CSteamID

			public int ConnectionPort;
			public int QueryPort;

			public uint IpAddressRaw => this.GameIP;
			public System.Net.IPAddress IpAddress => Utility.Int32ToIp(this.GameIP);

			public Lobby? Lobby
			{
				get
				{
					if (this.SteamIDLobby == 0) return null;
					return new Lobby(this.SteamIDLobby);
				}
			}

			public static FriendGameInfo From(FriendGameInfo_t i)
			{
				return new FriendGameInfo
				{
					GameID = i.GameID,
					GameIP = i.GameIP,
					ConnectionPort = i.GamePort,
					QueryPort = i.QueryPort,
					SteamIDLobby = i.SteamIDLobby,
				};
			}
		}

		public async Task<Data.Image?> GetSmallAvatarAsync()
		{
			return await SteamFriends.GetSmallAvatarAsync(this.Id);
		}

		public async Task<Data.Image?> GetMediumAvatarAsync()
		{
			return await SteamFriends.GetMediumAvatarAsync(this.Id);
		}

		public async Task<Data.Image?> GetLargeAvatarAsync()
		{
			return await SteamFriends.GetLargeAvatarAsync(this.Id);
		}

		public string GetRichPresence(string key)
		{
			var val = SteamFriends.Internal.GetFriendRichPresence(this.Id, key);
			if (string.IsNullOrEmpty(val)) return null;
			return val;
		}

		/// <summary>
		/// Invite this friend to the game that we are playing
		/// </summary>
		public bool InviteToGame(string Text)
		{
			return SteamFriends.Internal.InviteUserToGame(this.Id, Text);
		}

		/// <summary>
		/// Sends a message to a Steam friend. Returns true if success
		/// </summary>
		public bool SendMessage(string message)
		{
			return SteamFriends.Internal.ReplyToFriendMessage(this.Id, message);
		}


		/// <summary>
		/// Tries to get download the latest user stats
		/// </summary>
		/// <returns>True if successful, False if failure</returns>
		public async Task<bool> RequestUserStatsAsync()
		{
			var result = await SteamUserStats.Internal.RequestUserStats(this.Id);
			return result.HasValue && result.Value.Result == Result.OK;
		}

		/// <summary>
		/// Gets a user stat. Must call RequestUserStats first.
		/// </summary>
		/// <param name="statName">The name of the stat you want to get</param>
		/// <param name="defult">Will return this value if not available</param>
		/// <returns>The value, or defult if not available</returns>
		public float GetStatFloat(string statName, float defult = 0)
		{
			var val = defult;

			if (!SteamUserStats.Internal.GetUserStat(this.Id, statName, ref val))
				return defult;

			return val;
		}

		/// <summary>
		/// Gets a user stat. Must call RequestUserStats first.
		/// </summary>
		/// <param name="statName">The name of the stat you want to get</param>
		/// <param name="defult">Will return this value if not available</param>
		/// <returns>The value, or defult if not available</returns>
		public int GetStatInt(string statName, int defult = 0)
		{
			var val = defult;

			if (!SteamUserStats.Internal.GetUserStat(this.Id, statName, ref val))
				return defult;

			return val;
		}

		/// <summary>
		/// Gets a user achievement state. Must call RequestUserStats first.
		/// </summary>
		/// <param name="statName">The name of the achievement you want to get</param>
		/// <param name="defult">Will return this value if not available</param>
		/// <returns>The value, or defult if not available</returns>
		public bool GetAchievement(string statName, bool defult = false)
		{
			var val = defult;

			if (!SteamUserStats.Internal.GetUserAchievement(this.Id, statName, ref val))
				return defult;

			return val;
		}

		/// <summary>
		/// Gets a the time this achievement was unlocked.
		/// </summary>
		/// <param name="statName">The name of the achievement you want to get</param>
		/// <returns>The time unlocked. If it wasn't unlocked, or you haven't downloaded the stats yet - will return DateTime.MinValue</returns>
		public DateTime GetAchievementUnlockTime(string statName)
		{
			var val = false;
			uint time = 0;

			if (!SteamUserStats.Internal.GetUserAchievementAndUnlockTime(this.Id, statName, ref val, ref time) || !val)
				return DateTime.MinValue;

			return Epoch.ToDateTime(time);
		}

	}
}