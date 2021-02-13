using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public static class SteamAPI
	{
		public static class Native
		{
			[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_Init", CallingConvention = CallingConvention.Cdecl )]
			[return: MarshalAs( UnmanagedType.I1 )]
			public static extern bool SteamAPI_Init();

			[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_Shutdown", CallingConvention = CallingConvention.Cdecl )]
			public static extern void SteamAPI_Shutdown();
						
			[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_GetHSteamPipe", CallingConvention = CallingConvention.Cdecl )]
			public static extern HSteamPipe SteamAPI_GetHSteamPipe();
			
			[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_RestartAppIfNecessary", CallingConvention = CallingConvention.Cdecl )]
			[return: MarshalAs( UnmanagedType.I1 )]
			public static extern bool SteamAPI_RestartAppIfNecessary( uint unOwnAppID );
			
		}
		static public bool Init()
		{
			return Native.SteamAPI_Init();
		}
		
		static public void Shutdown()
		{
			Native.SteamAPI_Shutdown();
		}
				
		static public HSteamPipe GetHSteamPipe()
		{
			return Native.SteamAPI_GetHSteamPipe();
		}
		
		static public bool RestartAppIfNecessary( uint unOwnAppID )
		{
			return Native.SteamAPI_RestartAppIfNecessary( unOwnAppID );
		}
		
	}
}
