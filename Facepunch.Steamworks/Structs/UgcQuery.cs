using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QueryType = Steamworks.Ugc.Query;

namespace Steamworks.Ugc
{
	public struct Query
	{
		private UgcType matchingType;
		private UGCQuery queryType;
		private AppId consumerApp;
		private AppId creatorApp;
		private string searchText;

		public Query(UgcType type) : this()
		{
			this.matchingType = type;
		}

		public static Query All => new Query(UgcType.All);
		public static Query Items => new Query(UgcType.Items);
		public static Query ItemsMtx => new Query(UgcType.Items_Mtx);
		public static Query ItemsReadyToUse => new Query(UgcType.Items_ReadyToUse);
		public static Query Collections => new Query(UgcType.Collections);
		public static Query Artwork => new Query(UgcType.Artwork);
		public static Query Videos => new Query(UgcType.Videos);
		public static Query Screenshots => new Query(UgcType.Screenshots);
		public static Query AllGuides => new Query(UgcType.AllGuides);
		public static Query WebGuides => new Query(UgcType.WebGuides);
		public static Query IntegratedGuides => new Query(UgcType.IntegratedGuides);
		public static Query UsableInGame => new Query(UgcType.UsableInGame);
		public static Query ControllerBindings => new Query(UgcType.ControllerBindings);
		public static Query GameManagedItems => new Query(UgcType.GameManagedItems);


		public Query RankedByVote() { this.queryType = UGCQuery.RankedByVote; return this; }
		public Query RankedByPublicationDate() { this.queryType = UGCQuery.RankedByPublicationDate; return this; }
		public Query RankedByAcceptanceDate() { this.queryType = UGCQuery.AcceptedForGameRankedByAcceptanceDate; return this; }
		public Query RankedByTrend() { this.queryType = UGCQuery.RankedByTrend; return this; }
		public Query FavoritedByFriends() { this.queryType = UGCQuery.FavoritedByFriendsRankedByPublicationDate; return this; }
		public Query CreatedByFriends() { this.queryType = UGCQuery.CreatedByFriendsRankedByPublicationDate; return this; }
		public Query RankedByNumTimesReported() { this.queryType = UGCQuery.RankedByNumTimesReported; return this; }
		public Query CreatedByFollowedUsers() { this.queryType = UGCQuery.CreatedByFollowedUsersRankedByPublicationDate; return this; }
		public Query NotYetRated() { this.queryType = UGCQuery.NotYetRated; return this; }
		public Query RankedByTotalVotesAsc() { this.queryType = UGCQuery.RankedByTotalVotesAsc; return this; }
		public Query RankedByVotesUp() { this.queryType = UGCQuery.RankedByVotesUp; return this; }
		public Query RankedByTextSearch() { this.queryType = UGCQuery.RankedByTextSearch; return this; }
		public Query RankedByTotalUniqueSubscriptions() { this.queryType = UGCQuery.RankedByTotalUniqueSubscriptions; return this; }
		public Query RankedByPlaytimeTrend() { this.queryType = UGCQuery.RankedByPlaytimeTrend; return this; }
		public Query RankedByTotalPlaytime() { this.queryType = UGCQuery.RankedByTotalPlaytime; return this; }
		public Query RankedByAveragePlaytimeTrend() { this.queryType = UGCQuery.RankedByAveragePlaytimeTrend; return this; }
		public Query RankedByLifetimeAveragePlaytime() { this.queryType = UGCQuery.RankedByLifetimeAveragePlaytime; return this; }
		public Query RankedByPlaytimeSessionsTrend() { this.queryType = UGCQuery.RankedByPlaytimeSessionsTrend; return this; }
		public Query RankedByLifetimePlaytimeSessions() { this.queryType = UGCQuery.RankedByLifetimePlaytimeSessions; return this; }

		#region UserQuery

		private SteamId? steamid;
		private UserUGCList userType;
		private UserUGCListSortOrder userSort;

		public Query LimitUser(SteamId steamid)
		{
			if (steamid.Value == 0)
				steamid = SteamClient.SteamId;

			this.steamid = steamid;
			return this;
		}

		public Query WhereUserPublished(SteamId user = default) { this.userType = UserUGCList.Published; this.LimitUser(user); return this; }
		public Query WhereUserVotedOn(SteamId user = default) { this.userType = UserUGCList.VotedOn; this.LimitUser(user); return this; }
		public Query WhereUserVotedUp(SteamId user = default) { this.userType = UserUGCList.VotedUp; this.LimitUser(user); return this; }
		public Query WhereUserVotedDown(SteamId user = default) { this.userType = UserUGCList.VotedDown; this.LimitUser(user); return this; }
		public Query WhereUserWillVoteLater(SteamId user = default) { this.userType = UserUGCList.WillVoteLater; this.LimitUser(user); return this; }
		public Query WhereUserFavorited(SteamId user = default) { this.userType = UserUGCList.Favorited; this.LimitUser(user); return this; }
		public Query WhereUserSubscribed(SteamId user = default) { this.userType = UserUGCList.Subscribed; this.LimitUser(user); return this; }
		public Query WhereUserUsedOrPlayed(SteamId user = default) { this.userType = UserUGCList.UsedOrPlayed; this.LimitUser(user); return this; }
		public Query WhereUserFollowed(SteamId user = default) { this.userType = UserUGCList.Followed; this.LimitUser(user); return this; }

		public Query SortByCreationDate() { this.userSort = UserUGCListSortOrder.CreationOrderDesc; return this; }
		public Query SortByCreationDateAsc() { this.userSort = UserUGCListSortOrder.CreationOrderAsc; return this; }
		public Query SortByTitleAsc() { this.userSort = UserUGCListSortOrder.TitleAsc; return this; }
		public Query SortByUpdateDate() { this.userSort = UserUGCListSortOrder.LastUpdatedDesc; return this; }
		public Query SortBySubscriptionDate() { this.userSort = UserUGCListSortOrder.SubscriptionDateDesc; return this; }
		public Query SortByVoteScore() { this.userSort = UserUGCListSortOrder.VoteScoreDesc; return this; }
		public Query SortByModeration() { this.userSort = UserUGCListSortOrder.ForModeration; return this; }

		public Query WhereSearchText(string searchText) { this.searchText = searchText; return this; }

		#endregion

		#region Files
		private PublishedFileId[] Files;

		public Query WithFileId(params PublishedFileId[] files)
		{
			this.Files = files;
			return this;
		}
		#endregion

		public async Task<ResultPage?> GetPageAsync(int page)
		{
			if (page <= 0) throw new System.Exception("page should be > 0");

			if (this.consumerApp == 0) this.consumerApp = SteamClient.AppId;
			if (this.creatorApp == 0) this.creatorApp = this.consumerApp;

			UGCQueryHandle_t handle;

			if (this.Files != null)
			{
				handle = SteamUGC.Internal.CreateQueryUGCDetailsRequest(this.Files, (uint)this.Files.Length);
			}
			else if (this.steamid.HasValue)
			{
				handle = SteamUGC.Internal.CreateQueryUserUGCRequest(this.steamid.Value.AccountId, this.userType, this.matchingType, this.userSort, this.creatorApp.Value, this.consumerApp.Value, (uint)page);
			}
			else
			{
				handle = SteamUGC.Internal.CreateQueryAllUGCRequest(this.queryType, this.matchingType, this.creatorApp.Value, this.consumerApp.Value, (uint)page);
			}

			this.ApplyReturns(handle);

			if (this.maxCacheAge.HasValue)
			{
				SteamUGC.Internal.SetAllowCachedResponse(handle, (uint)this.maxCacheAge.Value);
			}

			this.ApplyConstraints(handle);

			var result = await SteamUGC.Internal.SendQueryUGCRequest(handle);
			if (!result.HasValue)
				return null;

			if (result.Value.Result != Steamworks.Result.OK)
				return null;

			return new ResultPage
			{
				Handle = result.Value.Handle,
				ResultCount = (int)result.Value.NumResultsReturned,
				TotalCount = (int)result.Value.TotalMatchingResults,
				CachedData = result.Value.CachedData,
				ReturnsKeyValueTags = this.WantsReturnKeyValueTags ?? false,
				ReturnsDefaultStats = this.WantsDefaultStats ?? true, //true by default
				ReturnsMetadata = this.WantsReturnMetadata ?? false,
				ReturnsChildren = this.WantsReturnChildren ?? false,
				ReturnsAdditionalPreviews = this.WantsReturnAdditionalPreviews ?? false,
			};
		}

		#region SharedConstraints
		public QueryType WithType(UgcType type) { this.matchingType = type; return this; }

		private int? maxCacheAge;
		public QueryType AllowCachedResponse(int maxSecondsAge) { this.maxCacheAge = maxSecondsAge; return this; }

		private string language;
		public QueryType InLanguage(string lang) { this.language = lang; return this; }

		private int? trendDays;
		public QueryType WithTrendDays(int days) { this.trendDays = days; return this; }

		private List<string> requiredTags;
		private bool? matchAnyTag;
		private List<string> excludedTags;
		private Dictionary<string, string> requiredKv;

		/// <summary>
		/// Found items must have at least one of the defined tags
		/// </summary>
		public QueryType MatchAnyTag() { this.matchAnyTag = true; return this; }

		/// <summary>
		/// Found items must have all defined tags
		/// </summary>
		public QueryType MatchAllTags() { this.matchAnyTag = false; return this; }

		public QueryType WithTag(string tag)
		{
			if (this.requiredTags == null) this.requiredTags = new List<string>();
			this.requiredTags.Add(tag);
			return this;
		}

		public QueryType AddRequiredKeyValueTag(string key, string value)
		{
			if (this.requiredKv == null) this.requiredKv = new Dictionary<string, string>();
			this.requiredKv.Add(key, value);
			return this;
		}

		public QueryType WithoutTag(string tag)
		{
			if (this.excludedTags == null) this.excludedTags = new List<string>();
			this.excludedTags.Add(tag);
			return this;
		}

		private void ApplyConstraints(UGCQueryHandle_t handle)
		{
			if (this.requiredTags != null)
			{
				foreach (var tag in this.requiredTags)
					SteamUGC.Internal.AddRequiredTag(handle, tag);
			}

			if (this.excludedTags != null)
			{
				foreach (var tag in this.excludedTags)
					SteamUGC.Internal.AddExcludedTag(handle, tag);
			}

			if (this.requiredKv != null)
			{
				foreach (var tag in this.requiredKv)
					SteamUGC.Internal.AddRequiredKeyValueTag(handle, tag.Key, tag.Value);
			}

			if (this.matchAnyTag.HasValue)
			{
				SteamUGC.Internal.SetMatchAnyTag(handle, this.matchAnyTag.Value);
			}

			if (this.trendDays.HasValue)
			{
				SteamUGC.Internal.SetRankedByTrendDays(handle, (uint)this.trendDays.Value);
			}

			if (!string.IsNullOrEmpty(this.searchText))
			{
				SteamUGC.Internal.SetSearchText(handle, this.searchText);
			}
		}

		#endregion

		#region ReturnValues

		private bool? WantsReturnOnlyIDs;
		public QueryType WithOnlyIDs(bool b) { this.WantsReturnOnlyIDs = b; return this; }

		private bool? WantsReturnKeyValueTags;
		public QueryType WithKeyValueTags(bool b) { this.WantsReturnKeyValueTags = b; return this; }
		[Obsolete("Renamed to WithKeyValueTags")]
		public QueryType WithKeyValueTag(bool b) { this.WantsReturnKeyValueTags = b; return this; }

		private bool? WantsReturnLongDescription;
		public QueryType WithLongDescription(bool b) { this.WantsReturnLongDescription = b; return this; }

		private bool? WantsReturnMetadata;
		public QueryType WithMetadata(bool b) { this.WantsReturnMetadata = b; return this; }

		private bool? WantsReturnChildren;
		public QueryType WithChildren(bool b) { this.WantsReturnChildren = b; return this; }

		private bool? WantsReturnAdditionalPreviews;
		public QueryType WithAdditionalPreviews(bool b) { this.WantsReturnAdditionalPreviews = b; return this; }

		private bool? WantsReturnTotalOnly;
		public QueryType WithTotalOnly(bool b) { this.WantsReturnTotalOnly = b; return this; }

		private uint? WantsReturnPlaytimeStats;
		public QueryType WithPlaytimeStats(uint unDays) { this.WantsReturnPlaytimeStats = unDays; return this; }

		private void ApplyReturns(UGCQueryHandle_t handle)
		{
			if (this.WantsReturnOnlyIDs.HasValue)
			{
				SteamUGC.Internal.SetReturnOnlyIDs(handle, this.WantsReturnOnlyIDs.Value);
			}

			if (this.WantsReturnKeyValueTags.HasValue)
			{
				SteamUGC.Internal.SetReturnKeyValueTags(handle, this.WantsReturnKeyValueTags.Value);
			}

			if (this.WantsReturnLongDescription.HasValue)
			{
				SteamUGC.Internal.SetReturnLongDescription(handle, this.WantsReturnLongDescription.Value);
			}

			if (this.WantsReturnMetadata.HasValue)
			{
				SteamUGC.Internal.SetReturnMetadata(handle, this.WantsReturnMetadata.Value);
			}

			if (this.WantsReturnChildren.HasValue)
			{
				SteamUGC.Internal.SetReturnChildren(handle, this.WantsReturnChildren.Value);
			}

			if (this.WantsReturnAdditionalPreviews.HasValue)
			{
				SteamUGC.Internal.SetReturnAdditionalPreviews(handle, this.WantsReturnAdditionalPreviews.Value);
			}

			if (this.WantsReturnTotalOnly.HasValue)
			{
				SteamUGC.Internal.SetReturnTotalOnly(handle, this.WantsReturnTotalOnly.Value);
			}

			if (this.WantsReturnPlaytimeStats.HasValue)
			{
				SteamUGC.Internal.SetReturnPlaytimeStats(handle, this.WantsReturnPlaytimeStats.Value);
			}
		}

		#endregion

		#region LoadingBehaviour

		private bool? WantsDefaultStats; //true by default
		/// <summary>
		/// Set to false to disable, by default following stats are loaded: NumSubscriptions, NumFavorites, NumFollowers, NumUniqueSubscriptions, NumUniqueFavorites, NumUniqueFollowers, NumUniqueWebsiteViews, ReportScore, NumSecondsPlayed, NumPlaytimeSessions, NumComments, NumSecondsPlayedDuringTimePeriod, NumPlaytimeSessionsDuringTimePeriod
		/// </summary>
		public QueryType WithDefaultStats(bool b) { this.WantsDefaultStats = b; return this; }

		#endregion
	}
}