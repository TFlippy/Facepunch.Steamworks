using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamMatchmakingPingResponse : SteamInterface
	{
		
		public ISteamMatchmakingPingResponse( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingPingResponse_ServerResponded", CallingConvention = Platform.CC)]
		private static extern void _ServerResponded( IntPtr self, ref gameserveritem_t server );
		
		#endregion
		public void ServerResponded( ref gameserveritem_t server )
		{
			_ServerResponded( Self, ref server );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingPingResponse_ServerFailedToRespond", CallingConvention = Platform.CC)]
		private static extern void _ServerFailedToRespond( IntPtr self );
		
		#endregion
		public void ServerFailedToRespond()
		{
			_ServerFailedToRespond( Self );
		}
		
	}
}
