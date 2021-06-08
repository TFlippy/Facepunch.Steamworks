using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Steamworks.Ugc
{
	public struct Item
	{
		public SteamUGCDetails_t details;
		public PublishedFileId _id;

		public Item(PublishedFileId id) : this()
		{
			this._id = id;
		}

		/// <summary>
		/// The actual ID of this file
		/// </summary>
		public PublishedFileId Id => this._id;

		/// <summary>
		/// The given title of this item
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The description of this item, in your local language if available
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// A list of tags for this item, all lowercase
		/// </summary>
		public string[] Tags { get; set; }

		/// <summary>
		/// A dictionary of key value tags for this item, only available from queries WithKeyValueTags(true)
		/// </summary>
		public Dictionary<string, string> KeyValueTags { get; set; }

		/// <summary>
		/// App Id of the app that created this item
		/// </summary>
		public AppId CreatorApp => this.details.CreatorAppID;

		/// <summary>
		/// App Id of the app that will consume this item.
		/// </summary>
		public AppId ConsumerApp => this.details.ConsumerAppID;

		/// <summary>
		/// User who created this content
		/// </summary>
		public Friend Owner => new Friend(this.details.SteamIDOwner);

		/// <summary>
		/// The bayesian average for up votes / total votes, between [0,1]
		/// </summary>
		public float Score => this.details.Score;

		/// <summary>
		/// Time when the published item was created
		/// </summary>
		public DateTime Created => Epoch.ToDateTime(this.details.TimeCreated);

		/// <summary>
		/// Time when the published item was last updated
		/// </summary>
		public DateTime Updated => Epoch.ToDateTime(this.details.TimeUpdated);

		/// <summary>
		/// True if this is publically visible
		/// </summary>
		public bool IsPublic => this.details.Visibility == RemoteStoragePublishedFileVisibility.Public;

		/// <summary>
		/// True if this item is only visible by friends of the creator
		/// </summary>
		public bool IsFriendsOnly => this.details.Visibility == RemoteStoragePublishedFileVisibility.FriendsOnly;

		/// <summary>
		/// True if this is only visible to the creator
		/// </summary>
		public bool IsPrivate => this.details.Visibility == RemoteStoragePublishedFileVisibility.Private;

		/// <summary>
		/// True if this item has been banned
		/// </summary>
		public bool IsBanned => this.details.Banned;

		/// <summary>
		/// Whether the developer of this app has specifically flagged this item as accepted in the Workshop
		/// </summary>
		public bool IsAcceptedForUse => this.details.AcceptedForUse;

		/// <summary>
		/// The number of upvotes of this item
		/// </summary>
		public uint VotesUp => this.details.VotesUp;

		/// <summary>
		/// The number of downvotes of this item
		/// </summary>
		public uint VotesDown => this.details.VotesDown;
		/// <summary>
		/// Dependencies/children of this item or collection, available only from WithDependencies(true) queries
		/// </summary>
		public PublishedFileId[] Children;

		/// <summary>
		/// Additional previews of this item or collection, available only from WithAdditionalPreviews(true) queries
		/// </summary>
		public UgcAdditionalPreview[] AdditionalPreviews { get; set; }

		public bool IsInstalled => (this.State & ItemState.Installed) == ItemState.Installed;
		public bool IsDownloading => (this.State & ItemState.Downloading) == ItemState.Downloading;
		public bool IsDownloadPending => (this.State & ItemState.DownloadPending) == ItemState.DownloadPending;
		public bool IsSubscribed => (this.State & ItemState.Subscribed) == ItemState.Subscribed;
		public bool NeedsUpdate => (this.State & ItemState.NeedsUpdate) == ItemState.NeedsUpdate;

		public string Directory
		{
			get
			{
				ulong size = 0;
				uint ts = 0;

				if (!SteamUGC.Internal.GetItemInstallInfo(this.Id, ref size, out var strVal, ref ts))
					return null;

				return strVal;
			}
		}

		/// <summary>
		/// Start downloading this item.
		/// If this returns false the item isn't getting downloaded.
		/// </summary>
		public bool Download(bool highPriority = false)
		{
			return SteamUGC.Download(this.Id, highPriority);
		}

		/// <summary>
		/// If we're downloading, how big the total download is 
		/// </summary>
		public long DownloadBytesTotal
		{
			get
			{
				if (!this.NeedsUpdate)
					return this.SizeBytes;

				ulong downloaded = 0;
				ulong total = 0;
				if (SteamUGC.Internal.GetItemDownloadInfo(this.Id, ref downloaded, ref total))
					return (long)total;

				return -1;
			}
		}

		/// <summary>
		/// If we're downloading, how much we've downloaded
		/// </summary>
		public long DownloadBytesDownloaded
		{
			get
			{
				if (!this.NeedsUpdate)
					return this.SizeBytes;

				ulong downloaded = 0;
				ulong total = 0;
				if (SteamUGC.Internal.GetItemDownloadInfo(this.Id, ref downloaded, ref total))
					return (long)downloaded;

				return -1;
			}
		}

		/// <summary>
		/// If we're installed, how big is the install
		/// </summary>
		public long SizeBytes
		{
			get
			{
				if (this.NeedsUpdate)
					return this.DownloadBytesDownloaded;

				ulong size = 0;
				uint ts = 0;
				if (!SteamUGC.Internal.GetItemInstallInfo(this.Id, ref size, out _, ref ts))
					return 0;

				return (long)size;
			}
		}

		/// <summary>
		/// If we're downloading our current progress as a delta betwen 0-1
		/// </summary>
		public float DownloadAmount
		{
			get
			{
				//changed from NeedsUpdate as it's false when validating and redownloading ugc
				//possibly similar properties should also be changed
				if (!this.IsDownloading) return 1;

				ulong downloaded = 0;
				ulong total = 0;
				if (SteamUGC.Internal.GetItemDownloadInfo(this.Id, ref downloaded, ref total) && total > 0)
					return (float)((double)downloaded / (double)total);

				if (this.NeedsUpdate || !this.IsInstalled || this.IsDownloading)
					return 0;

				return 1;
			}
		}

		private ItemState State => (ItemState)SteamUGC.Internal.GetItemState(this.Id);

		public static async Task<Item?> GetAsync(PublishedFileId id, int maxageseconds = 60 * 30)
		{
			var file = await Steamworks.Ugc.Query.All
											.WithFileId(id)
											.WithLongDescription(true)
											.GetPageAsync(1);

			if (!file.HasValue) return null;
			using (file.Value)
			{
				if (file.Value.ResultCount == 0) return null;

				return file.Value.Entries.First();
			}
		}

		public static Item From(SteamUGCDetails_t details)
		{
			var d = new Item
			{
				_id = details.PublishedFileId,
				details = details,
				Title = details.TitleUTF8(),
				Description = details.DescriptionUTF8(),
				Tags = details.TagsUTF8().ToLower().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
			};

			return d;
		}

		/// <summary>
		/// A case insensitive check for tag
		/// </summary>
		public bool HasTag(string find)
		{
			if (this.Tags.Length == 0) return false;

			return this.Tags.Contains(find, StringComparer.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Allows the user to subscribe to this item
		/// </summary>
		public async Task<bool> Subscribe()
		{
			var result = await SteamUGC.Internal.SubscribeItem(this._id);
			return result?.Result == Result.OK;
		}

		/// <summary>
		/// Allows the user to subscribe to download this item asyncronously
		/// If CancellationToken is default then there is 60 seconds timeout
		/// Progress will be set to 0-1
		/// </summary>
		public async Task<bool> DownloadAsync(Action<float> progress = null, int milisecondsUpdateDelay = 60, CancellationToken ct = default)
		{
			return await SteamUGC.DownloadAsync(this.Id, progress, milisecondsUpdateDelay, ct);
		}

		/// <summary>
		/// Allows the user to unsubscribe from this item
		/// </summary>
		public async Task<bool> Unsubscribe()
		{
			var result = await SteamUGC.Internal.UnsubscribeItem(this._id);
			return result?.Result == Result.OK;
		}

		/// <summary>
		/// Adds item to user favorite list
		/// </summary>
		public async Task<bool> AddFavorite()
		{
			var result = await SteamUGC.Internal.AddItemToFavorites(this.details.ConsumerAppID, this._id);
			return result?.Result == Result.OK;
		}

		/// <summary>
		/// Removes item from user favorite list
		/// </summary>
		public async Task<bool> RemoveFavorite()
		{
			var result = await SteamUGC.Internal.RemoveItemFromFavorites(this.details.ConsumerAppID, this._id);
			return result?.Result == Result.OK;
		}

		/// <summary>
		/// Allows the user to rate a workshop item up or down.
		/// </summary>
		public async Task<Result?> Vote(bool up)
		{
			var r = await SteamUGC.Internal.SetUserItemVote(this.Id, up);
			return r?.Result;
		}

		/// <summary>
		/// Gets the current users vote on the item
		/// </summary>
		public async Task<UserItemVote?> GetUserVote()
		{
			var result = await SteamUGC.Internal.GetUserItemVote(this._id);
			if (!result.HasValue)
				return null;
			return UserItemVote.From(result.Value);
		}

		/// <summary>
		/// Return a URL to view this item online
		/// </summary>
		public string Url => $"http://steamcommunity.com/sharedfiles/filedetails/?source=Facepunch.Steamworks&id={this.Id}";

		/// <summary>
		/// The URl to view this item's changelog
		/// </summary>
		public string ChangelogUrl => $"http://steamcommunity.com/sharedfiles/filedetails/changelog/{this.Id}";

		/// <summary>
		/// The URL to view the comments on this item
		/// </summary>
		public string CommentsUrl => $"http://steamcommunity.com/sharedfiles/filedetails/comments/{this.Id}";

		/// <summary>
		/// The URL to discuss this item
		/// </summary>
		public string DiscussUrl => $"http://steamcommunity.com/sharedfiles/filedetails/discussions/{this.Id}";

		/// <summary>
		/// The URL to view this items stats online
		/// </summary>
		public string StatsUrl => $"http://steamcommunity.com/sharedfiles/filedetails/stats/{this.Id}";

		public ulong NumSubscriptions { get; set; }
		public ulong NumFavorites { get; set; }
		public ulong NumFollowers { get; set; }
		public ulong NumUniqueSubscriptions { get; set; }
		public ulong NumUniqueFavorites { get; set; }
		public ulong NumUniqueFollowers { get; set; }
		public ulong NumUniqueWebsiteViews { get; set; }
		public ulong ReportScore { get; set; }
		public ulong NumSecondsPlayed { get; set; }
		public ulong NumPlaytimeSessions { get; set; }
		public ulong NumComments { get; set; }
		public ulong NumSecondsPlayedDuringTimePeriod { get; set; }
		public ulong NumPlaytimeSessionsDuringTimePeriod { get; set; }

		/// <summary>
		/// The URL to the preview image for this item
		/// </summary>
		public string PreviewImageUrl { get; set; }

		/// <summary>
		/// The metadata string for this item, only available from queries WithMetadata(true)
		/// </summary>
		public string Metadata { get; set; }

		/// <summary>
		/// Edit this item
		/// </summary>
		public Ugc.Editor Edit()
		{
			return new Ugc.Editor(this.Id);
		}

		public async Task<bool> AddDependency(PublishedFileId child)
		{
			var r = await SteamUGC.Internal.AddDependency(this.Id, child);
			return r?.Result == Result.OK;
		}

		public async Task<bool> RemoveDependency(PublishedFileId child)
		{
			var r = await SteamUGC.Internal.RemoveDependency(this.Id, child);
			return r?.Result == Result.OK;
		}

		public Result Result => this.details.Result;
	}
}
