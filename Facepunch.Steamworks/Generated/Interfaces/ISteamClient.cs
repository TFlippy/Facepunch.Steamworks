using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamClient : SteamInterface
	{
		
		public ISteamClient( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_CreateSteamPipe", CallingConvention = Platform.CC)]
		public static extern HSteamPipe _CreateSteamPipe( IntPtr self );
		
		#endregion
		public HSteamPipe CreateSteamPipe()
		{
			var returnValue = _CreateSteamPipe( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_BReleaseSteamPipe", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BReleaseSteamPipe( IntPtr self, HSteamPipe hSteamPipe );
		
		#endregion
		public bool BReleaseSteamPipe( HSteamPipe hSteamPipe )
		{
			var returnValue = _BReleaseSteamPipe( Self, hSteamPipe );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_ConnectToGlobalUser", CallingConvention = Platform.CC)]
		public static extern HSteamUser _ConnectToGlobalUser( IntPtr self, HSteamPipe hSteamPipe );
		
		#endregion
		public HSteamUser ConnectToGlobalUser( HSteamPipe hSteamPipe )
		{
			var returnValue = _ConnectToGlobalUser( Self, hSteamPipe );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_CreateLocalUser", CallingConvention = Platform.CC)]
		public static extern HSteamUser _CreateLocalUser( IntPtr self, ref HSteamPipe phSteamPipe, AccountType eAccountType );
		
		#endregion
		public HSteamUser CreateLocalUser( ref HSteamPipe phSteamPipe, AccountType eAccountType )
		{
			var returnValue = _CreateLocalUser( Self, ref phSteamPipe, eAccountType );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_ReleaseUser", CallingConvention = Platform.CC)]
		public static extern void _ReleaseUser( IntPtr self, HSteamPipe hSteamPipe, HSteamUser hUser );
		
		#endregion
		public void ReleaseUser( HSteamPipe hSteamPipe, HSteamUser hUser )
		{
			_ReleaseUser( Self, hSteamPipe, hUser );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamUser", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamUser( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamUser( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamUser( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServer", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamGameServer( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamGameServer( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamGameServer( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_SetLocalIPBinding", CallingConvention = Platform.CC)]
		public static extern void _SetLocalIPBinding( IntPtr self, ref SteamIPAddress unIP, ushort usPort );
		
		#endregion
		public void SetLocalIPBinding( ref SteamIPAddress unIP, ushort usPort )
		{
			_SetLocalIPBinding( Self, ref unIP, usPort );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamFriends", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamFriends( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamFriends( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamFriends( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamUtils", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamUtils( IntPtr self, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamUtils( HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamUtils( Self, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmaking", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamMatchmaking( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamMatchmaking( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamMatchmaking( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmakingServers", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamMatchmakingServers( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamMatchmakingServers( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamMatchmakingServers( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamGenericInterface", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamGenericInterface( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamGenericInterface( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamGenericInterface( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamUserStats", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamUserStats( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamUserStats( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamUserStats( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServerStats", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamGameServerStats( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamGameServerStats( HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamGameServerStats( Self, hSteamuser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamApps", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamApps( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamApps( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamApps( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamNetworking", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamNetworking( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamNetworking( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamNetworking( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamRemoteStorage", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamRemoteStorage( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamRemoteStorage( HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamRemoteStorage( Self, hSteamuser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamScreenshots", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamScreenshots( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamScreenshots( HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamScreenshots( Self, hSteamuser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameSearch", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamGameSearch( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamGameSearch( HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamGameSearch( Self, hSteamuser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetIPCCallCount", CallingConvention = Platform.CC)]
		public static extern uint _GetIPCCallCount( IntPtr self );
		
		#endregion
		public uint GetIPCCallCount()
		{
			var returnValue = _GetIPCCallCount( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_SetWarningMessageHook", CallingConvention = Platform.CC)]
		public static extern void _SetWarningMessageHook( IntPtr self, IntPtr pFunction );
		
		#endregion
		public void SetWarningMessageHook( IntPtr pFunction )
		{
			_SetWarningMessageHook( Self, pFunction );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_BShutdownIfAllPipesClosed", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BShutdownIfAllPipesClosed( IntPtr self );
		
		#endregion
		public bool BShutdownIfAllPipesClosed()
		{
			var returnValue = _BShutdownIfAllPipesClosed( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamHTTP", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamHTTP( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamHTTP( HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamHTTP( Self, hSteamuser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamController", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamController( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamController( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamController( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamUGC", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamUGC( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamUGC( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamUGC( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamAppList", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamAppList( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamAppList( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamAppList( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamMusic", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamMusic( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamMusic( HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamMusic( Self, hSteamuser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamMusicRemote", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamMusicRemote( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamMusicRemote( HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamMusicRemote( Self, hSteamuser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamHTMLSurface", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamHTMLSurface( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamHTMLSurface( HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamHTMLSurface( Self, hSteamuser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamInventory", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamInventory( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamInventory( HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamInventory( Self, hSteamuser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamVideo", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamVideo( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamVideo( HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamVideo( Self, hSteamuser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamParentalSettings", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamParentalSettings( IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamParentalSettings( HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamParentalSettings( Self, hSteamuser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamInput", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamInput( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamInput( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamInput( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamParties", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamParties( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamParties( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamParties( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamClient_GetISteamRemotePlay", CallingConvention = Platform.CC)]
		public static extern IntPtr _GetISteamRemotePlay( IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion );
		
		#endregion
		public IntPtr GetISteamRemotePlay( HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchVersion )
		{
			var returnValue = _GetISteamRemotePlay( Self, hSteamUser, hSteamPipe, pchVersion );
			return returnValue;
		}
		
	}
}
