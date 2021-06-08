using System;

namespace Steamworks.ServerList
{
	public class LocalNetwork: Base
	{
		public override void LaunchQuery()
		{
			this.request = Internal.RequestLANServerList(this.AppId.Value, IntPtr.Zero);
		}
	}
}