
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Socket
	{
		public uint Id;
		public override string ToString()
		{
			return this.Id.ToString();
		}

		public static implicit operator Socket(uint value) => new Socket() { Id = value };
		public static implicit operator uint(Socket value) => value.Id;

		/// <summary>
		/// Destroy a listen socket.  All the connections that were accepting on the listen
		/// socket are closed ungracefully.
		/// </summary>
		public bool Close()
		{
			return SteamNetworkingSockets.Internal.CloseListenSocket(this.Id);
		}

		public SocketManager Manager
		{
			get => SteamNetworkingSockets.GetSocketManager(this.Id);
			set => SteamNetworkingSockets.SetSocketManager(this.Id, value);
		}
	}
}