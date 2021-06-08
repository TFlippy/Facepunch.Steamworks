using Steamworks.Data;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Steamworks
{
	/// <summary>
	/// An awaitable version of a SteamAPICall_t
	/// </summary>
	public struct CallResult<T>: INotifyCompletion where T : struct, ICallbackData
	{
		private SteamAPICall_t call;
		private ISteamUtils utils;
		private bool server;

		public CallResult(SteamAPICall_t call, bool server)
		{
			this.call = call;
			this.server = server;

			this.utils = (server ? SteamUtils.InterfaceServer : SteamUtils.InterfaceClient) as ISteamUtils;

			if (this.utils == null)
				this.utils = SteamUtils.Interface as ISteamUtils;
		}

		/// <summary>
		/// This gets called if IsComplete returned false on the first call.
		/// The Action "continues" the async call. We pass it to the Dispatch
		/// to be called when the callback returns.
		/// </summary>
		public void OnCompleted(Action continuation)
		{
			if (this.IsCompleted)
				continuation();
			else
				Dispatch.OnCallComplete<T>(this.call, continuation, this.server);
		}

		/// <summary>
		/// Gets the result. This is called internally by the async shit.
		/// </summary>
		public T? GetResult()
		{
			var failed = false;
			if (!this.utils.IsAPICallCompleted(this.call, ref failed) || failed)
				return null;

			var t = default(T);
			var size = t.DataSize;
			var ptr = Marshal.AllocHGlobal(size);

			try
			{
				if (!this.utils.GetAPICallResult(this.call, ptr, size, (int)t.CallbackType, ref failed) || failed)
				{
					Dispatch.OnDebugCallback?.Invoke(t.CallbackType, "!GetAPICallResult or failed", this.server);
					return null;
				}

				Dispatch.OnDebugCallback?.Invoke(t.CallbackType, Dispatch.CallbackToString(t.CallbackType, ptr, size), this.server);

				return ((T)Marshal.PtrToStructure(ptr, typeof(T)));
			}
			finally
			{
				Marshal.FreeHGlobal(ptr);
			}
		}

		/// <summary>
		/// Return true if complete or failed
		/// </summary>
		public bool IsCompleted
		{
			get
			{
				var failed = false;
				if (this.utils.IsAPICallCompleted(this.call, ref failed) || failed)
					return true;

				return false;
			}
		}

		/// <summary>
		/// This is what makes this struct awaitable
		/// </summary>
		public CallResult<T> GetAwaiter()
		{
			return this;
		}
	}
}