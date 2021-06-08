using Steamworks.Data;
using System.Collections.Generic;

namespace Steamworks
{
	/// <summary>
	/// Used as a base to create your networking server. This creates a socket
	/// and listens/communicates with multiple queries.
	/// 
	/// You can override all the virtual functions to turn it into what you
	/// want it to do.
	/// </summary>
	public partial class SocketManager
	{
		public ISocketManager Interface { get; set; }

		public object mutex = new();

		public HashSet<Connection> Connecting = new HashSet<Connection>();
		public HashSet<Connection> Connected = new HashSet<Connection>();

		public Socket Socket { get; set; }

		public override string ToString()
		{
			return this.Socket.ToString();
		}

		public HSteamNetPollGroup pollGroup;

		public void Initialize()
		{
			this.pollGroup = SteamNetworkingSockets.Internal.CreatePollGroup();
		}

		public bool Close()
		{
			if (SteamNetworkingSockets.Internal.IsValid)
			{
				SteamNetworkingSockets.Internal.DestroyPollGroup(this.pollGroup);
				this.Socket.Close();
			}

			this.pollGroup = 0;
			this.Socket = 0;
			return true;
		}

		public virtual void OnConnectionChanged(Connection connection, ConnectionInfo info)
		{
			lock (this.mutex)
			{
				//
				// Some notes:
				// - Update state before the callbacks, in case an exception is thrown
				// - ConnectionState.None happens when a connection is destroyed, even if it was already disconnected (ClosedByPeer / ProblemDetectedLocally)
				//
				switch (info.State)
				{
					case ConnectionState.Connecting:
					if (!this.Connecting.Contains(connection) && !this.Connected.Contains(connection))
					{
						this.Connecting.Add(connection);

						this.OnConnecting(connection, info);
					}
					break;
					case ConnectionState.Connected:
					if (this.Connecting.Contains(connection) && !this.Connected.Contains(connection))
					{
						this.Connecting.Remove(connection);
						this.Connected.Add(connection);

						this.OnConnected(connection, info);
					}
					break;
					case ConnectionState.ClosedByPeer:
					case ConnectionState.ProblemDetectedLocally:
					case ConnectionState.None:
					if (this.Connecting.Contains(connection) || this.Connected.Contains(connection))
					{
						this.Connecting.Remove(connection);
						this.Connected.Remove(connection);

						this.OnDisconnected(connection, info);
					}
					break;
				}
			}
		}

		/// <summary>
		/// Default behaviour is to accept every connection
		/// </summary>
		public virtual void OnConnecting(Connection connection, ConnectionInfo info)
		{
			if (this.Interface != null)
			{
				this.Interface.OnConnecting(connection, info);
			}
			else
			{
				connection.Accept();
			}
		}

		/// <summary>
		/// Client is connected. They move from connecting to Connections
		/// </summary>
		public virtual void OnConnected(Connection connection, ConnectionInfo info)
		{
			SteamNetworkingSockets.Internal.SetConnectionPollGroup(connection, this.pollGroup);

			this.Interface?.OnConnected(connection, info);
		}

		/// <summary>
		/// The connection has been closed remotely or disconnected locally. Check data.State for details.
		/// </summary>
		public virtual void OnDisconnected(Connection connection, ConnectionInfo info)
		{
			if (this.Interface != null)
			{
				this.Interface.OnDisconnected(connection, info);
			}
			else
			{
				connection.Close();
			}
		}
	}
}