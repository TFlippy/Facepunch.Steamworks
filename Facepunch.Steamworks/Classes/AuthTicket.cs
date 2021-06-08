using System;

namespace Steamworks
{
	public class AuthTicket: IDisposable
	{
		public byte[] Data;
		public uint Handle;

		/// <summary>
		/// Cancels a ticket. 
		/// You should cancel your ticket when you close the game or leave a server.
		/// </summary>
		public void Cancel()
		{
			if (this.Handle != 0)
			{
				SteamUser.Internal.CancelAuthTicket(this.Handle);
			}

			this.Handle = 0;
			this.Data = null;
		}

		public void Dispose()
		{
			this.Cancel();
		}
	}
}