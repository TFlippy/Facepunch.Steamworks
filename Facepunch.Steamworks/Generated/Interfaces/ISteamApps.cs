using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamApps : SteamInterface
	{
		
		public ISteamApps( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamApps_v008", CallingConvention = Platform.CC)]
		public static extern IntPtr SteamAPI_SteamApps_v008();
		public override IntPtr GetUserInterfacePointer() => SteamAPI_SteamApps_v008();
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamGameServerApps_v008", CallingConvention = Platform.CC)]
		public static extern IntPtr SteamAPI_SteamGameServerApps_v008();
		public override IntPtr GetServerInterfacePointer() => SteamAPI_SteamGameServerApps_v008();
		
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribed", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsSubscribed( IntPtr self );
		
		#endregion
		public bool BIsSubscribed()
		{
			var returnValue = _BIsSubscribed( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsLowViolence", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsLowViolence( IntPtr self );
		
		#endregion
		public bool BIsLowViolence()
		{
			var returnValue = _BIsLowViolence( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsCybercafe", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsCybercafe( IntPtr self );
		
		#endregion
		public bool BIsCybercafe()
		{
			var returnValue = _BIsCybercafe( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsVACBanned", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsVACBanned( IntPtr self );
		
		#endregion
		public bool BIsVACBanned()
		{
			var returnValue = _BIsVACBanned( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetCurrentGameLanguage", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetCurrentGameLanguage( IntPtr self );
		
		#endregion
		public string GetCurrentGameLanguage()
		{
			var returnValue = _GetCurrentGameLanguage( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetAvailableGameLanguages", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetAvailableGameLanguages( IntPtr self );
		
		#endregion
		public string GetAvailableGameLanguages()
		{
			var returnValue = _GetAvailableGameLanguages( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedApp", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsSubscribedApp( IntPtr self, AppId appID );
		
		#endregion
		public bool BIsSubscribedApp( AppId appID )
		{
			var returnValue = _BIsSubscribedApp( Self, appID );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsDlcInstalled", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsDlcInstalled( IntPtr self, AppId appID );
		
		#endregion
		public bool BIsDlcInstalled( AppId appID )
		{
			var returnValue = _BIsDlcInstalled( Self, appID );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetEarliestPurchaseUnixTime", CallingConvention = Platform.CC)]
		public static extern uint _GetEarliestPurchaseUnixTime( IntPtr self, AppId nAppID );
		
		#endregion
		public uint GetEarliestPurchaseUnixTime( AppId nAppID )
		{
			var returnValue = _GetEarliestPurchaseUnixTime( Self, nAppID );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedFromFreeWeekend", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsSubscribedFromFreeWeekend( IntPtr self );
		
		#endregion
		public bool BIsSubscribedFromFreeWeekend()
		{
			var returnValue = _BIsSubscribedFromFreeWeekend( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetDLCCount", CallingConvention = Platform.CC)]
		public static extern int _GetDLCCount( IntPtr self );
		
		#endregion
		public int GetDLCCount()
		{
			var returnValue = _GetDLCCount( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BGetDLCDataByIndex", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BGetDLCDataByIndex( IntPtr self, int iDLC, ref AppId pAppID, [MarshalAs( UnmanagedType.U1 )] ref bool pbAvailable, IntPtr pchName, int cchNameBufferSize );
		
		#endregion
		public bool BGetDLCDataByIndex( int iDLC, ref AppId pAppID, [MarshalAs( UnmanagedType.U1 )] ref bool pbAvailable, out string pchName )
		{
			IntPtr mempchName = Helpers.TakeMemory();
			var returnValue = _BGetDLCDataByIndex( Self, iDLC, ref pAppID, ref pbAvailable, mempchName, (1024 * 32) );
			pchName = Helpers.MemoryToString( mempchName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_InstallDLC", CallingConvention = Platform.CC)]
		public static extern void _InstallDLC( IntPtr self, AppId nAppID );
		
		#endregion
		public void InstallDLC( AppId nAppID )
		{
			_InstallDLC( Self, nAppID );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_UninstallDLC", CallingConvention = Platform.CC)]
		public static extern void _UninstallDLC( IntPtr self, AppId nAppID );
		
		#endregion
		public void UninstallDLC( AppId nAppID )
		{
			_UninstallDLC( Self, nAppID );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_RequestAppProofOfPurchaseKey", CallingConvention = Platform.CC)]
		public static extern void _RequestAppProofOfPurchaseKey( IntPtr self, AppId nAppID );
		
		#endregion
		public void RequestAppProofOfPurchaseKey( AppId nAppID )
		{
			_RequestAppProofOfPurchaseKey( Self, nAppID );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetCurrentBetaName", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetCurrentBetaName( IntPtr self, IntPtr pchName, int cchNameBufferSize );
		
		#endregion
		public bool GetCurrentBetaName( out string pchName )
		{
			IntPtr mempchName = Helpers.TakeMemory();
			var returnValue = _GetCurrentBetaName( Self, mempchName, (1024 * 32) );
			pchName = Helpers.MemoryToString( mempchName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_MarkContentCorrupt", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _MarkContentCorrupt( IntPtr self, [MarshalAs( UnmanagedType.U1 )] bool bMissingFilesOnly );
		
		#endregion
		public bool MarkContentCorrupt( [MarshalAs( UnmanagedType.U1 )] bool bMissingFilesOnly )
		{
			var returnValue = _MarkContentCorrupt( Self, bMissingFilesOnly );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetInstalledDepots", CallingConvention = Platform.CC)]
		public static extern uint _GetInstalledDepots( IntPtr self, AppId appID, [In,Out] DepotId_t[]  pvecDepots, uint cMaxDepots );
		
		#endregion
		public uint GetInstalledDepots( AppId appID, [In,Out] DepotId_t[]  pvecDepots, uint cMaxDepots )
		{
			var returnValue = _GetInstalledDepots( Self, appID, pvecDepots, cMaxDepots );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetAppInstallDir", CallingConvention = Platform.CC)]
		public static extern uint _GetAppInstallDir( IntPtr self, AppId appID, IntPtr pchFolder, uint cchFolderBufferSize );
		
		#endregion
		public uint GetAppInstallDir( AppId appID, out string pchFolder )
		{
			IntPtr mempchFolder = Helpers.TakeMemory();
			var returnValue = _GetAppInstallDir( Self, appID, mempchFolder, (1024 * 32) );
			pchFolder = Helpers.MemoryToString( mempchFolder );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsAppInstalled", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsAppInstalled( IntPtr self, AppId appID );
		
		#endregion
		public bool BIsAppInstalled( AppId appID )
		{
			var returnValue = _BIsAppInstalled( Self, appID );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetAppOwner", CallingConvention = Platform.CC)]
		public static extern SteamId _GetAppOwner( IntPtr self );
		
		#endregion
		public SteamId GetAppOwner()
		{
			var returnValue = _GetAppOwner( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetLaunchQueryParam", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetLaunchQueryParam( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchKey );
		
		#endregion
		public string GetLaunchQueryParam( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchKey )
		{
			var returnValue = _GetLaunchQueryParam( Self, pchKey );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetDlcDownloadProgress", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetDlcDownloadProgress( IntPtr self, AppId nAppID, ref ulong punBytesDownloaded, ref ulong punBytesTotal );
		
		#endregion
		public bool GetDlcDownloadProgress( AppId nAppID, ref ulong punBytesDownloaded, ref ulong punBytesTotal )
		{
			var returnValue = _GetDlcDownloadProgress( Self, nAppID, ref punBytesDownloaded, ref punBytesTotal );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetAppBuildId", CallingConvention = Platform.CC)]
		public static extern int _GetAppBuildId( IntPtr self );
		
		#endregion
		public int GetAppBuildId()
		{
			var returnValue = _GetAppBuildId( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_RequestAllProofOfPurchaseKeys", CallingConvention = Platform.CC)]
		public static extern void _RequestAllProofOfPurchaseKeys( IntPtr self );
		
		#endregion
		public void RequestAllProofOfPurchaseKeys()
		{
			_RequestAllProofOfPurchaseKeys( Self );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetFileDetails", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _GetFileDetails( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszFileName );
		
		#endregion
		public CallResult<FileDetailsResult_t> GetFileDetails( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszFileName )
		{
			var returnValue = _GetFileDetails( Self, pszFileName );
			return new CallResult<FileDetailsResult_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_GetLaunchCommandLine", CallingConvention = Platform.CC)]
		public static extern int _GetLaunchCommandLine( IntPtr self, IntPtr pszCommandLine, int cubCommandLine );
		
		#endregion
		public int GetLaunchCommandLine( out string pszCommandLine )
		{
			IntPtr mempszCommandLine = Helpers.TakeMemory();
			var returnValue = _GetLaunchCommandLine( Self, mempszCommandLine, (1024 * 32) );
			pszCommandLine = Helpers.MemoryToString( mempszCommandLine );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedFromFamilySharing", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsSubscribedFromFamilySharing( IntPtr self );
		
		#endregion
		public bool BIsSubscribedFromFamilySharing()
		{
			var returnValue = _BIsSubscribedFromFamilySharing( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamApps_BIsTimedTrial", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsTimedTrial( IntPtr self, ref uint punSecondsAllowed, ref uint punSecondsPlayed );
		
		#endregion
		public bool BIsTimedTrial( ref uint punSecondsAllowed, ref uint punSecondsPlayed )
		{
			var returnValue = _BIsTimedTrial( Self, ref punSecondsAllowed, ref punSecondsPlayed );
			return returnValue;
		}
		
	}
}
