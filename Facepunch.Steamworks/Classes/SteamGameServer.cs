using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public static class SteamGameServer
	{
		public static class Native
		{
			[DllImport( Platform.LibraryName, EntryPoint = "SteamGameServer_RunCallbacks", CallingConvention = CallingConvention.Cdecl )]
			public static extern void SteamGameServer_RunCallbacks();
			
			[DllImport( Platform.LibraryName, EntryPoint = "SteamGameServer_Shutdown", CallingConvention = CallingConvention.Cdecl )]
			public static extern void SteamGameServer_Shutdown();
			
			[DllImport( Platform.LibraryName, EntryPoint = "SteamGameServer_GetHSteamPipe", CallingConvention = CallingConvention.Cdecl )]
			public static extern HSteamPipe SteamGameServer_GetHSteamPipe();
			
		}
		static public void RunCallbacks()
		{
			Native.SteamGameServer_RunCallbacks();
		}
		
		static public void Shutdown()
		{
			Native.SteamGameServer_Shutdown();
		}
		
		static public HSteamPipe GetHSteamPipe()
		{
			return Native.SteamGameServer_GetHSteamPipe();
		}
		
	}
}
