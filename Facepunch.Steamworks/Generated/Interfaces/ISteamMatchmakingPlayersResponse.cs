using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamMatchmakingPlayersResponse : SteamInterface
	{
		
		public ISteamMatchmakingPlayersResponse( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_AddPlayerToList", CallingConvention = Platform.CC)]
		private static extern void _AddPlayerToList( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, int nScore, float flTimePlayed );
		
		#endregion
		public void AddPlayerToList( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, int nScore, float flTimePlayed )
		{
			_AddPlayerToList( Self, pchName, nScore, flTimePlayed );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_PlayersFailedToRespond", CallingConvention = Platform.CC)]
		private static extern void _PlayersFailedToRespond( IntPtr self );
		
		#endregion
		public void PlayersFailedToRespond()
		{
			_PlayersFailedToRespond( Self );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_PlayersRefreshComplete", CallingConvention = Platform.CC)]
		private static extern void _PlayersRefreshComplete( IntPtr self );
		
		#endregion
		public void PlayersRefreshComplete()
		{
			_PlayersRefreshComplete( Self );
		}
		
	}
}
