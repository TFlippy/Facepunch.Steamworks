using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Steamworks.ServerList
{
	public abstract class Base: IDisposable
	{

		#region ISteamMatchmakingServers
		public static ISteamMatchmakingServers Internal => SteamMatchmakingServers.Internal;
		#endregion


		/// <summary>
		/// Which app we're querying. Defaults to the current app.
		/// </summary>
		public AppId AppId { get; set; }

		/// <summary>
		/// When a new server is added, this function will get called
		/// </summary>
		public event Action OnChanges;

		/// <summary>
		/// Called for every responsive server
		/// </summary>
		public event Action<ServerInfo> OnResponsiveServer;

		/// <summary>
		/// A list of servers that responded. If you're only interested in servers that responded since you
		/// last updated, then simply clear this list.
		/// </summary>
		public List<ServerInfo> Responsive = new List<ServerInfo>();

		/// <summary>
		/// A list of servers that were in the master list but didn't respond. 
		/// </summary>
		public List<ServerInfo> Unresponsive = new List<ServerInfo>();


		public Base()
		{
			this.AppId = SteamClient.AppId; // Default AppId is this 
		}

		/// <summary>
		/// Query the server list. Task result will be true when finished
		/// </summary>
		/// <returns></returns>
		public virtual async Task<bool> RunQueryAsync(float timeoutSeconds = 10)
		{
			var stopwatch = System.Diagnostics.Stopwatch.StartNew();

			this.Reset();
			this.LaunchQuery();

			var thisRequest = this.request;

			while (this.IsRefreshing)
			{
				await Task.Delay(33);

				//
				// The request has been cancelled or changed in some way
				//
				if (this.request.Value == IntPtr.Zero || thisRequest.Value != this.request.Value)
					return false;

				if (!SteamClient.IsValid)
					return false;

				var r = this.Responsive.Count;

				this.UpdatePending();
				this.UpdateResponsive();

				if (r != this.Responsive.Count)
				{
					this.InvokeChanges();
				}

				if (stopwatch.Elapsed.TotalSeconds > timeoutSeconds)
					break;
			}

			this.MovePendingToUnresponsive();
			this.InvokeChanges();

			return true;
		}

		public virtual void Cancel()
		{
			Internal.CancelQuery(this.request);
		}

		// Overrides
		public abstract void LaunchQuery();

		public HServerListRequest request;

		#region Filters

		public List<MatchMakingKeyValuePair> filters = new List<MatchMakingKeyValuePair>();
		public virtual MatchMakingKeyValuePair[] GetFilters()
		{
			return this.filters.ToArray();
		}

		public void AddFilter(string key, string value)
		{
			this.filters.Add(new MatchMakingKeyValuePair { Key = key, Value = value });
		}

		#endregion

		public int Count => Internal.GetServerCount(this.request);
		public bool IsRefreshing => this.request.Value != IntPtr.Zero && Internal.IsRefreshing(this.request);
		public List<int> watchList = new List<int>();
		public int LastCount = 0;

		private void Reset()
		{
			this.ReleaseQuery();
			this.LastCount = 0;
			this.watchList.Clear();
		}

		private void ReleaseQuery()
		{
			if (this.request.Value != IntPtr.Zero)
			{
				this.Cancel();
				Internal.ReleaseRequest(this.request);
				this.request = IntPtr.Zero;
			}
		}

		public void Dispose()
		{
			this.ReleaseQuery();
		}

		public void InvokeChanges()
		{
			OnChanges?.Invoke();
		}

		private void UpdatePending()
		{
			var count = this.Count;
			if (count == this.LastCount) return;

			for (var i = this.LastCount; i < count; i++)
			{
				this.watchList.Add(i);
			}

			this.LastCount = count;
		}

		public void UpdateResponsive()
		{
			this.watchList.RemoveAll(x =>
		   {
			   var info = Internal.GetServerDetails(this.request, x);
			   if (info.HadSuccessfulResponse)
			   {
				   this.OnServer(ServerInfo.From(info), info.HadSuccessfulResponse);
				   return true;
			   }

			   return false;
		   });
		}

		private void MovePendingToUnresponsive()
		{
			this.watchList.RemoveAll(x =>
		   {
			   var info = Internal.GetServerDetails(this.request, x);
			   this.OnServer(ServerInfo.From(info), info.HadSuccessfulResponse);
			   return true;
		   });
		}

		private void OnServer(ServerInfo serverInfo, bool responded)
		{
			if (responded)
			{
				this.Responsive.Add(serverInfo);
				OnResponsiveServer?.Invoke(serverInfo);
				return;
			}

			this.Unresponsive.Add(serverInfo);
		}
	}
}