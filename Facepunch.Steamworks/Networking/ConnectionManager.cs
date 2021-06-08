using Steamworks.Data;
using System;
using System.Runtime.CompilerServices;

namespace Steamworks
{
	public class ConnectionManager
	{
		/// <summary>
		/// An optional interface to use instead of deriving
		/// </summary>
		public IConnectionManager Interface { get; set; }

		/// <summary>
		/// The actual connection we're managing
		/// </summary>
		public Connection Connection;

		/// <summary>
		/// The last received ConnectionInfo
		/// </summary>
		public ConnectionInfo ConnectionInfo { get; set; }

		public bool Connected = false;
		public bool Connecting = true;

		public string ConnectionName
		{
			get => this.Connection.ConnectionName;
			set => this.Connection.ConnectionName = value;
		}

		public long UserData
		{
			get => this.Connection.UserData;
			set => this.Connection.UserData = value;
		}

		public void Close(bool linger = false, int reasonCode = 0, string debugString = "Closing Connection")
		{
			this.Connection.Close(linger, reasonCode, debugString);
		}

		public override string ToString()
		{
			return this.Connection.ToString();
		}

		public virtual void OnConnectionChanged(ConnectionInfo info)
		{
			this.ConnectionInfo = info;

			//
			// Some notes:
			// - Update state before the callbacks, in case an exception is thrown
			// - ConnectionState.None happens when a connection is destroyed, even if it was already disconnected (ClosedByPeer / ProblemDetectedLocally)
			//
			switch (info.State)
			{
				case ConnectionState.Connecting:
				if (!this.Connecting && !this.Connected)
				{
					this.Connecting = true;

					this.OnConnecting(info);
				}
				break;
				case ConnectionState.Connected:
				if (this.Connecting && !this.Connected)
				{
					this.Connecting = false;
					this.Connected = true;

					this.OnConnected(info);
				}
				break;
				case ConnectionState.ClosedByPeer:
				case ConnectionState.ProblemDetectedLocally:
				case ConnectionState.None:
				if (this.Connecting || this.Connected)
				{
					this.Connecting = false;
					this.Connected = false;

					this.OnDisconnected(info);
				}
				break;
			}
		}

		/// <summary>
		/// We're trying to connect!
		/// </summary>
		public virtual void OnConnecting(ConnectionInfo info)
		{
			this.Interface?.OnConnecting(info);
		}

		/// <summary>
		/// Client is connected. They move from connecting to Connections
		/// </summary>
		public virtual void OnConnected(ConnectionInfo info)
		{
			this.Interface?.OnConnected(info);
		}

		/// <summary>
		/// The connection has been closed remotely or disconnected locally. Check data.State for details.
		/// </summary>
		public virtual void OnDisconnected(ConnectionInfo info)
		{
			this.Interface?.OnDisconnected(info);
		}

		public unsafe void Receive(int bufferSize = 32)
		{
			var processed = 0;
			var messageBuffer = stackalloc IntPtr[bufferSize]; //IntPtr messageBuffer = Marshal.AllocHGlobal( IntPtr.Size * bufferSize );

			try
			{
				processed = SteamNetworkingSockets.Internal.ReceiveMessagesOnConnection(this.Connection, (IntPtr)messageBuffer, bufferSize);

				for (var i = 0; i < processed; i++)
				{
					this.ReceiveMessage(messageBuffer[i]);  // ReceiveMessage(Marshal.ReadIntPtr(messageBuffer, i * IntPtr.Size));
				}
			}
			finally
			{
				//Marshal.FreeHGlobal(messageBuffer);
			}

			// Overwhelmed our buffer, keep going
			if (processed == bufferSize) this.Receive(bufferSize);
		}

		public unsafe void ReceiveMessage(IntPtr msgPtr)
		{
			var msg = Unsafe.AsRef<NetMsg>(msgPtr.ToPointer()); // Marshal.PtrToStructure<NetMsg>( msgPtr );
			try
			{
				this.OnMessage(msg.DataPtr, msg.DataSize, msg.RecvTime, msg.MessageNumber, msg.Channel);
			}
			finally
			{
				// Releases the message
				NetMsg.InternalRelease((NetMsg*)msgPtr);
			}
		}

		public virtual void OnMessage(IntPtr data, int size, long messageNum, long recvTime, int channel)
		{
			this.Interface?.OnMessage(data, size, messageNum, recvTime, channel);
		}
	}
}