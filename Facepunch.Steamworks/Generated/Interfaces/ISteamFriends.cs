using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamFriends : SteamInterface
	{
		
		public ISteamFriends( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamFriends_v017", CallingConvention = Platform.CC)]
		public static extern IntPtr SteamAPI_SteamFriends_v017();
		public override IntPtr GetUserInterfacePointer() => SteamAPI_SteamFriends_v017();
		
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetPersonaName", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetPersonaName( IntPtr self );
		
		#endregion
		public string GetPersonaName()
		{
			var returnValue = _GetPersonaName( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_SetPersonaName", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _SetPersonaName( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchPersonaName );
		
		#endregion
		public CallResult<SetPersonaNameResponse_t> SetPersonaName( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchPersonaName )
		{
			var returnValue = _SetPersonaName( Self, pchPersonaName );
			return new CallResult<SetPersonaNameResponse_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetPersonaState", CallingConvention = Platform.CC)]
		public static extern FriendState _GetPersonaState( IntPtr self );
		
		#endregion
		public FriendState GetPersonaState()
		{
			var returnValue = _GetPersonaState( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCount", CallingConvention = Platform.CC)]
		public static extern int _GetFriendCount( IntPtr self, int iFriendFlags );
		
		#endregion
		public int GetFriendCount( int iFriendFlags )
		{
			var returnValue = _GetFriendCount( Self, iFriendFlags );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendByIndex", CallingConvention = Platform.CC)]
		public static extern SteamId _GetFriendByIndex( IntPtr self, int iFriend, int iFriendFlags );
		
		#endregion
		public SteamId GetFriendByIndex( int iFriend, int iFriendFlags )
		{
			var returnValue = _GetFriendByIndex( Self, iFriend, iFriendFlags );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRelationship", CallingConvention = Platform.CC)]
		public static extern Relationship _GetFriendRelationship( IntPtr self, SteamId steamIDFriend );
		
		#endregion
		public Relationship GetFriendRelationship( SteamId steamIDFriend )
		{
			var returnValue = _GetFriendRelationship( Self, steamIDFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaState", CallingConvention = Platform.CC)]
		public static extern FriendState _GetFriendPersonaState( IntPtr self, SteamId steamIDFriend );
		
		#endregion
		public FriendState GetFriendPersonaState( SteamId steamIDFriend )
		{
			var returnValue = _GetFriendPersonaState( Self, steamIDFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaName", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetFriendPersonaName( IntPtr self, SteamId steamIDFriend );
		
		#endregion
		public string GetFriendPersonaName( SteamId steamIDFriend )
		{
			var returnValue = _GetFriendPersonaName( Self, steamIDFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendGamePlayed", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetFriendGamePlayed( IntPtr self, SteamId steamIDFriend, ref FriendGameInfo_t pFriendGameInfo );
		
		#endregion
		public bool GetFriendGamePlayed( SteamId steamIDFriend, ref FriendGameInfo_t pFriendGameInfo )
		{
			var returnValue = _GetFriendGamePlayed( Self, steamIDFriend, ref pFriendGameInfo );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaNameHistory", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetFriendPersonaNameHistory( IntPtr self, SteamId steamIDFriend, int iPersonaName );
		
		#endregion
		public string GetFriendPersonaNameHistory( SteamId steamIDFriend, int iPersonaName )
		{
			var returnValue = _GetFriendPersonaNameHistory( Self, steamIDFriend, iPersonaName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendSteamLevel", CallingConvention = Platform.CC)]
		public static extern int _GetFriendSteamLevel( IntPtr self, SteamId steamIDFriend );
		
		#endregion
		public int GetFriendSteamLevel( SteamId steamIDFriend )
		{
			var returnValue = _GetFriendSteamLevel( Self, steamIDFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetPlayerNickname", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetPlayerNickname( IntPtr self, SteamId steamIDPlayer );
		
		#endregion
		public string GetPlayerNickname( SteamId steamIDPlayer )
		{
			var returnValue = _GetPlayerNickname( Self, steamIDPlayer );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupCount", CallingConvention = Platform.CC)]
		public static extern int _GetFriendsGroupCount( IntPtr self );
		
		#endregion
		public int GetFriendsGroupCount()
		{
			var returnValue = _GetFriendsGroupCount( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupIDByIndex", CallingConvention = Platform.CC)]
		public static extern FriendsGroupID_t _GetFriendsGroupIDByIndex( IntPtr self, int iFG );
		
		#endregion
		public FriendsGroupID_t GetFriendsGroupIDByIndex( int iFG )
		{
			var returnValue = _GetFriendsGroupIDByIndex( Self, iFG );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupName", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetFriendsGroupName( IntPtr self, FriendsGroupID_t friendsGroupID );
		
		#endregion
		public string GetFriendsGroupName( FriendsGroupID_t friendsGroupID )
		{
			var returnValue = _GetFriendsGroupName( Self, friendsGroupID );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupMembersCount", CallingConvention = Platform.CC)]
		public static extern int _GetFriendsGroupMembersCount( IntPtr self, FriendsGroupID_t friendsGroupID );
		
		#endregion
		public int GetFriendsGroupMembersCount( FriendsGroupID_t friendsGroupID )
		{
			var returnValue = _GetFriendsGroupMembersCount( Self, friendsGroupID );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupMembersList", CallingConvention = Platform.CC)]
		public static extern void _GetFriendsGroupMembersList( IntPtr self, FriendsGroupID_t friendsGroupID, [In,Out] SteamId[]  pOutSteamIDMembers, int nMembersCount );
		
		#endregion
		public void GetFriendsGroupMembersList( FriendsGroupID_t friendsGroupID, [In,Out] SteamId[]  pOutSteamIDMembers, int nMembersCount )
		{
			_GetFriendsGroupMembersList( Self, friendsGroupID, pOutSteamIDMembers, nMembersCount );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_HasFriend", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _HasFriend( IntPtr self, SteamId steamIDFriend, int iFriendFlags );
		
		#endregion
		public bool HasFriend( SteamId steamIDFriend, int iFriendFlags )
		{
			var returnValue = _HasFriend( Self, steamIDFriend, iFriendFlags );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanCount", CallingConvention = Platform.CC)]
		public static extern int _GetClanCount( IntPtr self );
		
		#endregion
		public int GetClanCount()
		{
			var returnValue = _GetClanCount( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanByIndex", CallingConvention = Platform.CC)]
		public static extern SteamId _GetClanByIndex( IntPtr self, int iClan );
		
		#endregion
		public SteamId GetClanByIndex( int iClan )
		{
			var returnValue = _GetClanByIndex( Self, iClan );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanName", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetClanName( IntPtr self, SteamId steamIDClan );
		
		#endregion
		public string GetClanName( SteamId steamIDClan )
		{
			var returnValue = _GetClanName( Self, steamIDClan );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanTag", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetClanTag( IntPtr self, SteamId steamIDClan );
		
		#endregion
		public string GetClanTag( SteamId steamIDClan )
		{
			var returnValue = _GetClanTag( Self, steamIDClan );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanActivityCounts", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _GetClanActivityCounts( IntPtr self, SteamId steamIDClan, ref int pnOnline, ref int pnInGame, ref int pnChatting );
		
		#endregion
		public bool GetClanActivityCounts( SteamId steamIDClan, ref int pnOnline, ref int pnInGame, ref int pnChatting )
		{
			var returnValue = _GetClanActivityCounts( Self, steamIDClan, ref pnOnline, ref pnInGame, ref pnChatting );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_DownloadClanActivityCounts", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _DownloadClanActivityCounts( IntPtr self, [In,Out] SteamId[]  psteamIDClans, int cClansToRequest );
		
		#endregion
		public CallResult<DownloadClanActivityCountsResult_t> DownloadClanActivityCounts( [In,Out] SteamId[]  psteamIDClans, int cClansToRequest )
		{
			var returnValue = _DownloadClanActivityCounts( Self, psteamIDClans, cClansToRequest );
			return new CallResult<DownloadClanActivityCountsResult_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCountFromSource", CallingConvention = Platform.CC)]
		public static extern int _GetFriendCountFromSource( IntPtr self, SteamId steamIDSource );
		
		#endregion
		public int GetFriendCountFromSource( SteamId steamIDSource )
		{
			var returnValue = _GetFriendCountFromSource( Self, steamIDSource );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendFromSourceByIndex", CallingConvention = Platform.CC)]
		public static extern SteamId _GetFriendFromSourceByIndex( IntPtr self, SteamId steamIDSource, int iFriend );
		
		#endregion
		public SteamId GetFriendFromSourceByIndex( SteamId steamIDSource, int iFriend )
		{
			var returnValue = _GetFriendFromSourceByIndex( Self, steamIDSource, iFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsUserInSource", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _IsUserInSource( IntPtr self, SteamId steamIDUser, SteamId steamIDSource );
		
		#endregion
		public bool IsUserInSource( SteamId steamIDUser, SteamId steamIDSource )
		{
			var returnValue = _IsUserInSource( Self, steamIDUser, steamIDSource );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_SetInGameVoiceSpeaking", CallingConvention = Platform.CC)]
		public static extern void _SetInGameVoiceSpeaking( IntPtr self, SteamId steamIDUser, [MarshalAs( UnmanagedType.U1 )] bool bSpeaking );
		
		#endregion
		public void SetInGameVoiceSpeaking( SteamId steamIDUser, [MarshalAs( UnmanagedType.U1 )] bool bSpeaking )
		{
			_SetInGameVoiceSpeaking( Self, steamIDUser, bSpeaking );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlay", CallingConvention = Platform.CC)]
		public static extern void _ActivateGameOverlay( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchDialog );
		
		#endregion
		public void ActivateGameOverlay( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchDialog )
		{
			_ActivateGameOverlay( Self, pchDialog );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToUser", CallingConvention = Platform.CC)]
		public static extern void _ActivateGameOverlayToUser( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchDialog, SteamId steamID );
		
		#endregion
		public void ActivateGameOverlayToUser( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchDialog, SteamId steamID )
		{
			_ActivateGameOverlayToUser( Self, pchDialog, steamID );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage", CallingConvention = Platform.CC)]
		public static extern void _ActivateGameOverlayToWebPage( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchURL, ActivateGameOverlayToWebPageMode eMode );
		
		#endregion
		public void ActivateGameOverlayToWebPage( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchURL, ActivateGameOverlayToWebPageMode eMode )
		{
			_ActivateGameOverlayToWebPage( Self, pchURL, eMode );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToStore", CallingConvention = Platform.CC)]
		public static extern void _ActivateGameOverlayToStore( IntPtr self, AppId nAppID, OverlayToStoreFlag eFlag );
		
		#endregion
		public void ActivateGameOverlayToStore( AppId nAppID, OverlayToStoreFlag eFlag )
		{
			_ActivateGameOverlayToStore( Self, nAppID, eFlag );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_SetPlayedWith", CallingConvention = Platform.CC)]
		public static extern void _SetPlayedWith( IntPtr self, SteamId steamIDUserPlayedWith );
		
		#endregion
		public void SetPlayedWith( SteamId steamIDUserPlayedWith )
		{
			_SetPlayedWith( Self, steamIDUserPlayedWith );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialog", CallingConvention = Platform.CC)]
		public static extern void _ActivateGameOverlayInviteDialog( IntPtr self, SteamId steamIDLobby );
		
		#endregion
		public void ActivateGameOverlayInviteDialog( SteamId steamIDLobby )
		{
			_ActivateGameOverlayInviteDialog( Self, steamIDLobby );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetSmallFriendAvatar", CallingConvention = Platform.CC)]
		public static extern int _GetSmallFriendAvatar( IntPtr self, SteamId steamIDFriend );
		
		#endregion
		public int GetSmallFriendAvatar( SteamId steamIDFriend )
		{
			var returnValue = _GetSmallFriendAvatar( Self, steamIDFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetMediumFriendAvatar", CallingConvention = Platform.CC)]
		public static extern int _GetMediumFriendAvatar( IntPtr self, SteamId steamIDFriend );
		
		#endregion
		public int GetMediumFriendAvatar( SteamId steamIDFriend )
		{
			var returnValue = _GetMediumFriendAvatar( Self, steamIDFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetLargeFriendAvatar", CallingConvention = Platform.CC)]
		public static extern int _GetLargeFriendAvatar( IntPtr self, SteamId steamIDFriend );
		
		#endregion
		public int GetLargeFriendAvatar( SteamId steamIDFriend )
		{
			var returnValue = _GetLargeFriendAvatar( Self, steamIDFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_RequestUserInformation", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _RequestUserInformation( IntPtr self, SteamId steamIDUser, [MarshalAs( UnmanagedType.U1 )] bool bRequireNameOnly );
		
		#endregion
		public bool RequestUserInformation( SteamId steamIDUser, [MarshalAs( UnmanagedType.U1 )] bool bRequireNameOnly )
		{
			var returnValue = _RequestUserInformation( Self, steamIDUser, bRequireNameOnly );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_RequestClanOfficerList", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _RequestClanOfficerList( IntPtr self, SteamId steamIDClan );
		
		#endregion
		public CallResult<ClanOfficerListResponse_t> RequestClanOfficerList( SteamId steamIDClan )
		{
			var returnValue = _RequestClanOfficerList( Self, steamIDClan );
			return new CallResult<ClanOfficerListResponse_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanOwner", CallingConvention = Platform.CC)]
		public static extern SteamId _GetClanOwner( IntPtr self, SteamId steamIDClan );
		
		#endregion
		public SteamId GetClanOwner( SteamId steamIDClan )
		{
			var returnValue = _GetClanOwner( Self, steamIDClan );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanOfficerCount", CallingConvention = Platform.CC)]
		public static extern int _GetClanOfficerCount( IntPtr self, SteamId steamIDClan );
		
		#endregion
		public int GetClanOfficerCount( SteamId steamIDClan )
		{
			var returnValue = _GetClanOfficerCount( Self, steamIDClan );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanOfficerByIndex", CallingConvention = Platform.CC)]
		public static extern SteamId _GetClanOfficerByIndex( IntPtr self, SteamId steamIDClan, int iOfficer );
		
		#endregion
		public SteamId GetClanOfficerByIndex( SteamId steamIDClan, int iOfficer )
		{
			var returnValue = _GetClanOfficerByIndex( Self, steamIDClan, iOfficer );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetUserRestrictions", CallingConvention = Platform.CC)]
		public static extern uint _GetUserRestrictions( IntPtr self );
		
		#endregion
		public uint GetUserRestrictions()
		{
			var returnValue = _GetUserRestrictions( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_SetRichPresence", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _SetRichPresence( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchKey, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchValue );
		
		#endregion
		public bool SetRichPresence( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchKey, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchValue )
		{
			var returnValue = _SetRichPresence( Self, pchKey, pchValue );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ClearRichPresence", CallingConvention = Platform.CC)]
		public static extern void _ClearRichPresence( IntPtr self );
		
		#endregion
		public void ClearRichPresence()
		{
			_ClearRichPresence( Self );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresence", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetFriendRichPresence( IntPtr self, SteamId steamIDFriend, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchKey );
		
		#endregion
		public string GetFriendRichPresence( SteamId steamIDFriend, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchKey )
		{
			var returnValue = _GetFriendRichPresence( Self, steamIDFriend, pchKey );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresenceKeyCount", CallingConvention = Platform.CC)]
		public static extern int _GetFriendRichPresenceKeyCount( IntPtr self, SteamId steamIDFriend );
		
		#endregion
		public int GetFriendRichPresenceKeyCount( SteamId steamIDFriend )
		{
			var returnValue = _GetFriendRichPresenceKeyCount( Self, steamIDFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresenceKeyByIndex", CallingConvention = Platform.CC)]
		public static extern Utf8StringPointer _GetFriendRichPresenceKeyByIndex( IntPtr self, SteamId steamIDFriend, int iKey );
		
		#endregion
		public string GetFriendRichPresenceKeyByIndex( SteamId steamIDFriend, int iKey )
		{
			var returnValue = _GetFriendRichPresenceKeyByIndex( Self, steamIDFriend, iKey );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_RequestFriendRichPresence", CallingConvention = Platform.CC)]
		public static extern void _RequestFriendRichPresence( IntPtr self, SteamId steamIDFriend );
		
		#endregion
		public void RequestFriendRichPresence( SteamId steamIDFriend )
		{
			_RequestFriendRichPresence( Self, steamIDFriend );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_InviteUserToGame", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _InviteUserToGame( IntPtr self, SteamId steamIDFriend, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchConnectString );
		
		#endregion
		public bool InviteUserToGame( SteamId steamIDFriend, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchConnectString )
		{
			var returnValue = _InviteUserToGame( Self, steamIDFriend, pchConnectString );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetCoplayFriendCount", CallingConvention = Platform.CC)]
		public static extern int _GetCoplayFriendCount( IntPtr self );
		
		#endregion
		public int GetCoplayFriendCount()
		{
			var returnValue = _GetCoplayFriendCount( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetCoplayFriend", CallingConvention = Platform.CC)]
		public static extern SteamId _GetCoplayFriend( IntPtr self, int iCoplayFriend );
		
		#endregion
		public SteamId GetCoplayFriend( int iCoplayFriend )
		{
			var returnValue = _GetCoplayFriend( Self, iCoplayFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCoplayTime", CallingConvention = Platform.CC)]
		public static extern int _GetFriendCoplayTime( IntPtr self, SteamId steamIDFriend );
		
		#endregion
		public int GetFriendCoplayTime( SteamId steamIDFriend )
		{
			var returnValue = _GetFriendCoplayTime( Self, steamIDFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCoplayGame", CallingConvention = Platform.CC)]
		public static extern AppId _GetFriendCoplayGame( IntPtr self, SteamId steamIDFriend );
		
		#endregion
		public AppId GetFriendCoplayGame( SteamId steamIDFriend )
		{
			var returnValue = _GetFriendCoplayGame( Self, steamIDFriend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_JoinClanChatRoom", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _JoinClanChatRoom( IntPtr self, SteamId steamIDClan );
		
		#endregion
		public CallResult<JoinClanChatRoomCompletionResult_t> JoinClanChatRoom( SteamId steamIDClan )
		{
			var returnValue = _JoinClanChatRoom( Self, steamIDClan );
			return new CallResult<JoinClanChatRoomCompletionResult_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_LeaveClanChatRoom", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _LeaveClanChatRoom( IntPtr self, SteamId steamIDClan );
		
		#endregion
		public bool LeaveClanChatRoom( SteamId steamIDClan )
		{
			var returnValue = _LeaveClanChatRoom( Self, steamIDClan );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanChatMemberCount", CallingConvention = Platform.CC)]
		public static extern int _GetClanChatMemberCount( IntPtr self, SteamId steamIDClan );
		
		#endregion
		public int GetClanChatMemberCount( SteamId steamIDClan )
		{
			var returnValue = _GetClanChatMemberCount( Self, steamIDClan );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetChatMemberByIndex", CallingConvention = Platform.CC)]
		public static extern SteamId _GetChatMemberByIndex( IntPtr self, SteamId steamIDClan, int iUser );
		
		#endregion
		public SteamId GetChatMemberByIndex( SteamId steamIDClan, int iUser )
		{
			var returnValue = _GetChatMemberByIndex( Self, steamIDClan, iUser );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_SendClanChatMessage", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _SendClanChatMessage( IntPtr self, SteamId steamIDClanChat, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchText );
		
		#endregion
		public bool SendClanChatMessage( SteamId steamIDClanChat, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchText )
		{
			var returnValue = _SendClanChatMessage( Self, steamIDClanChat, pchText );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetClanChatMessage", CallingConvention = Platform.CC)]
		public static extern int _GetClanChatMessage( IntPtr self, SteamId steamIDClanChat, int iMessage, IntPtr prgchText, int cchTextMax, ref ChatEntryType peChatEntryType, ref SteamId psteamidChatter );
		
		#endregion
		public int GetClanChatMessage( SteamId steamIDClanChat, int iMessage, IntPtr prgchText, int cchTextMax, ref ChatEntryType peChatEntryType, ref SteamId psteamidChatter )
		{
			var returnValue = _GetClanChatMessage( Self, steamIDClanChat, iMessage, prgchText, cchTextMax, ref peChatEntryType, ref psteamidChatter );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsClanChatAdmin", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _IsClanChatAdmin( IntPtr self, SteamId steamIDClanChat, SteamId steamIDUser );
		
		#endregion
		public bool IsClanChatAdmin( SteamId steamIDClanChat, SteamId steamIDUser )
		{
			var returnValue = _IsClanChatAdmin( Self, steamIDClanChat, steamIDUser );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsClanChatWindowOpenInSteam", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _IsClanChatWindowOpenInSteam( IntPtr self, SteamId steamIDClanChat );
		
		#endregion
		public bool IsClanChatWindowOpenInSteam( SteamId steamIDClanChat )
		{
			var returnValue = _IsClanChatWindowOpenInSteam( Self, steamIDClanChat );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_OpenClanChatWindowInSteam", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _OpenClanChatWindowInSteam( IntPtr self, SteamId steamIDClanChat );
		
		#endregion
		public bool OpenClanChatWindowInSteam( SteamId steamIDClanChat )
		{
			var returnValue = _OpenClanChatWindowInSteam( Self, steamIDClanChat );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_CloseClanChatWindowInSteam", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _CloseClanChatWindowInSteam( IntPtr self, SteamId steamIDClanChat );
		
		#endregion
		public bool CloseClanChatWindowInSteam( SteamId steamIDClanChat )
		{
			var returnValue = _CloseClanChatWindowInSteam( Self, steamIDClanChat );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_SetListenForFriendsMessages", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _SetListenForFriendsMessages( IntPtr self, [MarshalAs( UnmanagedType.U1 )] bool bInterceptEnabled );
		
		#endregion
		public bool SetListenForFriendsMessages( [MarshalAs( UnmanagedType.U1 )] bool bInterceptEnabled )
		{
			var returnValue = _SetListenForFriendsMessages( Self, bInterceptEnabled );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ReplyToFriendMessage", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _ReplyToFriendMessage( IntPtr self, SteamId steamIDFriend, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchMsgToSend );
		
		#endregion
		public bool ReplyToFriendMessage( SteamId steamIDFriend, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchMsgToSend )
		{
			var returnValue = _ReplyToFriendMessage( Self, steamIDFriend, pchMsgToSend );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFriendMessage", CallingConvention = Platform.CC)]
		public static extern int _GetFriendMessage( IntPtr self, SteamId steamIDFriend, int iMessageID, IntPtr pvData, int cubData, ref ChatEntryType peChatEntryType );
		
		#endregion
		public int GetFriendMessage( SteamId steamIDFriend, int iMessageID, IntPtr pvData, int cubData, ref ChatEntryType peChatEntryType )
		{
			var returnValue = _GetFriendMessage( Self, steamIDFriend, iMessageID, pvData, cubData, ref peChatEntryType );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetFollowerCount", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _GetFollowerCount( IntPtr self, SteamId steamID );
		
		#endregion
		public CallResult<FriendsGetFollowerCount_t> GetFollowerCount( SteamId steamID )
		{
			var returnValue = _GetFollowerCount( Self, steamID );
			return new CallResult<FriendsGetFollowerCount_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsFollowing", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _IsFollowing( IntPtr self, SteamId steamID );
		
		#endregion
		public CallResult<FriendsIsFollowing_t> IsFollowing( SteamId steamID )
		{
			var returnValue = _IsFollowing( Self, steamID );
			return new CallResult<FriendsIsFollowing_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_EnumerateFollowingList", CallingConvention = Platform.CC)]
		public static extern SteamAPICall_t _EnumerateFollowingList( IntPtr self, uint unStartIndex );
		
		#endregion
		public CallResult<FriendsEnumerateFollowingList_t> EnumerateFollowingList( uint unStartIndex )
		{
			var returnValue = _EnumerateFollowingList( Self, unStartIndex );
			return new CallResult<FriendsEnumerateFollowingList_t>( returnValue, IsServer );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsClanPublic", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _IsClanPublic( IntPtr self, SteamId steamIDClan );
		
		#endregion
		public bool IsClanPublic( SteamId steamIDClan )
		{
			var returnValue = _IsClanPublic( Self, steamIDClan );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_IsClanOfficialGameGroup", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _IsClanOfficialGameGroup( IntPtr self, SteamId steamIDClan );
		
		#endregion
		public bool IsClanOfficialGameGroup( SteamId steamIDClan )
		{
			var returnValue = _IsClanOfficialGameGroup( Self, steamIDClan );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_GetNumChatsWithUnreadPriorityMessages", CallingConvention = Platform.CC)]
		public static extern int _GetNumChatsWithUnreadPriorityMessages( IntPtr self );
		
		#endregion
		public int GetNumChatsWithUnreadPriorityMessages()
		{
			var returnValue = _GetNumChatsWithUnreadPriorityMessages( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayRemotePlayTogetherInviteDialog", CallingConvention = Platform.CC)]
		public static extern void _ActivateGameOverlayRemotePlayTogetherInviteDialog( IntPtr self, SteamId steamIDLobby );
		
		#endregion
		public void ActivateGameOverlayRemotePlayTogetherInviteDialog( SteamId steamIDLobby )
		{
			_ActivateGameOverlayRemotePlayTogetherInviteDialog( Self, steamIDLobby );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_RegisterProtocolInOverlayBrowser", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		public static extern bool _RegisterProtocolInOverlayBrowser( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchProtocol );
		
		#endregion
		public bool RegisterProtocolInOverlayBrowser( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchProtocol )
		{
			var returnValue = _RegisterProtocolInOverlayBrowser( Self, pchProtocol );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialogConnectString", CallingConvention = Platform.CC)]
		public static extern void _ActivateGameOverlayInviteDialogConnectString( IntPtr self, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchConnectString );
		
		#endregion
		public void ActivateGameOverlayInviteDialogConnectString( [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pchConnectString )
		{
			_ActivateGameOverlayInviteDialogConnectString( Self, pchConnectString );
		}
		
	}
}
