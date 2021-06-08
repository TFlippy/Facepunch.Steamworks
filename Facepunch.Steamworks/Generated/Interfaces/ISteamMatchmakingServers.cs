using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamMatchmakingServers : SteamInterface
	{
		
		public ISteamMatchmakingServers( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamMatchmakingServers_v002", CallingConvention = Platform.CC)]
		public static extern IntPtr SteamAPI_SteamMatchmakingServers_v002();
		public override IntPtr GetUserInterfacePointer() => SteamAPI_SteamMatchmakingServers_v002();
		
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestInternetServerList", CallingConvention = Platform.CC)]
		public static extern HServerListRequest _RequestInternetServerList( IntPtr self, AppId iApp, [In,Out] ref MatchMakingKeyValuePair[]  ppchFilters, uint nFilters, IntPtr pRequestServersResponse );
		
		#endregion
		public HServerListRequest RequestInternetServerList( AppId iApp, [In,Out] ref MatchMakingKeyValuePair[]  ppchFilters, uint nFilters, IntPtr pRequestServersResponse )
		{
			var returnValue = _RequestInternetServerList( Self, iApp, ref ppchFilters, nFilters, pRequestServersResponse );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestLANServerList", CallingConvention = Platform.CC)]
		public static extern HServerListRequest _RequestLANServerList( IntPtr self, AppId iApp, IntPtr pRequestServersResponse );
		
		#endregion
		public HServerListRequest RequestLANServerList( AppId iApp, IntPtr pRequestServersResponse )
		{
			var returnValue = _RequestLANServerList( Self, iApp, pRequestServersResponse );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList", CallingConvention = Platform.CC)]
		public static extern HServerListRequest _RequestFriendsServerList( IntPtr self, AppId iApp, [In,Out] ref MatchMakingKeyValuePair[]  ppchFilters, uint nFilters, IntPtr pRequestServersResponse );
		
		#endregion
		public HServerListRequest RequestFriendsServerList( AppId iApp, [In,Out] ref MatchMakingKeyValuePair[]  ppchFilters, uint nFilters, IntPtr pRequestServersResponse )
		{
			var returnValue = _RequestFriendsServerList( Self, iApp, ref ppchFilters, nFilters, pRequestServersResponse );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList", CallingConvention = Platform.CC)]
		public static extern HServerListRequest _RequestFavoritesServerList( IntPtr self, AppId iApp, [In,Out] ref MatchMakingKeyValuePair[]  ppchFilters, uint nFilters, IntPtr pRequestServersResponse );
		
		#endregion
		public HServerListRequest RequestFavoritesServerList( AppId iApp, [In,Out] ref MatchMakingKeyValuePair[]  ppchFilters, uint nFilters, IntPtr pRequestServersResponse )
		{
			var returnValue = _RequestFavoritesServerList( Self, iApp, ref ppchFilters, nFilters, pRequestServersResponse );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList", CallingConvention = Platform.CC)]
		public static extern HServerListRequest _RequestHistoryServerList( IntPtr self, AppId iApp, [In,Out] ref MatchMakingKeyValuePair[]  ppchFilters, uint nFilters, IntPtr pRequestServersResponse );
		
		#endregion
		public HServerListRequest RequestHistoryServerList( AppId iApp, [In,Out] ref MatchMakingKeyValuePair[]  ppchFilters, uint nFilters, IntPtr pRequestServersResponse )
		{
			var returnValue = _RequestHistoryServerList( Self, iApp, ref ppchFilters, nFilters, pRequestServersResponse );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList", CallingConvention = Platform.CC)]
		public static extern HServerListRequest _RequestSpectatorServerList( IntPtr self, AppId iApp, [In,Out] ref MatchMakingKeyValuePair[]  ppchFilters, uint nFilters, IntPtr pRequestServersResponse );
		
		#endregion
		public HServerListRequest RequestSpectatorServerList( AppId iApp, [In,Out] ref MatchMakingKeyValuePair[]  ppchFilters, uint nFilters, IntPtr pRequestServersResponse )
		{
			var returnValue = _RequestSpectatorServerList( Self, iApp, ref ppchFilters, nFilters, pRequestServersResponse );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_ReleaseRequest", CallingConvention = Platform.CC)]
		public static extern void _ReleaseRequest( IntPtr self, HServerListRequest hServerListRequest );
		
		#endregion
		public void ReleaseRequest( HServerListRequest hServerListRequest )
		{
			_ReleaseRequest( Self, hServerListRequest );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_GetServerDetails", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetServerDetails( IntPtr self, HServerListRequest hRequest, int iServer );
		
		#endregion
		public gameserveritem_t GetServerDetails( HServerListRequest hRequest, int iServer )
		{
			var returnValue = _GetServerDetails( Self, hRequest, iServer );
			return returnValue.ToMarshalledType<gameserveritem_t>();
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_CancelQuery", CallingConvention = Platform.CC)]
		public static extern void _CancelQuery( IntPtr self, HServerListRequest hRequest );
		
		#endregion
		public void CancelQuery( HServerListRequest hRequest )
		{
			_CancelQuery( Self, hRequest );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RefreshQuery", CallingConvention = Platform.CC)]
		public static extern void _RefreshQuery( IntPtr self, HServerListRequest hRequest );
		
		#endregion
		public void RefreshQuery( HServerListRequest hRequest )
		{
			_RefreshQuery( Self, hRequest );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_IsRefreshing", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _IsRefreshing( IntPtr self, HServerListRequest hRequest );
		
		#endregion
		public bool IsRefreshing( HServerListRequest hRequest )
		{
			var returnValue = _IsRefreshing( Self, hRequest );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_GetServerCount", CallingConvention = Platform.CC)]
		public static extern int _GetServerCount( IntPtr self, HServerListRequest hRequest );
		
		#endregion
		public int GetServerCount( HServerListRequest hRequest )
		{
			var returnValue = _GetServerCount( Self, hRequest );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RefreshServer", CallingConvention = Platform.CC)]
		public static extern void _RefreshServer( IntPtr self, HServerListRequest hRequest, int iServer );
		
		#endregion
		public void RefreshServer( HServerListRequest hRequest, int iServer )
		{
			_RefreshServer( Self, hRequest, iServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_PingServer", CallingConvention = Platform.CC)]
		public static extern HServerQuery _PingServer( IntPtr self, uint unIP, ushort usPort, IntPtr pRequestServersResponse );
		
		#endregion
		public HServerQuery PingServer( uint unIP, ushort usPort, IntPtr pRequestServersResponse )
		{
			var returnValue = _PingServer( Self, unIP, usPort, pRequestServersResponse );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_PlayerDetails", CallingConvention = Platform.CC)]
		public static extern HServerQuery _PlayerDetails( IntPtr self, uint unIP, ushort usPort, IntPtr pRequestServersResponse );
		
		#endregion
		public HServerQuery PlayerDetails( uint unIP, ushort usPort, IntPtr pRequestServersResponse )
		{
			var returnValue = _PlayerDetails( Self, unIP, usPort, pRequestServersResponse );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_ServerRules", CallingConvention = Platform.CC)]
		public static extern HServerQuery _ServerRules( IntPtr self, uint unIP, ushort usPort, IntPtr pRequestServersResponse );
		
		#endregion
		public HServerQuery ServerRules( uint unIP, ushort usPort, IntPtr pRequestServersResponse )
		{
			var returnValue = _ServerRules( Self, unIP, usPort, pRequestServersResponse );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMatchmakingServers_CancelServerQuery", CallingConvention = Platform.CC)]
		public static extern void _CancelServerQuery( IntPtr self, HServerQuery hServerQuery );
		
		#endregion
		public void CancelServerQuery( HServerQuery hServerQuery )
		{
			_CancelServerQuery( Self, hServerQuery );
		}
		
	}
}
