using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamUserStats : SteamInterface
	{
		
		public ISteamUserStats( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamUserStats_v012", CallingConvention = Platform.CC)]
		public static extern IntPtr SteamAPI_SteamUserStats_v012();
		public override IntPtr GetUserInterfacePointer() => SteamAPI_SteamUserStats_v012();
		
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_RequestCurrentStats", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _RequestCurrentStats( IntPtr self );
		
		#endregion
		public bool RequestCurrentStats()
		{
			var returnValue = _RequestCurrentStats( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetStatInt32", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetStat( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref int pData );
		
		#endregion
		public bool GetStat( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref int pData )
		{
			var returnValue = _GetStat( Self, pchName, ref pData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetStatFloat", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetStat( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref float pData );
		
		#endregion
		public bool GetStat( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref float pData )
		{
			var returnValue = _GetStat( Self, pchName, ref pData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_SetStatInt32", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _SetStat( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, int nData );
		
		#endregion
		public bool SetStat( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, int nData )
		{
			var returnValue = _SetStat( Self, pchName, nData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_SetStatFloat", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _SetStat( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, float fData );
		
		#endregion
		public bool SetStat( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, float fData )
		{
			var returnValue = _SetStat( Self, pchName, fData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_UpdateAvgRateStat", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _UpdateAvgRateStat( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, float flCountThisSession, double dSessionLength );
		
		#endregion
		public bool UpdateAvgRateStat( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, float flCountThisSession, double dSessionLength )
		{
			var returnValue = _UpdateAvgRateStat( Self, pchName, flCountThisSession, dSessionLength );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievement", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetAchievement( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved );
		
		#endregion
		public bool GetAchievement( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved )
		{
			var returnValue = _GetAchievement( Self, pchName, ref pbAchieved );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_SetAchievement", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _SetAchievement( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName );
		
		#endregion
		public bool SetAchievement( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName )
		{
			var returnValue = _SetAchievement( Self, pchName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_ClearAchievement", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _ClearAchievement( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName );
		
		#endregion
		public bool ClearAchievement( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName )
		{
			var returnValue = _ClearAchievement( Self, pchName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetAchievementAndUnlockTime( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved, ref uint punUnlockTime );
		
		#endregion
		public bool GetAchievementAndUnlockTime( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved, ref uint punUnlockTime )
		{
			var returnValue = _GetAchievementAndUnlockTime( Self, pchName, ref pbAchieved, ref punUnlockTime );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_StoreStats", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _StoreStats( IntPtr self );
		
		#endregion
		public bool StoreStats()
		{
			var returnValue = _StoreStats( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementIcon", CallingConvention = Platform.CC)]
		public static extern int _GetAchievementIcon( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName );
		
		#endregion
		public int GetAchievementIcon( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName )
		{
			var returnValue = _GetAchievementIcon( Self, pchName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetAchievementDisplayAttribute( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchKey );
		
		#endregion
		public string GetAchievementDisplayAttribute( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchKey )
		{
			var returnValue = _GetAchievementDisplayAttribute( Self, pchName, pchKey );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_IndicateAchievementProgress", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _IndicateAchievementProgress( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, uint nCurProgress, uint nMaxProgress );
		
		#endregion
		public bool IndicateAchievementProgress( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, uint nCurProgress, uint nMaxProgress )
		{
			var returnValue = _IndicateAchievementProgress( Self, pchName, nCurProgress, nMaxProgress );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetNumAchievements", CallingConvention = Platform.CC)]
		public static extern uint _GetNumAchievements( IntPtr self );
		
		#endregion
		public uint GetNumAchievements()
		{
			var returnValue = _GetNumAchievements( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementName", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetAchievementName( IntPtr self, uint iAchievement );
		
		#endregion
		public string GetAchievementName( uint iAchievement )
		{
			var returnValue = _GetAchievementName( Self, iAchievement );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_RequestUserStats", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _RequestUserStats( IntPtr self, SteamId steamIDUser );
		
		#endregion
		public CallResult<UserStatsReceived_t> RequestUserStats( SteamId steamIDUser )
		{
			var returnValue = _RequestUserStats( Self, steamIDUser );
			return new CallResult<UserStatsReceived_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetUserStatInt32", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetUserStat( IntPtr self, SteamId steamIDUser, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref int pData );
		
		#endregion
		public bool GetUserStat( SteamId steamIDUser, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref int pData )
		{
			var returnValue = _GetUserStat( Self, steamIDUser, pchName, ref pData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetUserStatFloat", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetUserStat( IntPtr self, SteamId steamIDUser, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref float pData );
		
		#endregion
		public bool GetUserStat( SteamId steamIDUser, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref float pData )
		{
			var returnValue = _GetUserStat( Self, steamIDUser, pchName, ref pData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetUserAchievement", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetUserAchievement( IntPtr self, SteamId steamIDUser, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved );
		
		#endregion
		public bool GetUserAchievement( SteamId steamIDUser, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved )
		{
			var returnValue = _GetUserAchievement( Self, steamIDUser, pchName, ref pbAchieved );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetUserAchievementAndUnlockTime( IntPtr self, SteamId steamIDUser, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved, ref uint punUnlockTime );
		
		#endregion
		public bool GetUserAchievementAndUnlockTime( SteamId steamIDUser, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved, ref uint punUnlockTime )
		{
			var returnValue = _GetUserAchievementAndUnlockTime( Self, steamIDUser, pchName, ref pbAchieved, ref punUnlockTime );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_ResetAllStats", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _ResetAllStats( IntPtr self, [MarshalAs( UnmanagedType.U1 )] bool bAchievementsToo );
		
		#endregion
		public bool ResetAllStats( [MarshalAs( UnmanagedType.U1 )] bool bAchievementsToo )
		{
			var returnValue = _ResetAllStats( Self, bAchievementsToo );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_FindOrCreateLeaderboard", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _FindOrCreateLeaderboard( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchLeaderboardName, LeaderboardSort eLeaderboardSortMethod, LeaderboardDisplay eLeaderboardDisplayType );
		
		#endregion
		public CallResult<LeaderboardFindResult_t> FindOrCreateLeaderboard( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchLeaderboardName, LeaderboardSort eLeaderboardSortMethod, LeaderboardDisplay eLeaderboardDisplayType )
		{
			var returnValue = _FindOrCreateLeaderboard( Self, pchLeaderboardName, eLeaderboardSortMethod, eLeaderboardDisplayType );
			return new CallResult<LeaderboardFindResult_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_FindLeaderboard", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _FindLeaderboard( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchLeaderboardName );
		
		#endregion
		public CallResult<LeaderboardFindResult_t> FindLeaderboard( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchLeaderboardName )
		{
			var returnValue = _FindLeaderboard( Self, pchLeaderboardName );
			return new CallResult<LeaderboardFindResult_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardName", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetLeaderboardName( IntPtr self, SteamLeaderboard_t hSteamLeaderboard );
		
		#endregion
		public string GetLeaderboardName( SteamLeaderboard_t hSteamLeaderboard )
		{
			var returnValue = _GetLeaderboardName( Self, hSteamLeaderboard );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardEntryCount", CallingConvention = Platform.CC)]
		public static extern int _GetLeaderboardEntryCount( IntPtr self, SteamLeaderboard_t hSteamLeaderboard );
		
		#endregion
		public int GetLeaderboardEntryCount( SteamLeaderboard_t hSteamLeaderboard )
		{
			var returnValue = _GetLeaderboardEntryCount( Self, hSteamLeaderboard );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardSortMethod", CallingConvention = Platform.CC)]
		public static extern LeaderboardSort _GetLeaderboardSortMethod( IntPtr self, SteamLeaderboard_t hSteamLeaderboard );
		
		#endregion
		public LeaderboardSort GetLeaderboardSortMethod( SteamLeaderboard_t hSteamLeaderboard )
		{
			var returnValue = _GetLeaderboardSortMethod( Self, hSteamLeaderboard );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardDisplayType", CallingConvention = Platform.CC)]
		public static extern LeaderboardDisplay _GetLeaderboardDisplayType( IntPtr self, SteamLeaderboard_t hSteamLeaderboard );
		
		#endregion
		public LeaderboardDisplay GetLeaderboardDisplayType( SteamLeaderboard_t hSteamLeaderboard )
		{
			var returnValue = _GetLeaderboardDisplayType( Self, hSteamLeaderboard );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_DownloadLeaderboardEntries", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _DownloadLeaderboardEntries( IntPtr self, SteamLeaderboard_t hSteamLeaderboard, LeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd );
		
		#endregion
		public CallResult<LeaderboardScoresDownloaded_t> DownloadLeaderboardEntries( SteamLeaderboard_t hSteamLeaderboard, LeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd )
		{
			var returnValue = _DownloadLeaderboardEntries( Self, hSteamLeaderboard, eLeaderboardDataRequest, nRangeStart, nRangeEnd );
			return new CallResult<LeaderboardScoresDownloaded_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _DownloadLeaderboardEntriesForUsers( IntPtr self, SteamLeaderboard_t hSteamLeaderboard, [In,Out] SteamId[]  prgUsers, int cUsers );
		
		#endregion
		/// <summary>
		/// Downloads leaderboard entries for an arbitrary set of users - ELeaderboardDataRequest is k_ELeaderboardDataRequestUsers
		/// </summary>
		public CallResult<LeaderboardScoresDownloaded_t> DownloadLeaderboardEntriesForUsers( SteamLeaderboard_t hSteamLeaderboard, [In,Out] SteamId[]  prgUsers, int cUsers )
		{
			var returnValue = _DownloadLeaderboardEntriesForUsers( Self, hSteamLeaderboard, prgUsers, cUsers );
			return new CallResult<LeaderboardScoresDownloaded_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetDownloadedLeaderboardEntry( IntPtr self, SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, ref LeaderboardEntry_t pLeaderboardEntry, [In,Out] int[]  pDetails, int cDetailsMax );
		
		#endregion
		public bool GetDownloadedLeaderboardEntry( SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, ref LeaderboardEntry_t pLeaderboardEntry, [In,Out] int[]  pDetails, int cDetailsMax )
		{
			var returnValue = _GetDownloadedLeaderboardEntry( Self, hSteamLeaderboardEntries, index, ref pLeaderboardEntry, pDetails, cDetailsMax );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_UploadLeaderboardScore", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _UploadLeaderboardScore( IntPtr self, SteamLeaderboard_t hSteamLeaderboard, LeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, [In,Out] int[]  pScoreDetails, int cScoreDetailsCount );
		
		#endregion
		public CallResult<LeaderboardScoreUploaded_t> UploadLeaderboardScore( SteamLeaderboard_t hSteamLeaderboard, LeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, [In,Out] int[]  pScoreDetails, int cScoreDetailsCount )
		{
			var returnValue = _UploadLeaderboardScore( Self, hSteamLeaderboard, eLeaderboardUploadScoreMethod, nScore, pScoreDetails, cScoreDetailsCount );
			return new CallResult<LeaderboardScoreUploaded_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_AttachLeaderboardUGC", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _AttachLeaderboardUGC( IntPtr self, SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC );
		
		#endregion
		public CallResult<LeaderboardUGCSet_t> AttachLeaderboardUGC( SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC )
		{
			var returnValue = _AttachLeaderboardUGC( Self, hSteamLeaderboard, hUGC );
			return new CallResult<LeaderboardUGCSet_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _GetNumberOfCurrentPlayers( IntPtr self );
		
		#endregion
		public CallResult<NumberOfCurrentPlayers_t> GetNumberOfCurrentPlayers()
		{
			var returnValue = _GetNumberOfCurrentPlayers( Self );
			return new CallResult<NumberOfCurrentPlayers_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _RequestGlobalAchievementPercentages( IntPtr self );
		
		#endregion
		public CallResult<GlobalAchievementPercentagesReady_t> RequestGlobalAchievementPercentages()
		{
			var returnValue = _RequestGlobalAchievementPercentages( Self );
			return new CallResult<GlobalAchievementPercentagesReady_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo", CallingConvention = Platform.CC)]
		public static extern int _GetMostAchievedAchievementInfo( IntPtr self, IntPtr pchName, uint unNameBufLen, ref float pflPercent, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved );
		
		#endregion
		public int GetMostAchievedAchievementInfo( out string pchName, ref float pflPercent, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved )
		{
			IntPtr mempchName = Helpers.TakeMemory();
			var returnValue = _GetMostAchievedAchievementInfo( Self, mempchName, (1024 * 32), ref pflPercent, ref pbAchieved );
			pchName = Helpers.MemoryToString( mempchName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo", CallingConvention = Platform.CC)]
		public static extern int _GetNextMostAchievedAchievementInfo( IntPtr self, int iIteratorPrevious, IntPtr pchName, uint unNameBufLen, ref float pflPercent, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved );
		
		#endregion
		public int GetNextMostAchievedAchievementInfo( int iIteratorPrevious, out string pchName, ref float pflPercent, [MarshalAs( UnmanagedType.U1 )] ref bool pbAchieved )
		{
			IntPtr mempchName = Helpers.TakeMemory();
			var returnValue = _GetNextMostAchievedAchievementInfo( Self, iIteratorPrevious, mempchName, (1024 * 32), ref pflPercent, ref pbAchieved );
			pchName = Helpers.MemoryToString( mempchName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementAchievedPercent", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetAchievementAchievedPercent( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref float pflPercent );
		
		#endregion
		public bool GetAchievementAchievedPercent( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref float pflPercent )
		{
			var returnValue = _GetAchievementAchievedPercent( Self, pchName, ref pflPercent );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_RequestGlobalStats", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _RequestGlobalStats( IntPtr self, int nHistoryDays );
		
		#endregion
		public CallResult<GlobalStatsReceived_t> RequestGlobalStats( int nHistoryDays )
		{
			var returnValue = _RequestGlobalStats( Self, nHistoryDays );
			return new CallResult<GlobalStatsReceived_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatInt64", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetGlobalStat( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchStatName, ref long pData );
		
		#endregion
		public bool GetGlobalStat( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchStatName, ref long pData )
		{
			var returnValue = _GetGlobalStat( Self, pchStatName, ref pData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatDouble", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetGlobalStat( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchStatName, ref double pData );
		
		#endregion
		public bool GetGlobalStat( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchStatName, ref double pData )
		{
			var returnValue = _GetGlobalStat( Self, pchStatName, ref pData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatHistoryInt64", CallingConvention = Platform.CC)]
		public static extern int _GetGlobalStatHistory( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchStatName, [In,Out] long[]  pData, uint cubData );
		
		#endregion
		public int GetGlobalStatHistory( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchStatName, [In,Out] long[]  pData, uint cubData )
		{
			var returnValue = _GetGlobalStatHistory( Self, pchStatName, pData, cubData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatHistoryDouble", CallingConvention = Platform.CC)]
		public static extern int _GetGlobalStatHistory( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchStatName, [In,Out] double[]  pData, uint cubData );
		
		#endregion
		public int GetGlobalStatHistory( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchStatName, [In,Out] double[]  pData, uint cubData )
		{
			var returnValue = _GetGlobalStatHistory( Self, pchStatName, pData, cubData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementProgressLimitsInt32", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetAchievementProgressLimits( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref int pnMinProgress, ref int pnMaxProgress );
		
		#endregion
		public bool GetAchievementProgressLimits( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref int pnMinProgress, ref int pnMaxProgress )
		{
			var returnValue = _GetAchievementProgressLimits( Self, pchName, ref pnMinProgress, ref pnMaxProgress );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementProgressLimitsFloat", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetAchievementProgressLimits( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref float pfMinProgress, ref float pfMaxProgress );
		
		#endregion
		public bool GetAchievementProgressLimits( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchName, ref float pfMinProgress, ref float pfMaxProgress )
		{
			var returnValue = _GetAchievementProgressLimits( Self, pchName, ref pfMinProgress, ref pfMaxProgress );
			return returnValue;
		}
		
	}
}
