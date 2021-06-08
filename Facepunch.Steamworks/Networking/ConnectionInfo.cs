using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	/// <summary>
	/// Describe the state of a connection
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Size = 696)]
	public struct ConnectionInfo
	{
		public NetIdentity identity;
		public long userData;
		public Socket listenSocket;
		public NetAddress address;
		public ushort pad;
		public SteamNetworkingPOPID popRemote;
		public SteamNetworkingPOPID popRelay;
		public ConnectionState state;
		public int endReason;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string endDebug;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string connectionDescription;

		/// <summary>
		/// High level state of the connection
		/// </summary>
		public ConnectionState State => this.state;

		/// <summary>
		/// Remote address.  Might be all 0's if we don't know it, or if this is N/A.
		/// </summary>
		public NetAddress Address => this.address;

		/// <summary>
		/// Who is on the other end?  Depending on the connection type and phase of the connection, we might not know
		/// </summary>
		public NetIdentity Identity => this.identity;

		/// <summary>
		/// Basic cause of the connection termination or problem.
		/// </summary>
		public NetConnectionEnd EndReason => (NetConnectionEnd)this.endReason;
	}
}