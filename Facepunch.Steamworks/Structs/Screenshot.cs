namespace Steamworks.Data
{
	public struct Screenshot
	{
		public ScreenshotHandle Value;

		/// <summary>
		/// Tags a user as being visible in the screenshot
		/// </summary>
		public bool TagUser(SteamId user)
		{
			return SteamScreenshots.Internal.TagUser(this.Value, user);
		}

		/// <summary>
		/// Tags a user as being visible in the screenshot
		/// </summary>
		public bool SetLocation(string location)
		{
			return SteamScreenshots.Internal.SetLocation(this.Value, location);
		}

		/// <summary>
		/// Tags a user as being visible in the screenshot
		/// </summary>
		public bool TagPublishedFile(PublishedFileId file)
		{
			return SteamScreenshots.Internal.TagPublishedFile(this.Value, file);
		}
	}
}