using System;

namespace Steamworks.ServerList
{
	public class Favourites: Base
	{
		public override void LaunchQuery()
		{
			var filters = this.GetFilters();
			this.request = Internal.RequestFavoritesServerList(this.AppId.Value, ref filters, (uint)filters.Length, IntPtr.Zero);
		}
	}
}