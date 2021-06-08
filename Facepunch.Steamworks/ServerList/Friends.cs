using System;

namespace Steamworks.ServerList
{
	public class Friends: Base
	{
		public override void LaunchQuery()
		{
			var filters = this.GetFilters();
			this.request = Internal.RequestFriendsServerList(this.AppId.Value, ref filters, (uint)filters.Length, IntPtr.Zero);
		}
	}
}