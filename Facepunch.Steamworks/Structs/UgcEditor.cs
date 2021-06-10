using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steamworks.Ugc
{
	public struct Editor
	{
		private PublishedFileId fileId;
		private bool creatingNew;
		private WorkshopFileType creatingType;
		private AppId consumerAppId;

		public Editor(WorkshopFileType filetype) : this()
		{
			this.creatingNew = true;
			this.creatingType = filetype;
		}

		public Editor(PublishedFileId fileId) : this()
		{
			this.fileId = fileId;
		}

		/// <summary>
		/// Create a Normal Workshop item that can be subscribed to
		/// </summary>
		public static Editor NewCommunityFile => new Editor(WorkshopFileType.Community);

		/// <summary>
		/// Create a Collection
		/// Add items using Item.AddDependency()
		/// </summary>
		public static Editor NewCollection => new Editor(WorkshopFileType.Collection);

		/// <summary>
		/// Workshop item that is meant to be voted on for the purpose of selling in-game
		/// </summary>
		public static Editor NewMicrotransactionFile => new Editor( WorkshopFileType.Microtransaction );

		/// <summary>
		/// Workshop item that is meant to be managed by the game. It is queryable by the API, but isn't visible on the web browser.
		/// </summary>
		public static Editor NewGameManagedFile => new Editor(WorkshopFileType.GameManagedItem);

		public Editor ForAppId( AppId id ) { this.consumerAppId = id; return this; }

		private string Title;
		public Editor WithTitle(string t) { this.Title = t; return this; }

		private string Description;
		public Editor WithDescription(string t) { this.Description = t; return this; }

		private string MetaData;
		public Editor WithMetaData(string t) { this.MetaData = t; return this; }

		private string ChangeLog;
		public Editor WithChangeLog(string t) { this.ChangeLog = t; return this; }

		private string Language;
		public Editor InLanguage(string t) { this.Language = t; return this; }

		private string PreviewFile;
		public Editor WithPreviewFile(string t) { this.PreviewFile = t; return this; }

		private System.IO.DirectoryInfo ContentFolder;
		public Editor WithContent(System.IO.DirectoryInfo t) { this.ContentFolder = t; return this; }
		public Editor WithContent(string folderName) { return this.WithContent(new System.IO.DirectoryInfo(folderName)); }

		private RemoteStoragePublishedFileVisibility? Visibility;

		public Editor WithPublicVisibility() { this.Visibility = RemoteStoragePublishedFileVisibility.Public; return this; }
		public Editor WithFriendsOnlyVisibility() { this.Visibility = RemoteStoragePublishedFileVisibility.FriendsOnly; return this; }
		public Editor WithPrivateVisibility() { this.Visibility = RemoteStoragePublishedFileVisibility.Private; return this; }

		private List<string> Tags;
		private Dictionary<string, List<string>> KeyValueTags;
		private HashSet<string> KeyValueTagsToRemove;

		public Editor WithTag(string tag)
		{
			if (this.Tags == null) this.Tags = new List<string>();

			this.Tags.Add(tag);

			return this;
		}

		/// <summary>
		/// Adds a key-value tag pair to an item. 
		/// Keys can map to multiple different values (1-to-many relationship). 
		/// Key names are restricted to alpha-numeric characters and the '_' character. 
		/// Both keys and values cannot exceed 255 characters in length. Key-value tags are searchable by exact match only.
		/// To replace all values associated to one key use RemoveKeyValueTags then AddKeyValueTag.
		/// </summary>
		public Editor AddKeyValueTag(string key, string value)
		{
			if (this.KeyValueTags == null)
				this.KeyValueTags = new Dictionary<string, List<string>>();

			if (this.KeyValueTags.TryGetValue(key, out var list))
				list.Add(value);
			else
				this.KeyValueTags[key] = new List<string>() { value };

			return this;
		}

		/// <summary>
		/// Removes a key and all values associated to it. 
		/// You can remove up to 100 keys per item update. 
		/// If you need remove more tags than that you'll need to make subsequent item updates.
		/// </summary>
		public Editor RemoveKeyValueTags(string key)
		{
			if (this.KeyValueTagsToRemove == null)
				this.KeyValueTagsToRemove = new HashSet<string>();

			this.KeyValueTagsToRemove.Add(key);
			return this;
		}

		public async Task<PublishResult> SubmitAsync( IProgress<float> progress = null, Action<PublishResult> onItemCreated = null )
		{
			var result = default(PublishResult);

			progress?.Report(0);

			if (this.consumerAppId == 0)
				this.consumerAppId = SteamClient.AppId;

			//
			// Checks
			//
			if (this.ContentFolder != null)
			{
				if (!System.IO.Directory.Exists(this.ContentFolder.FullName))
					throw new System.Exception($"UgcEditor - Content Folder doesn't exist ({this.ContentFolder.FullName})");

				if (!this.ContentFolder.EnumerateFiles("*", System.IO.SearchOption.AllDirectories).Any())
					throw new System.Exception($"UgcEditor - Content Folder is empty");
			}


			//
			// Item Create
			//
			if (this.creatingNew)
			{
				result.Result = Steamworks.Result.Fail;

				var created = await SteamUGC.Internal.CreateItem(this.consumerAppId, this.creatingType);
				if (!created.HasValue) return result;

				result.Result = created.Value.Result;

				if (result.Result != Steamworks.Result.OK)
					return result;

				this.fileId = created.Value.PublishedFileId;
				result.NeedsWorkshopAgreement = created.Value.UserNeedsToAcceptWorkshopLegalAgreement;
				result.FileId = fileId;

				if ( onItemCreated != null )
					onItemCreated( result );
			}


			result.FileId = this.fileId;

			//
			// Item Update
			//
			{
				var handle = SteamUGC.Internal.StartItemUpdate(this.consumerAppId, this.fileId);
				if (handle == 0xffffffffffffffff)
					return result;

				if (this.Title != null) SteamUGC.Internal.SetItemTitle(handle, this.Title);
				if (this.Description != null) SteamUGC.Internal.SetItemDescription(handle, this.Description);
				if (this.MetaData != null) SteamUGC.Internal.SetItemMetadata(handle, this.MetaData);
				if (this.Language != null) SteamUGC.Internal.SetItemUpdateLanguage(handle, this.Language);
				if (this.ContentFolder != null) SteamUGC.Internal.SetItemContent(handle, this.ContentFolder.FullName);
				if (this.PreviewFile != null) SteamUGC.Internal.SetItemPreview(handle, this.PreviewFile);
				if (this.Visibility.HasValue) SteamUGC.Internal.SetItemVisibility(handle, this.Visibility.Value);
				if (this.Tags != null && this.Tags.Count > 0)
				{
					using (var a = SteamParamStringArray.From(this.Tags.ToArray()))
					{
						var val = a.Value;
						SteamUGC.Internal.SetItemTags(handle, ref val);
					}
				}

				if (this.KeyValueTagsToRemove != null)
				{
					foreach (var key in this.KeyValueTagsToRemove)
						SteamUGC.Internal.RemoveItemKeyValueTags(handle, key);
				}

				if (this.KeyValueTags != null)
				{
					foreach (var keyWithValues in this.KeyValueTags)
					{
						var key = keyWithValues.Key;
						foreach (var value in keyWithValues.Value)
							SteamUGC.Internal.AddItemKeyValueTag(handle, key, value);
					}
				}

				result.Result = Steamworks.Result.Fail;

				if (this.ChangeLog == null)
					this.ChangeLog = "";

				var updating = SteamUGC.Internal.SubmitItemUpdate(handle, this.ChangeLog);

				while (!updating.IsCompleted)
				{
					if (progress != null)
					{
						ulong total = 0;
						ulong processed = 0;

						var r = SteamUGC.Internal.GetItemUpdateProgress(handle, ref processed, ref total);

						switch (r)
						{
							case ItemUpdateStatus.PreparingConfig:
							{
								progress?.Report(0.1f);
								break;
							}

							case ItemUpdateStatus.PreparingContent:
							{
								progress?.Report(0.2f);
								break;
							}
							case ItemUpdateStatus.UploadingContent:
							{
								var uploaded = total > 0 ? ((float)processed / (float)total) : 0.0f;
								progress?.Report(0.2f + uploaded * 0.7f);
								break;
							}
							case ItemUpdateStatus.UploadingPreviewFile:
							{
								progress?.Report(0.8f);
								break;
							}
							case ItemUpdateStatus.CommittingChanges:
							{
								progress?.Report(1);
								break;
							}
						}
					}

					await Task.Delay(1000 / 60);
				}

				progress?.Report(1);

				var updated = updating.GetResult();

				if (!updated.HasValue) return result;

				result.Result = updated.Value.Result;

				if (result.Result != Steamworks.Result.OK)
					return result;

				result.NeedsWorkshopAgreement = updated.Value.UserNeedsToAcceptWorkshopLegalAgreement;
				result.FileId = this.fileId;

			}

			return result;
		}
	}

	public struct PublishResult
	{
		public bool Success => this.Result == Steamworks.Result.OK;

		public Steamworks.Result Result;
		public PublishedFileId FileId;

		/// <summary>
		/// https://partner.steamgames.com/doc/features/workshop/implementation#Legal
		/// </summary>
		public bool NeedsWorkshopAgreement;
	}
}