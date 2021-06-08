using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamMatchmakingRulesResponse : SteamInterface
	{
		
		public ISteamMatchmakingRulesResponse( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded", CallingConvention = Platform.CC)]
		public static extern void _RulesResponded( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchRule, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchValue );
		
		#endregion
		public void RulesResponded( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchRule, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchValue )
		{
			_RulesResponded( Self, pchRule, pchValue );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond", CallingConvention = Platform.CC)]
		public static extern void _RulesFailedToRespond( IntPtr self );
		
		#endregion
		public void RulesFailedToRespond()
		{
			_RulesFailedToRespond( Self );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete", CallingConvention = Platform.CC)]
		public static extern void _RulesRefreshComplete( IntPtr self );
		
		#endregion
		public void RulesRefreshComplete()
		{
			_RulesRefreshComplete( Self );
		}
		
	}
}
