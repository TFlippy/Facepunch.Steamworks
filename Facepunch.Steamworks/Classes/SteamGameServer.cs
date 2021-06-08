using Steamworks.Data;
using System.Runtime.InteropServices;


namespace Steamworks
{
	public static class SteamGameServer
	{
		public static class Native
		{
			[DllImport(Platform.LibraryName, EntryPoint = "SteamGameServer_RunCallbacks", CallingConvention = CallingConvention.Cdecl)]
			public static extern void SteamGameServer_RunCallbacks();

			[DllImport(Platform.LibraryName, EntryPoint = "SteamGameServer_Shutdown", CallingConvention = CallingConvention.Cdecl)]
			public static extern void SteamGameServer_Shutdown();

			[DllImport(Platform.LibraryName, EntryPoint = "SteamGameServer_GetHSteamPipe", CallingConvention = CallingConvention.Cdecl)]
			public static extern HSteamPipe SteamGameServer_GetHSteamPipe();

		}
		public static void RunCallbacks()
		{
			Native.SteamGameServer_RunCallbacks();
		}

		public static void Shutdown()
		{
			Native.SteamGameServer_Shutdown();
		}

		public static HSteamPipe GetHSteamPipe()
		{
			return Native.SteamGameServer_GetHSteamPipe();
		}

	}
}
