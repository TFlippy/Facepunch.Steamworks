using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamUser : SteamInterface
	{
		
		public ISteamUser( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamUser_v021", CallingConvention = Platform.CC)]
		public static extern IntPtr SteamAPI_SteamUser_v021();
		public override IntPtr GetUserInterfacePointer() => SteamAPI_SteamUser_v021();
		
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetHSteamUser", CallingConvention = Platform.CC)]
		public static extern HSteamUser _GetHSteamUser( IntPtr self );
		
		#endregion
		public HSteamUser GetHSteamUser()
		{
			var returnValue = _GetHSteamUser( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BLoggedOn", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BLoggedOn( IntPtr self );
		
		#endregion
		public bool BLoggedOn()
		{
			var returnValue = _BLoggedOn( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetSteamID", CallingConvention = Platform.CC)]
		public static extern SteamId _GetSteamID( IntPtr self );
		
		#endregion
		public SteamId GetSteamID()
		{
			var returnValue = _GetSteamID( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_InitiateGameConnection", CallingConvention = Platform.CC)]
		public static extern int _InitiateGameConnection( IntPtr self, IntPtr pAuthBlob, int cbMaxAuthBlob, SteamId steamIDGameServer, uint unIPServer, ushort usPortServer, [MarshalAs( UnmanagedType.U1 )] bool bSecure );
		
		#endregion
		public int InitiateGameConnection( IntPtr pAuthBlob, int cbMaxAuthBlob, SteamId steamIDGameServer, uint unIPServer, ushort usPortServer, [MarshalAs( UnmanagedType.U1 )] bool bSecure )
		{
			var returnValue = _InitiateGameConnection( Self, pAuthBlob, cbMaxAuthBlob, steamIDGameServer, unIPServer, usPortServer, bSecure );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_TerminateGameConnection", CallingConvention = Platform.CC)]
		public static extern void _TerminateGameConnection( IntPtr self, uint unIPServer, ushort usPortServer );
		
		#endregion
		public void TerminateGameConnection( uint unIPServer, ushort usPortServer )
		{
			_TerminateGameConnection( Self, unIPServer, usPortServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_TrackAppUsageEvent", CallingConvention = Platform.CC)]
		public static extern void _TrackAppUsageEvent( IntPtr self, GameId gameID, int eAppUsageEvent, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchExtraInfo );
		
		#endregion
		public void TrackAppUsageEvent( GameId gameID, int eAppUsageEvent, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchExtraInfo )
		{
			_TrackAppUsageEvent( Self, gameID, eAppUsageEvent, pchExtraInfo );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetUserDataFolder", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetUserDataFolder( IntPtr self, IntPtr pchBuffer, int cubBuffer );
		
		#endregion
		public bool GetUserDataFolder( out string pchBuffer )
		{
			IntPtr mempchBuffer = Helpers.TakeMemory();
			var returnValue = _GetUserDataFolder( Self, mempchBuffer, (1024 * 32) );
			pchBuffer = Helpers.MemoryToString( mempchBuffer );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_StartVoiceRecording", CallingConvention = Platform.CC)]
		public static extern void _StartVoiceRecording( IntPtr self );
		
		#endregion
		public void StartVoiceRecording()
		{
			_StartVoiceRecording( Self );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_StopVoiceRecording", CallingConvention = Platform.CC)]
		public static extern void _StopVoiceRecording( IntPtr self );
		
		#endregion
		public void StopVoiceRecording()
		{
			_StopVoiceRecording( Self );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetAvailableVoice", CallingConvention = Platform.CC)]
		public static extern VoiceResult _GetAvailableVoice( IntPtr self, ref uint pcbCompressed, ref uint pcbUncompressed_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated );
		
		#endregion
		public VoiceResult GetAvailableVoice( ref uint pcbCompressed, ref uint pcbUncompressed_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated )
		{
			var returnValue = _GetAvailableVoice( Self, ref pcbCompressed, ref pcbUncompressed_Deprecated, nUncompressedVoiceDesiredSampleRate_Deprecated );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetVoice", CallingConvention = Platform.CC)]
		public static extern VoiceResult _GetVoice( IntPtr self, [MarshalAs( UnmanagedType.U1 )] bool bWantCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, [MarshalAs( UnmanagedType.U1 )] bool bWantUncompressed_Deprecated, IntPtr pUncompressedDestBuffer_Deprecated, uint cbUncompressedDestBufferSize_Deprecated, ref uint nUncompressBytesWritten_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated );
		
		#endregion
		public VoiceResult GetVoice( [MarshalAs( UnmanagedType.U1 )] bool bWantCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, [MarshalAs( UnmanagedType.U1 )] bool bWantUncompressed_Deprecated, IntPtr pUncompressedDestBuffer_Deprecated, uint cbUncompressedDestBufferSize_Deprecated, ref uint nUncompressBytesWritten_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated )
		{
			var returnValue = _GetVoice( Self, bWantCompressed, pDestBuffer, cbDestBufferSize, ref nBytesWritten, bWantUncompressed_Deprecated, pUncompressedDestBuffer_Deprecated, cbUncompressedDestBufferSize_Deprecated, ref nUncompressBytesWritten_Deprecated, nUncompressedVoiceDesiredSampleRate_Deprecated );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_DecompressVoice", CallingConvention = Platform.CC)]
		public static extern VoiceResult _DecompressVoice( IntPtr self, IntPtr pCompressed, uint cbCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, uint nDesiredSampleRate );
		
		#endregion
		public VoiceResult DecompressVoice( IntPtr pCompressed, uint cbCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, uint nDesiredSampleRate )
		{
			var returnValue = _DecompressVoice( Self, pCompressed, cbCompressed, pDestBuffer, cbDestBufferSize, ref nBytesWritten, nDesiredSampleRate );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetVoiceOptimalSampleRate", CallingConvention = Platform.CC)]
		public static extern uint _GetVoiceOptimalSampleRate( IntPtr self );
		
		#endregion
		public uint GetVoiceOptimalSampleRate()
		{
			var returnValue = _GetVoiceOptimalSampleRate( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetAuthSessionTicket", CallingConvention = Platform.CC)]
		public static extern HAuthTicket _GetAuthSessionTicket( IntPtr self, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket );
		
		#endregion
		public HAuthTicket GetAuthSessionTicket( IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket )
		{
			var returnValue = _GetAuthSessionTicket( Self, pTicket, cbMaxTicket, ref pcbTicket );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BeginAuthSession", CallingConvention = Platform.CC)]
		public static extern BeginAuthResult _BeginAuthSession( IntPtr self, IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID );
		
		#endregion
		public BeginAuthResult BeginAuthSession( IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID )
		{
			var returnValue = _BeginAuthSession( Self, pAuthTicket, cbAuthTicket, steamID );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_EndAuthSession", CallingConvention = Platform.CC)]
		public static extern void _EndAuthSession( IntPtr self, SteamId steamID );
		
		#endregion
		public void EndAuthSession( SteamId steamID )
		{
			_EndAuthSession( Self, steamID );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_CancelAuthTicket", CallingConvention = Platform.CC)]
		public static extern void _CancelAuthTicket( IntPtr self, HAuthTicket hAuthTicket );
		
		#endregion
		public void CancelAuthTicket( HAuthTicket hAuthTicket )
		{
			_CancelAuthTicket( Self, hAuthTicket );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_UserHasLicenseForApp", CallingConvention = Platform.CC)]
		public static extern UserHasLicenseForAppResult _UserHasLicenseForApp( IntPtr self, SteamId steamID, AppId appID );
		
		#endregion
		public UserHasLicenseForAppResult UserHasLicenseForApp( SteamId steamID, AppId appID )
		{
			var returnValue = _UserHasLicenseForApp( Self, steamID, appID );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BIsBehindNAT", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsBehindNAT( IntPtr self );
		
		#endregion
		public bool BIsBehindNAT()
		{
			var returnValue = _BIsBehindNAT( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_AdvertiseGame", CallingConvention = Platform.CC)]
		public static extern void _AdvertiseGame( IntPtr self, SteamId steamIDGameServer, uint unIPServer, ushort usPortServer );
		
		#endregion
		public void AdvertiseGame( SteamId steamIDGameServer, uint unIPServer, ushort usPortServer )
		{
			_AdvertiseGame( Self, steamIDGameServer, unIPServer, usPortServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_RequestEncryptedAppTicket", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _RequestEncryptedAppTicket( IntPtr self, IntPtr pDataToInclude, int cbDataToInclude );
		
		#endregion
		public CallResult<EncryptedAppTicketResponse_t> RequestEncryptedAppTicket( IntPtr pDataToInclude, int cbDataToInclude )
		{
			var returnValue = _RequestEncryptedAppTicket( Self, pDataToInclude, cbDataToInclude );
			return new CallResult<EncryptedAppTicketResponse_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetEncryptedAppTicket", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetEncryptedAppTicket( IntPtr self, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket );
		
		#endregion
		public bool GetEncryptedAppTicket( IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket )
		{
			var returnValue = _GetEncryptedAppTicket( Self, pTicket, cbMaxTicket, ref pcbTicket );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetGameBadgeLevel", CallingConvention = Platform.CC)]
		public static extern int _GetGameBadgeLevel( IntPtr self, int nSeries, [MarshalAs( UnmanagedType.U1 )] bool bFoil );
		
		#endregion
		public int GetGameBadgeLevel( int nSeries, [MarshalAs( UnmanagedType.U1 )] bool bFoil )
		{
			var returnValue = _GetGameBadgeLevel( Self, nSeries, bFoil );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetPlayerSteamLevel", CallingConvention = Platform.CC)]
		public static extern int _GetPlayerSteamLevel( IntPtr self );
		
		#endregion
		public int GetPlayerSteamLevel()
		{
			var returnValue = _GetPlayerSteamLevel( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_RequestStoreAuthURL", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _RequestStoreAuthURL( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchRedirectURL );
		
		#endregion
		public CallResult<StoreAuthURLResponse_t> RequestStoreAuthURL( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchRedirectURL )
		{
			var returnValue = _RequestStoreAuthURL( Self, pchRedirectURL );
			return new CallResult<StoreAuthURLResponse_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneVerified", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsPhoneVerified( IntPtr self );
		
		#endregion
		public bool BIsPhoneVerified()
		{
			var returnValue = _BIsPhoneVerified( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BIsTwoFactorEnabled", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsTwoFactorEnabled( IntPtr self );
		
		#endregion
		public bool BIsTwoFactorEnabled()
		{
			var returnValue = _BIsTwoFactorEnabled( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneIdentifying", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsPhoneIdentifying( IntPtr self );
		
		#endregion
		public bool BIsPhoneIdentifying()
		{
			var returnValue = _BIsPhoneIdentifying( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneRequiringVerification", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BIsPhoneRequiringVerification( IntPtr self );
		
		#endregion
		public bool BIsPhoneRequiringVerification()
		{
			var returnValue = _BIsPhoneRequiringVerification( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetMarketEligibility", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _GetMarketEligibility( IntPtr self );
		
		#endregion
		public CallResult<MarketEligibilityResponse_t> GetMarketEligibility()
		{
			var returnValue = _GetMarketEligibility( Self );
			return new CallResult<MarketEligibilityResponse_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_GetDurationControl", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _GetDurationControl( IntPtr self );
		
		#endregion
		public CallResult<DurationControl_t> GetDurationControl()
		{
			var returnValue = _GetDurationControl( Self );
			return new CallResult<DurationControl_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamUser_BSetDurationControlOnlineState", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _BSetDurationControlOnlineState( IntPtr self, DurationControlOnlineState eNewState );
		
		#endregion
		public bool BSetDurationControlOnlineState( DurationControlOnlineState eNewState )
		{
			var returnValue = _BSetDurationControlOnlineState( Self, eNewState );
			return returnValue;
		}
		
	}
}
