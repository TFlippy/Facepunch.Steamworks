using System.Collections.Generic;
using System.Threading.Tasks;

namespace Steamworks
{
	public struct Clan
	{
		public SteamId Id;

		public Clan(SteamId id)
		{
			this.Id = id;
		}

		public string Name => SteamFriends.Internal.GetClanName(this.Id);

		public string Tag => SteamFriends.Internal.GetClanTag(this.Id);

		public int ChatMemberCount => SteamFriends.Internal.GetClanChatMemberCount(this.Id);

		public Friend Owner => new Friend(SteamFriends.Internal.GetClanOwner(this.Id));

		public bool Public => SteamFriends.Internal.IsClanPublic(this.Id);

		/// <summary>
		/// Is the clan an official game group?
		/// </summary>
		public bool Official => SteamFriends.Internal.IsClanOfficialGameGroup(this.Id);

		/// <summary>
		/// Asynchronously fetches the officer list for a given clan
		/// </summary>
		/// <returns>Whether the request was successful or not</returns>
		public async Task<bool> RequestOfficerList()
		{
			var req = await SteamFriends.Internal.RequestClanOfficerList(this.Id);
			return req.HasValue && req.Value.Success != 0x0;
		}

		public IEnumerable<Friend> GetOfficers()
		{
			for (var i = 0; i < SteamFriends.Internal.GetClanOfficerCount(this.Id); i++)
			{
				yield return new Friend(SteamFriends.Internal.GetClanOfficerByIndex(this.Id, i));
			}
		}
	}
}
