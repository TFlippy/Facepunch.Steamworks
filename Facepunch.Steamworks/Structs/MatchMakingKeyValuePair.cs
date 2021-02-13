using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	[StructLayout( LayoutKind.Sequential, Pack = Platform.StructPackSize )]
	public partial struct MatchMakingKeyValuePair
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string Key;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string Value;
	}
	
}
