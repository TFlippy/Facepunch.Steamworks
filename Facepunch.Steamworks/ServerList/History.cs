using System;

namespace Steamworks.ServerList
{
	public class History: Base
	{
		public override void LaunchQuery()
		{
			var filters = this.GetFilters();
			this.request = Internal.RequestHistoryServerList(this.AppId.Value, ref filters, (uint)filters.Length, IntPtr.Zero);
		}
	}
}