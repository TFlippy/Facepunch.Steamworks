using Steamworks.Data;
using System.Collections.Generic;

namespace Steamworks.Ugc
{
	public struct ResultPage: System.IDisposable
	{
		public UGCQueryHandle_t Handle;

		public int ResultCount;
		public int TotalCount;

		public bool CachedData;

		public bool ReturnsKeyValueTags;
		public bool ReturnsDefaultStats;
		public bool ReturnsMetadata;
		public bool ReturnsChildren;
		public bool ReturnsAdditionalPreviews;

		public IEnumerable<Item> Entries
		{
			get
			{

				var details = default(SteamUGCDetails_t);
				for (uint i = 0; i < this.ResultCount; i++)
				{
					if (SteamUGC.Internal.GetQueryUGCResult(this.Handle, i, ref details))
					{
						var item = Item.From(details);


						if (this.ReturnsDefaultStats)
						{
							item.NumSubscriptions = this.GetStat(i, ItemStatistic.NumSubscriptions);
							item.NumFavorites = this.GetStat(i, ItemStatistic.NumFavorites);
							item.NumFollowers = this.GetStat(i, ItemStatistic.NumFollowers);
							item.NumUniqueSubscriptions = this.GetStat(i, ItemStatistic.NumUniqueSubscriptions);
							item.NumUniqueFavorites = this.GetStat(i, ItemStatistic.NumUniqueFavorites);
							item.NumUniqueFollowers = this.GetStat(i, ItemStatistic.NumUniqueFollowers);
							item.NumUniqueWebsiteViews = this.GetStat(i, ItemStatistic.NumUniqueWebsiteViews);
							item.ReportScore = this.GetStat(i, ItemStatistic.ReportScore);
							item.NumSecondsPlayed = this.GetStat(i, ItemStatistic.NumSecondsPlayed);
							item.NumPlaytimeSessions = this.GetStat(i, ItemStatistic.NumPlaytimeSessions);
							item.NumComments = this.GetStat(i, ItemStatistic.NumComments);
							item.NumSecondsPlayedDuringTimePeriod = this.GetStat(i, ItemStatistic.NumSecondsPlayedDuringTimePeriod);
							item.NumPlaytimeSessionsDuringTimePeriod = this.GetStat(i, ItemStatistic.NumPlaytimeSessionsDuringTimePeriod);
						}

						if (SteamUGC.Internal.GetQueryUGCPreviewURL(this.Handle, i, out var preview))
						{
							item.PreviewImageUrl = preview;
						}

						if (this.ReturnsKeyValueTags)
						{
							var keyValueTagsCount = SteamUGC.Internal.GetQueryUGCNumKeyValueTags(this.Handle, i);

							item.KeyValueTags = new Dictionary<string, string>((int)keyValueTagsCount);
							for (uint j = 0; j < keyValueTagsCount; j++)
							{
								string key, value;
								if (SteamUGC.Internal.GetQueryUGCKeyValueTag(this.Handle, i, j, out key, out value))
									item.KeyValueTags[key] = value;
							}
						}

						if (this.ReturnsMetadata)
						{
							string metadata;
							if (SteamUGC.Internal.GetQueryUGCMetadata(this.Handle, i, out metadata))
							{
								item.Metadata = metadata;
							}
						}

						var numChildren = item.details.NumChildren;
						if (this.ReturnsChildren && numChildren > 0)
						{
							var children = new PublishedFileId[numChildren];
							if (SteamUGC.Internal.GetQueryUGCChildren(this.Handle, i, children, numChildren))
							{
								item.Children = children;
							}
						}

						if (this.ReturnsAdditionalPreviews)
						{
							var previewsCount = SteamUGC.Internal.GetQueryUGCNumAdditionalPreviews(this.Handle, i);
							if (previewsCount > 0)
							{
								item.AdditionalPreviews = new UgcAdditionalPreview[previewsCount];
								for (uint j = 0; j < previewsCount; j++)
								{
									string previewUrlOrVideo;
									string originalFileName; //what is this???
									ItemPreviewType previewType = default;
									if (SteamUGC.Internal.GetQueryUGCAdditionalPreview(
										this.Handle, i, j, out previewUrlOrVideo, out originalFileName, ref previewType))
									{
										item.AdditionalPreviews[j] = new UgcAdditionalPreview(
											previewUrlOrVideo, originalFileName, previewType);
									}
								}
							}
						}

						yield return item;
					}
				}
			}
		}

		private ulong GetStat(uint index, ItemStatistic stat)
		{
			ulong val = 0;

			if (!SteamUGC.Internal.GetQueryUGCStatistic(this.Handle, index, stat, ref val))
				return 0;

			return val;
		}

		public void Dispose()
		{
			if (this.Handle > 0)
			{
				SteamUGC.Internal.ReleaseQueryUGCRequest(this.Handle);
				this.Handle = 0;
			}
		}
	}
}