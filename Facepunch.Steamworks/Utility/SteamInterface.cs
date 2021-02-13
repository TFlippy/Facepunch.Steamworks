using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	public abstract class SteamInterface
	{
		public virtual IntPtr GetUserInterfacePointer() => IntPtr.Zero;
		public virtual IntPtr GetServerInterfacePointer() => IntPtr.Zero;
		public virtual IntPtr GetGlobalInterfacePointer() => IntPtr.Zero;

		public IntPtr Self;
		public IntPtr SelfGlobal;
		public IntPtr SelfServer;
		public IntPtr SelfClient;

		public bool IsValid => Self != IntPtr.Zero;
		public bool IsServer { get; private set; }

		public void SetupInterface( bool gameServer )
		{
			if ( Self != IntPtr.Zero )
				return;

			IsServer = gameServer;
			SelfGlobal = GetGlobalInterfacePointer();
			Self = SelfGlobal;

			if ( Self != IntPtr.Zero )
				return;

			if ( gameServer )
			{
				SelfServer = GetServerInterfacePointer();
				Self = SelfServer;
			}
			else
			{
				SelfClient = GetUserInterfacePointer();
				Self = SelfClient;
			}
		}

		public void ShutdownInterface()
		{
			Self = IntPtr.Zero;
		}
	}

	public abstract class SteamClass
	{
		public abstract void InitializeInterface( bool server );
		public abstract void DestroyInterface( bool server );
	}

	public class SteamSharedClass<T> : SteamClass
	{
		public static SteamInterface Interface => InterfaceClient ?? InterfaceServer;
		public static SteamInterface InterfaceClient;
		public static SteamInterface InterfaceServer;

		public override void InitializeInterface( bool server )
		{

		}

		public virtual void SetInterface( bool server, SteamInterface iface )
		{
			if ( server )
			{
				InterfaceServer = iface;
			}

			if ( !server )
			{
				InterfaceClient = iface;
			}
		}

		public override void DestroyInterface( bool server )
		{
			if ( !server )
			{
				InterfaceClient = null;
			}

			if ( server )
			{
				InterfaceServer = null;
			}
		}
	}

	public class SteamClientClass<T> : SteamClass
	{
		public static SteamInterface Interface;

		public override void InitializeInterface( bool server )
		{

		}

		public virtual void SetInterface( bool server, SteamInterface iface )
		{
			if ( server )
				throw new System.NotSupportedException();

			Interface = iface;
		}

		public override void DestroyInterface( bool server )
		{
			Interface = null;
		}
	}	
	
	public class SteamServerClass<T> : SteamClass
	{
		public static SteamInterface Interface;

		public override void InitializeInterface( bool server )
		{

		}

		public virtual void SetInterface( bool server, SteamInterface iface )
		{
			if ( !server )
				throw new System.NotSupportedException();

			Interface = iface;
		}

		public override void DestroyInterface( bool server )
		{
			Interface = null;
		}
	}

}