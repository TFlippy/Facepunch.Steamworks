using Steamworks.Data;
using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	[StructLayout( LayoutKind.Explicit, Pack = Platform.StructPlatformPackSize )]
	public partial struct NetKeyValue
	{
		[FieldOffset(0)]
		public NetConfig Value; // m_eValue ESteamNetworkingConfigValue

		[FieldOffset( 4 )]
		public NetConfigType DataType; // m_eDataType ESteamNetworkingConfigDataType

		[FieldOffset( 8 )]
		public long Int64Value; // m_int64 int64_t

		[FieldOffset( 8 )]
		public int Int32Value; // m_val_int32 int32_t

		[FieldOffset( 8 )]
		public float FloatValue; // m_val_float float

		[FieldOffset( 8 )]
		public IntPtr PointerValue; // m_val_functionPtr void *


		// TODO - support strings, maybe
	}
}