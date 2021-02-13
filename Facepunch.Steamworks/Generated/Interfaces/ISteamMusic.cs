using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	public class ISteamMusic : SteamInterface
	{
		
		public ISteamMusic( bool IsGameServer )
		{
			SetupInterface( IsGameServer );
		}
		
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_SteamMusic_v001", CallingConvention = Platform.CC)]
		public static extern IntPtr SteamAPI_SteamMusic_v001();
		public override IntPtr GetUserInterfacePointer() => SteamAPI_SteamMusic_v001();
		
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_BIsEnabled", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _BIsEnabled( IntPtr self );
		
		#endregion
		public bool BIsEnabled()
		{
			var returnValue = _BIsEnabled( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_BIsPlaying", CallingConvention = Platform.CC)]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _BIsPlaying( IntPtr self );
		
		#endregion
		public bool BIsPlaying()
		{
			var returnValue = _BIsPlaying( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_GetPlaybackStatus", CallingConvention = Platform.CC)]
		private static extern MusicStatus _GetPlaybackStatus( IntPtr self );
		
		#endregion
		public MusicStatus GetPlaybackStatus()
		{
			var returnValue = _GetPlaybackStatus( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_Play", CallingConvention = Platform.CC)]
		private static extern void _Play( IntPtr self );
		
		#endregion
		public void Play()
		{
			_Play( Self );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_Pause", CallingConvention = Platform.CC)]
		private static extern void _Pause( IntPtr self );
		
		#endregion
		public void Pause()
		{
			_Pause( Self );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_PlayPrevious", CallingConvention = Platform.CC)]
		private static extern void _PlayPrevious( IntPtr self );
		
		#endregion
		public void PlayPrevious()
		{
			_PlayPrevious( Self );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_PlayNext", CallingConvention = Platform.CC)]
		private static extern void _PlayNext( IntPtr self );
		
		#endregion
		public void PlayNext()
		{
			_PlayNext( Self );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_SetVolume", CallingConvention = Platform.CC)]
		private static extern void _SetVolume( IntPtr self, float flVolume );
		
		#endregion
		public void SetVolume( float flVolume )
		{
			_SetVolume( Self, flVolume );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamMusic_GetVolume", CallingConvention = Platform.CC)]
		private static extern float _GetVolume( IntPtr self );
		
		#endregion
		public float GetVolume()
		{
			var returnValue = _GetVolume( Self );
			return returnValue;
		}
		
	}
}
