using System;
using System.Runtime.InteropServices;
using System.Linq;
using Steamworks.Data;
using System.Threading.Tasks;

namespace Steamworks.Data
{
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize )]
	public struct FriendGameInfo_t
	{
		public GameId GameID; // m_gameID CGameID
		public uint GameIP; // m_unGameIP uint32
		public ushort GamePort; // m_usGamePort uint16
		public ushort QueryPort; // m_usQueryPort uint16
		public ulong SteamIDLobby; // m_steamIDLobby CSteamID
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public partial struct servernetadr_t
	{
		public ushort ConnectionPort; // m_usConnectionPort uint16
		public ushort QueryPort; // m_usQueryPort uint16
		public uint IP; // m_unIP uint32
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize )]
	public partial struct gameserveritem_t
	{
		public servernetadr_t NetAdr; // m_NetAdr servernetadr_t
		public int Ping; // m_nPing int
		[MarshalAs(UnmanagedType.I1)]
		public bool HadSuccessfulResponse; // m_bHadSuccessfulResponse bool
		[MarshalAs(UnmanagedType.I1)]
		public bool DoNotRefresh; // m_bDoNotRefresh bool
		public string GameDirUTF8() => System.Text.Encoding.UTF8.GetString( GameDir, 0, System.Array.IndexOf<byte>( GameDir, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] // byte[] m_szGameDir
		public byte[] GameDir; // m_szGameDir char [32]
		public string MapUTF8() => System.Text.Encoding.UTF8.GetString( Map, 0, System.Array.IndexOf<byte>( Map, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] // byte[] m_szMap
		public byte[] Map; // m_szMap char [32]
		public string GameDescriptionUTF8() => System.Text.Encoding.UTF8.GetString( GameDescription, 0, System.Array.IndexOf<byte>( GameDescription, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] // byte[] m_szGameDescription
		public byte[] GameDescription; // m_szGameDescription char [64]
		public uint AppID; // m_nAppID uint32
		public int Players; // m_nPlayers int
		public int MaxPlayers; // m_nMaxPlayers int
		public int BotPlayers; // m_nBotPlayers int
		[MarshalAs(UnmanagedType.I1)]
		public bool Password; // m_bPassword bool
		[MarshalAs(UnmanagedType.I1)]
		public bool Secure; // m_bSecure bool
		public uint TimeLastPlayed; // m_ulTimeLastPlayed uint32
		public int ServerVersion; // m_nServerVersion int
		public string ServerNameUTF8() => System.Text.Encoding.UTF8.GetString( ServerName, 0, System.Array.IndexOf<byte>( ServerName, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] // byte[] m_szServerName
		public byte[] ServerName; // m_szServerName char [64]
		public string GameTagsUTF8() => System.Text.Encoding.UTF8.GetString( GameTags, 0, System.Array.IndexOf<byte>( GameTags, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] // byte[] m_szGameTags
		public byte[] GameTags; // m_szGameTags char [128]
		public ulong SteamID; // m_steamID CSteamID
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public struct SteamPartyBeaconLocation_t
	{
		public SteamPartyBeaconLocationType Type; // m_eType ESteamPartyBeaconLocationType
		public ulong LocationID; // m_ulLocationID uint64
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public struct SteamParamStringArray_t
	{
		public IntPtr Strings; // m_ppStrings const char **
		public int NumStrings; // m_nNumStrings int32
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public struct LeaderboardEntry_t
	{
		public ulong SteamIDUser; // m_steamIDUser CSteamID
		public int GlobalRank; // m_nGlobalRank int32
		public int Score; // m_nScore int32
		public int CDetails; // m_cDetails int32
		public ulong UGC; // m_hUGC UGCHandle_t
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public struct P2PSessionState_t
	{
		public byte ConnectionActive; // m_bConnectionActive uint8
		public byte Connecting; // m_bConnecting uint8
		public byte P2PSessionError; // m_eP2PSessionError uint8
		public byte UsingRelay; // m_bUsingRelay uint8
		public int BytesQueuedForSend; // m_nBytesQueuedForSend int32
		public int PacketsQueuedForSend; // m_nPacketsQueuedForSend int32
		public uint RemoteIP; // m_nRemoteIP uint32
		public ushort RemotePort; // m_nRemotePort uint16
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public struct SteamUGCDetails_t
	{
		public PublishedFileId PublishedFileId; // m_nPublishedFileId PublishedFileId_t
		public Result Result; // m_eResult EResult
		public WorkshopFileType FileType; // m_eFileType EWorkshopFileType
		public AppId CreatorAppID; // m_nCreatorAppID AppId_t
		public AppId ConsumerAppID; // m_nConsumerAppID AppId_t
		public string TitleUTF8() => System.Text.Encoding.UTF8.GetString( Title, 0, System.Array.IndexOf<byte>( Title, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)] // byte[] m_rgchTitle
		public byte[] Title; // m_rgchTitle char [129]
		public string DescriptionUTF8() => System.Text.Encoding.UTF8.GetString( Description, 0, System.Array.IndexOf<byte>( Description, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8000)] // byte[] m_rgchDescription
		public byte[] Description; // m_rgchDescription char [8000]
		public ulong SteamIDOwner; // m_ulSteamIDOwner uint64
		public uint TimeCreated; // m_rtimeCreated uint32
		public uint TimeUpdated; // m_rtimeUpdated uint32
		public uint TimeAddedToUserList; // m_rtimeAddedToUserList uint32
		public RemoteStoragePublishedFileVisibility Visibility; // m_eVisibility ERemoteStoragePublishedFileVisibility
		[MarshalAs(UnmanagedType.I1)]
		public bool Banned; // m_bBanned bool
		[MarshalAs(UnmanagedType.I1)]
		public bool AcceptedForUse; // m_bAcceptedForUse bool
		[MarshalAs(UnmanagedType.I1)]
		public bool TagsTruncated; // m_bTagsTruncated bool
		public string TagsUTF8() => System.Text.Encoding.UTF8.GetString( Tags, 0, System.Array.IndexOf<byte>( Tags, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)] // byte[] m_rgchTags
		public byte[] Tags; // m_rgchTags char [1025]
		public ulong File; // m_hFile UGCHandle_t
		public ulong PreviewFile; // m_hPreviewFile UGCHandle_t
		public string PchFileNameUTF8() => System.Text.Encoding.UTF8.GetString( PchFileName, 0, System.Array.IndexOf<byte>( PchFileName, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)] // byte[] m_pchFileName
		public byte[] PchFileName; // m_pchFileName char [260]
		public int FileSize; // m_nFileSize int32
		public int PreviewFileSize; // m_nPreviewFileSize int32
		public string URLUTF8() => System.Text.Encoding.UTF8.GetString( URL, 0, System.Array.IndexOf<byte>( URL, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] // byte[] m_rgchURL
		public byte[] URL; // m_rgchURL char [256]
		public uint VotesUp; // m_unVotesUp uint32
		public uint VotesDown; // m_unVotesDown uint32
		public float Score; // m_flScore float
		public uint NumChildren; // m_unNumChildren uint32
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public struct SteamItemDetails_t
	{
		public InventoryItemId ItemId; // m_itemId SteamItemInstanceID_t
		public InventoryDefId Definition; // m_iDefinition SteamItemDef_t
		public ushort Quantity; // m_unQuantity uint16
		public ushort Flags; // m_unFlags uint16
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public partial struct SteamNetworkingPOPIDRender
	{
		public string BufUTF8() => System.Text.Encoding.UTF8.GetString( Buf, 0, System.Array.IndexOf<byte>( Buf, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] // byte[] buf
		public byte[] Buf; // buf char [8]
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public partial struct NetIdentityRender
	{
		public string BufUTF8() => System.Text.Encoding.UTF8.GetString( Buf, 0, System.Array.IndexOf<byte>( Buf, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] // byte[] buf
		public byte[] Buf; // buf char [128]
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public partial struct NetAddressRender
	{
		public string BufUTF8() => System.Text.Encoding.UTF8.GetString( Buf, 0, System.Array.IndexOf<byte>( Buf, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)] // byte[] buf
		public byte[] Buf; // buf char [48]
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public partial struct SteamDatagramHostedAddress
	{
		public int CbSize; // m_cbSize int
		public string DataUTF8() => System.Text.Encoding.UTF8.GetString( Data, 0, System.Array.IndexOf<byte>( Data, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] // byte[] m_data
		public byte[] Data; // m_data char [128]
		
	}
	
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPlatformPackSize )]
	public struct SteamDatagramGameCoordinatorServerLogin
	{
		public NetIdentity Dentity; // m_identity SteamNetworkingIdentity
		public SteamDatagramHostedAddress Outing; // m_routing SteamDatagramHostedAddress
		public AppId AppID; // m_nAppID AppId_t
		public uint Time; // m_rtime RTime32
		public int CbAppData; // m_cbAppData int
		public string AppDataUTF8() => System.Text.Encoding.UTF8.GetString( AppData, 0, System.Array.IndexOf<byte>( AppData, 0 ) );
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)] // byte[] m_appData
		public byte[] AppData; // m_appData char [2048]
		
	}
	
}
