﻿using System.Net;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	[StructLayout(LayoutKind.Explicit, Size = 18, Pack = 1)]
	public partial struct NetAddress
	{
		[FieldOffset(0)]
		public IPV4 ip;

		[FieldOffset(16)]
		public ushort port;

		public struct IPV4
		{
			public ulong m_8zeros;
			public ushort m_0000;
			public ushort m_ffff;
			public byte ip0;
			public byte ip1;
			public byte ip2;
			public byte ip3;
		}

		/// <summary>
		/// The Port. This is redundant documentation.
		/// </summary>
		public ushort Port => this.port;

		/// <summary>
		/// Any IP, specific port
		/// </summary>
		public static NetAddress AnyIp(ushort port)
		{
			var addr = Cleared;
			addr.port = port;
			return addr;
		}

		/// <summary>
		/// Localhost IP, specific port
		/// </summary>
		public static NetAddress LocalHost(ushort port)
		{
			var local = Cleared;
			InternalSetIPv6LocalHost(ref local, port);
			return local;
		}

		/// <summary>
		/// Specific IP, specific port
		/// </summary>
		public static NetAddress From(string addrStr, ushort port)
		{
			return From(IPAddress.Parse(addrStr), port);
		}

		/// <summary>
		/// Specific IP, specific port
		/// </summary>
		public static NetAddress From(IPAddress address, ushort port)
		{
			var addr = address.GetAddressBytes();

			if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
			{
				var local = Cleared;
				InternalSetIPv4(ref local, Utility.IpToInt32(address), port);
				return local;
			}

			throw new System.NotImplementedException("Oops - no IPV6 support yet?");
		}

		/// <summary>
		/// Set everything to zero
		/// </summary>
		public static NetAddress Cleared
		{
			get
			{
				NetAddress self = default;
				InternalClear(ref self);
				return self;
			}
		}

		/// <summary>
		/// Return true if the IP is ::0.  (Doesn't check port.)
		/// </summary>
		public bool IsIPv6AllZeros
		{
			get
			{
				var self = this;
				return InternalIsIPv6AllZeros(ref self);
			}
		}

		/// <summary>
		/// Return true if IP is mapped IPv4
		/// </summary>
		public bool IsIPv4
		{
			get
			{
				var self = this;
				return InternalIsIPv4(ref self);
			}
		}

		/// <summary>
		/// Return true if this identity is localhost.  (Either IPv6 ::1, or IPv4 127.0.0.1)
		/// </summary>
		public bool IsLocalHost
		{
			get
			{
				var self = this;
				return InternalIsLocalHost(ref self);
			}
		}

		/// <summary>
		/// Get the Address section
		/// </summary>
		public IPAddress Address
		{
			get
			{
				if (this.IsIPv4)
				{
					var self = this;
					var ip = InternalGetIPv4(ref self);
					return Utility.Int32ToIp(ip);
				}

				if (this.IsIPv6AllZeros)
				{
					return IPAddress.IPv6Loopback;
				}

				throw new System.NotImplementedException("Oops - no IPV6 support yet?");
			}
		}

		public override string ToString()
		{
			var ptr = Helpers.TakeMemory();
			var self = this;
			InternalToString(ref self, ptr, Helpers.MemoryBufferSize, true);
			return Helpers.MemoryToString(ptr);
		}
	}
}
