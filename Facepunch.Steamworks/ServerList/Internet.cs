using System;

namespace Steamworks.ServerList
{
	public class Internet: Base
	{
		public override void LaunchQuery()
		{
			var filters = this.GetFilters();

			this.request = Internal.RequestInternetServerList(this.AppId.Value, ref filters, (uint)filters.Length, IntPtr.Zero);
		}
	}
}