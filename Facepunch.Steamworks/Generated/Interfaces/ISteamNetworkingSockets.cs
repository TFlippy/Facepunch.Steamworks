using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamNetworkingSockets : SteamInterface
	{
		
		public ISteamNetworkingSockets( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamNetworkingSockets_SteamAPI_v009", CallingConvention = Platform.CC)]
		public static extern IntPtr SteamAPI_SteamNetworkingSockets_SteamAPI_v009();
		public override IntPtr GetUserInterfacePointer() => SteamAPI_SteamNetworkingSockets_SteamAPI_v009();
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameServerNetworkingSockets_SteamAPI_v009", CallingConvention = Platform.CC)]
		public static extern IntPtr SteamAPI_SteamGameServerNetworkingSockets_SteamAPI_v009();
		public override IntPtr GetServerInterfacePointer() => SteamAPI_SteamGameServerNetworkingSockets_SteamAPI_v009();
		
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateListenSocketIP", CallingConvention = Platform.CC)]
		public static extern Socket _CreateListenSocketIP( IntPtr self, ref NetAddress localAddress, int nOptions, [In,Out] NetKeyValue[]  pOptions );
		
		#endregion
		public Socket CreateListenSocketIP( ref NetAddress localAddress, int nOptions, [In,Out] NetKeyValue[]  pOptions )
		{
			var returnValue = _CreateListenSocketIP( Self, ref localAddress, nOptions, pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectByIPAddress", CallingConvention = Platform.CC)]
		public static extern Connection _ConnectByIPAddress( IntPtr self, ref NetAddress address, int nOptions, [In,Out] NetKeyValue[]  pOptions );
		
		#endregion
		public Connection ConnectByIPAddress( ref NetAddress address, int nOptions, [In,Out] NetKeyValue[]  pOptions )
		{
			var returnValue = _ConnectByIPAddress( Self, ref address, nOptions, pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2P", CallingConvention = Platform.CC)]
		public static extern Socket _CreateListenSocketP2P( IntPtr self, int nLocalVirtualPort, int nOptions, [In,Out] NetKeyValue[]  pOptions );
		
		#endregion
		public Socket CreateListenSocketP2P( int nLocalVirtualPort, int nOptions, [In,Out] NetKeyValue[]  pOptions )
		{
			var returnValue = _CreateListenSocketP2P( Self, nLocalVirtualPort, nOptions, pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectP2P", CallingConvention = Platform.CC)]
		public static extern Connection _ConnectP2P( IntPtr self, ref NetIdentity identityRemote, int nRemoteVirtualPort, int nOptions, [In,Out] NetKeyValue[]  pOptions );
		
		#endregion
		public Connection ConnectP2P( ref NetIdentity identityRemote, int nRemoteVirtualPort, int nOptions, [In,Out] NetKeyValue[]  pOptions )
		{
			var returnValue = _ConnectP2P( Self, ref identityRemote, nRemoteVirtualPort, nOptions, pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_AcceptConnection", CallingConvention = Platform.CC)]
		public static extern Result _AcceptConnection( IntPtr self, Connection hConn );
		
		#endregion
		public Result AcceptConnection( Connection hConn )
		{
			var returnValue = _AcceptConnection( Self, hConn );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CloseConnection", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _CloseConnection( IntPtr self, Connection hPeer, int nReason, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszDebug, [MarshalAs( UnmanagedType.U1 )] bool bEnableLinger );
		
		#endregion
		public bool CloseConnection( Connection hPeer, int nReason, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszDebug, [MarshalAs( UnmanagedType.U1 )] bool bEnableLinger )
		{
			var returnValue = _CloseConnection( Self, hPeer, nReason, pszDebug, bEnableLinger );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CloseListenSocket", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _CloseListenSocket( IntPtr self, Socket hSocket );
		
		#endregion
		public bool CloseListenSocket( Socket hSocket )
		{
			var returnValue = _CloseListenSocket( Self, hSocket );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetConnectionUserData", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _SetConnectionUserData( IntPtr self, Connection hPeer, long nUserData );
		
		#endregion
		public bool SetConnectionUserData( Connection hPeer, long nUserData )
		{
			var returnValue = _SetConnectionUserData( Self, hPeer, nUserData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetConnectionUserData", CallingConvention = Platform.CC)]
		public static extern long _GetConnectionUserData( IntPtr self, Connection hPeer );
		
		#endregion
		public long GetConnectionUserData( Connection hPeer )
		{
			var returnValue = _GetConnectionUserData( Self, hPeer );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetConnectionName", CallingConvention = Platform.CC)]
		public static extern void _SetConnectionName( IntPtr self, Connection hPeer, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszName );
		
		#endregion
		public void SetConnectionName( Connection hPeer, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszName )
		{
			_SetConnectionName( Self, hPeer, pszName );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetConnectionName", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetConnectionName( IntPtr self, Connection hPeer, IntPtr pszName, int nMaxLen );
		
		#endregion
		public bool GetConnectionName( Connection hPeer, out string pszName )
		{
			IntPtr mempszName = Helpers.TakeMemory();
			var returnValue = _GetConnectionName( Self, hPeer, mempszName, (1024 * 32) );
			pszName = Helpers.MemoryToString( mempszName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SendMessageToConnection", CallingConvention = Platform.CC)]
		public static extern Result _SendMessageToConnection( IntPtr self, Connection hConn, IntPtr pData, uint cbData, int nSendFlags, ref long pOutMessageNumber );
		
		#endregion
		public Result SendMessageToConnection( Connection hConn, IntPtr pData, uint cbData, int nSendFlags, ref long pOutMessageNumber )
		{
			var returnValue = _SendMessageToConnection( Self, hConn, pData, cbData, nSendFlags, ref pOutMessageNumber );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SendMessages", CallingConvention = Platform.CC)]
		public static unsafe extern void _SendMessages( IntPtr self, int nMessages, NetMsg** pMessages, long* pOutMessageNumberOrResult );

		#endregion
		public unsafe void SendMessages( int nMessages, NetMsg** pMessages, long* pOutMessageNumberOrResult )
		{
			_SendMessages( Self, nMessages, pMessages, pOutMessageNumberOrResult );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_FlushMessagesOnConnection", CallingConvention = Platform.CC)]
		public static extern Result _FlushMessagesOnConnection( IntPtr self, Connection hConn );
		
		#endregion
		public Result FlushMessagesOnConnection( Connection hConn )
		{
			var returnValue = _FlushMessagesOnConnection( Self, hConn );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnConnection", CallingConvention = Platform.CC)]
		public static extern int _ReceiveMessagesOnConnection( IntPtr self, Connection hConn, IntPtr ppOutMessages, int nMaxMessages );
		
		#endregion
		public int ReceiveMessagesOnConnection( Connection hConn, IntPtr ppOutMessages, int nMaxMessages )
		{
			var returnValue = _ReceiveMessagesOnConnection( Self, hConn, ppOutMessages, nMaxMessages );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetConnectionInfo", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetConnectionInfo( IntPtr self, Connection hConn, ref ConnectionInfo pInfo );
		
		#endregion
		public bool GetConnectionInfo( Connection hConn, ref ConnectionInfo pInfo )
		{
			var returnValue = _GetConnectionInfo( Self, hConn, ref pInfo );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetQuickConnectionStatus", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetQuickConnectionStatus( IntPtr self, Connection hConn, ref ConnectionStatus pStats );
		
		#endregion
		public bool GetQuickConnectionStatus( Connection hConn, ref ConnectionStatus pStats )
		{
			var returnValue = _GetQuickConnectionStatus( Self, hConn, ref pStats );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetDetailedConnectionStatus", CallingConvention = Platform.CC)]
		public static extern int _GetDetailedConnectionStatus( IntPtr self, Connection hConn, IntPtr pszBuf, int cbBuf );
		
		#endregion
		public int GetDetailedConnectionStatus( Connection hConn, out string pszBuf )
		{
			IntPtr mempszBuf = Helpers.TakeMemory();
			var returnValue = _GetDetailedConnectionStatus( Self, hConn, mempszBuf, (1024 * 32) );
			pszBuf = Helpers.MemoryToString( mempszBuf );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetListenSocketAddress", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetListenSocketAddress( IntPtr self, Socket hSocket, ref NetAddress address );
		
		#endregion
		public bool GetListenSocketAddress( Socket hSocket, ref NetAddress address )
		{
			var returnValue = _GetListenSocketAddress( Self, hSocket, ref address );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateSocketPair", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _CreateSocketPair( IntPtr self, [In,Out] Connection[]  pOutConnection1, [In,Out] Connection[]  pOutConnection2, [MarshalAs( UnmanagedType.U1 )] bool bUseNetworkLoopback, ref NetIdentity pIdentity1, ref NetIdentity pIdentity2 );
		
		#endregion
		public bool CreateSocketPair( [In,Out] Connection[]  pOutConnection1, [In,Out] Connection[]  pOutConnection2, [MarshalAs( UnmanagedType.U1 )] bool bUseNetworkLoopback, ref NetIdentity pIdentity1, ref NetIdentity pIdentity2 )
		{
			var returnValue = _CreateSocketPair( Self, pOutConnection1, pOutConnection2, bUseNetworkLoopback, ref pIdentity1, ref pIdentity2 );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetIdentity", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetIdentity( IntPtr self, ref NetIdentity pIdentity );
		
		#endregion
		public bool GetIdentity( ref NetIdentity pIdentity )
		{
			var returnValue = _GetIdentity( Self, ref pIdentity );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_InitAuthentication", CallingConvention = Platform.CC)]
		public static extern SteamNetworkingAvailability _InitAuthentication( IntPtr self );
		
		#endregion
		public SteamNetworkingAvailability InitAuthentication()
		{
			var returnValue = _InitAuthentication( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetAuthenticationStatus", CallingConvention = Platform.CC)]
		public static extern SteamNetworkingAvailability _GetAuthenticationStatus( IntPtr self, ref SteamNetAuthenticationStatus_t pDetails );
		
		#endregion
		public SteamNetworkingAvailability GetAuthenticationStatus( ref SteamNetAuthenticationStatus_t pDetails )
		{
			var returnValue = _GetAuthenticationStatus( Self, ref pDetails );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreatePollGroup", CallingConvention = Platform.CC)]
		public static extern HSteamNetPollGroup _CreatePollGroup( IntPtr self );
		
		#endregion
		public HSteamNetPollGroup CreatePollGroup()
		{
			var returnValue = _CreatePollGroup( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_DestroyPollGroup", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _DestroyPollGroup( IntPtr self, HSteamNetPollGroup hPollGroup );
		
		#endregion
		public bool DestroyPollGroup( HSteamNetPollGroup hPollGroup )
		{
			var returnValue = _DestroyPollGroup( Self, hPollGroup );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetConnectionPollGroup", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _SetConnectionPollGroup( IntPtr self, Connection hConn, HSteamNetPollGroup hPollGroup );
		
		#endregion
		public bool SetConnectionPollGroup( Connection hConn, HSteamNetPollGroup hPollGroup )
		{
			var returnValue = _SetConnectionPollGroup( Self, hConn, hPollGroup );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnPollGroup", CallingConvention = Platform.CC)]
		public static extern int _ReceiveMessagesOnPollGroup( IntPtr self, HSteamNetPollGroup hPollGroup, IntPtr ppOutMessages, int nMaxMessages );
		
		#endregion
		public int ReceiveMessagesOnPollGroup( HSteamNetPollGroup hPollGroup, IntPtr ppOutMessages, int nMaxMessages )
		{
			var returnValue = _ReceiveMessagesOnPollGroup( Self, hPollGroup, ppOutMessages, nMaxMessages );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceivedRelayAuthTicket", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _ReceivedRelayAuthTicket( IntPtr self, IntPtr pvTicket, int cbTicket, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket );
		
		#endregion
		public bool ReceivedRelayAuthTicket( IntPtr pvTicket, int cbTicket, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket )
		{
			var returnValue = _ReceivedRelayAuthTicket( Self, pvTicket, cbTicket, pOutParsedTicket );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_FindRelayAuthTicketForServer", CallingConvention = Platform.CC)]
		public static extern int _FindRelayAuthTicketForServer( IntPtr self, ref NetIdentity identityGameServer, int nRemoteVirtualPort, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket );
		
		#endregion
		public int FindRelayAuthTicketForServer( ref NetIdentity identityGameServer, int nRemoteVirtualPort, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket )
		{
			var returnValue = _FindRelayAuthTicketForServer( Self, ref identityGameServer, nRemoteVirtualPort, pOutParsedTicket );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectToHostedDedicatedServer", CallingConvention = Platform.CC)]
		public static extern Connection _ConnectToHostedDedicatedServer( IntPtr self, ref NetIdentity identityTarget, int nRemoteVirtualPort, int nOptions, [In,Out] NetKeyValue[]  pOptions );
		
		#endregion
		public Connection ConnectToHostedDedicatedServer( ref NetIdentity identityTarget, int nRemoteVirtualPort, int nOptions, [In,Out] NetKeyValue[]  pOptions )
		{
			var returnValue = _ConnectToHostedDedicatedServer( Self, ref identityTarget, nRemoteVirtualPort, nOptions, pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPort", CallingConvention = Platform.CC)]
		public static extern ushort _GetHostedDedicatedServerPort( IntPtr self );
		
		#endregion
		public ushort GetHostedDedicatedServerPort()
		{
			var returnValue = _GetHostedDedicatedServerPort( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPOPID", CallingConvention = Platform.CC)]
		public static extern SteamNetworkingPOPID _GetHostedDedicatedServerPOPID( IntPtr self );
		
		#endregion
		public SteamNetworkingPOPID GetHostedDedicatedServerPOPID()
		{
			var returnValue = _GetHostedDedicatedServerPOPID( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerAddress", CallingConvention = Platform.CC)]
		public static extern Result _GetHostedDedicatedServerAddress( IntPtr self, ref SteamDatagramHostedAddress pRouting );
		
		#endregion
		public Result GetHostedDedicatedServerAddress( ref SteamDatagramHostedAddress pRouting )
		{
			var returnValue = _GetHostedDedicatedServerAddress( Self, ref pRouting );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateHostedDedicatedServerListenSocket", CallingConvention = Platform.CC)]
		public static extern Socket _CreateHostedDedicatedServerListenSocket( IntPtr self, int nLocalVirtualPort, int nOptions, [In,Out] NetKeyValue[]  pOptions );
		
		#endregion
		public Socket CreateHostedDedicatedServerListenSocket( int nLocalVirtualPort, int nOptions, [In,Out] NetKeyValue[]  pOptions )
		{
			var returnValue = _CreateHostedDedicatedServerListenSocket( Self, nLocalVirtualPort, nOptions, pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetGameCoordinatorServerLogin", CallingConvention = Platform.CC)]
		public static extern Result _GetGameCoordinatorServerLogin( IntPtr self, ref SteamDatagramGameCoordinatorServerLogin pLoginInfo, ref int pcbSignedBlob, IntPtr pBlob );
		
		#endregion
		public Result GetGameCoordinatorServerLogin( ref SteamDatagramGameCoordinatorServerLogin pLoginInfo, ref int pcbSignedBlob, IntPtr pBlob )
		{
			var returnValue = _GetGameCoordinatorServerLogin( Self, ref pLoginInfo, ref pcbSignedBlob, pBlob );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectP2PCustomSignaling", CallingConvention = Platform.CC)]
		public static extern Connection _ConnectP2PCustomSignaling( IntPtr self, IntPtr pSignaling, ref NetIdentity pPeerIdentity, int nRemoteVirtualPort, int nOptions, [In,Out] NetKeyValue[]  pOptions );
		
		#endregion
		public Connection ConnectP2PCustomSignaling( IntPtr pSignaling, ref NetIdentity pPeerIdentity, int nRemoteVirtualPort, int nOptions, [In,Out] NetKeyValue[]  pOptions )
		{
			var returnValue = _ConnectP2PCustomSignaling( Self, pSignaling, ref pPeerIdentity, nRemoteVirtualPort, nOptions, pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceivedP2PCustomSignal", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _ReceivedP2PCustomSignal( IntPtr self, IntPtr pMsg, int cbMsg, IntPtr pContext );
		
		#endregion
		public bool ReceivedP2PCustomSignal( IntPtr pMsg, int cbMsg, IntPtr pContext )
		{
			var returnValue = _ReceivedP2PCustomSignal( Self, pMsg, cbMsg, pContext );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetCertificateRequest", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetCertificateRequest( IntPtr self, ref int pcbBlob, IntPtr pBlob, ref NetErrorMessage errMsg );
		
		#endregion
		public bool GetCertificateRequest( ref int pcbBlob, IntPtr pBlob, ref NetErrorMessage errMsg )
		{
			var returnValue = _GetCertificateRequest( Self, ref pcbBlob, pBlob, ref errMsg );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetCertificate", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _SetCertificate( IntPtr self, IntPtr pCertificate, int cbCertificate, ref NetErrorMessage errMsg );
		
		#endregion
		public bool SetCertificate( IntPtr pCertificate, int cbCertificate, ref NetErrorMessage errMsg )
		{
			var returnValue = _SetCertificate( Self, pCertificate, cbCertificate, ref errMsg );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_RunCallbacks", CallingConvention = Platform.CC)]
		public static extern void _RunCallbacks( IntPtr self );
		
		#endregion
		public void RunCallbacks()
		{
			_RunCallbacks( Self );
		}
		
	}
}
