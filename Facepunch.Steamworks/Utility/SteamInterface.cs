using System;

namespace Steamworks
{
	public abstract class SteamInterface
	{
		public virtual IntPtr GetUserInterfacePointer()
		{
			return IntPtr.Zero;
		}

		public virtual IntPtr GetServerInterfacePointer()
		{
			return IntPtr.Zero;
		}

		public virtual IntPtr GetGlobalInterfacePointer()
		{
			return IntPtr.Zero;
		}

		public IntPtr Self;
		public IntPtr SelfGlobal;
		public IntPtr SelfServer;
		public IntPtr SelfClient;

		public bool IsValid => this.Self != IntPtr.Zero;
		public bool IsServer { get; private set; }

		public void SetupInterface(bool gameServer)
		{
			if (this.Self != IntPtr.Zero)
				return;

			this.IsServer = gameServer;
			this.SelfGlobal = this.GetGlobalInterfacePointer();
			this.Self = this.SelfGlobal;

			if (this.Self != IntPtr.Zero)
				return;

			if (gameServer)
			{
				this.SelfServer = this.GetServerInterfacePointer();
				this.Self = this.SelfServer;
			}
			else
			{
				this.SelfClient = this.GetUserInterfacePointer();
				this.Self = this.SelfClient;
			}
		}

		public void ShutdownInterface()
		{
			this.Self = IntPtr.Zero;
		}
	}

	public abstract class SteamClass
	{
		public abstract void InitializeInterface(bool server);
		public abstract void DestroyInterface(bool server);
	}

	public class SteamSharedClass<T>: SteamClass
	{
		public static SteamInterface Interface => InterfaceClient ?? InterfaceServer;
		public static SteamInterface InterfaceClient;
		public static SteamInterface InterfaceServer;

		public override void InitializeInterface(bool server)
		{

		}

		public virtual void SetInterface(bool server, SteamInterface iface)
		{
			if (server)
			{
				InterfaceServer = iface;
			}

			if (!server)
			{
				InterfaceClient = iface;
			}
		}

		public override void DestroyInterface(bool server)
		{
			if (!server)
			{
				InterfaceClient = null;
			}

			if (server)
			{
				InterfaceServer = null;
			}
		}
	}

	public class SteamClientClass<T>: SteamClass
	{
		public static SteamInterface Interface;

		public override void InitializeInterface(bool server)
		{

		}

		public virtual void SetInterface(bool server, SteamInterface iface)
		{
			if (server)
				throw new System.NotSupportedException();

			Interface = iface;
		}

		public override void DestroyInterface(bool server)
		{
			Interface = null;
		}
	}

	public class SteamServerClass<T>: SteamClass
	{
		public static SteamInterface Interface;

		public override void InitializeInterface(bool server)
		{

		}

		public virtual void SetInterface(bool server, SteamInterface iface)
		{
			if (!server)
				throw new System.NotSupportedException();

			Interface = iface;
		}

		public override void DestroyInterface(bool server)
		{
			Interface = null;
		}
	}

}