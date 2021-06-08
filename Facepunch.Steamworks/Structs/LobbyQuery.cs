using System.Collections.Generic;
using System.Threading.Tasks;

namespace Steamworks.Data
{
	public struct LobbyQuery
	{
		// TODO FILTERS
		// AddRequestLobbyListStringFilter
		// - WithoutKeyValue

		#region Distance Filter
		public LobbyDistanceFilter? distance;

		/// <summary>
		/// only lobbies in the same immediate region will be returned
		/// </summary>
		public LobbyQuery FilterDistanceClose()
		{
			this.distance = LobbyDistanceFilter.Close;
			return this;
		}

		/// <summary>
		/// only lobbies in the same immediate region will be returned
		/// </summary>
		public LobbyQuery FilterDistanceFar()
		{
			this.distance = LobbyDistanceFilter.Far;
			return this;
		}

		/// <summary>
		/// only lobbies in the same immediate region will be returned
		/// </summary>
		public LobbyQuery FilterDistanceWorldwide()
		{
			this.distance = LobbyDistanceFilter.Worldwide;
			return this;
		}
		#endregion

		#region String key/value filter
		public Dictionary<string, string> stringFilters;

		/// <summary>
		/// Filter by specified key/value pair; string parameters
		/// </summary>
		public LobbyQuery WithKeyValue(string key, string value)
		{
			if (string.IsNullOrEmpty(key))
				throw new System.ArgumentException("Key string provided for LobbyQuery filter is null or empty", nameof(key));

			if (key.Length > SteamMatchmaking.MaxLobbyKeyLength)
				throw new System.ArgumentException($"Key length is longer than {SteamMatchmaking.MaxLobbyKeyLength}", nameof(key));

			if (this.stringFilters == null)
				this.stringFilters = new Dictionary<string, string>();

			this.stringFilters.Add(key, value);

			return this;
		}
		#endregion

		#region Numerical filters
		public List<NumericalFilter> numericalFilters;

		/// <summary>
		/// Numerical filter where value is less than the value provided
		/// </summary>
		public LobbyQuery WithLower(string key, int value)
		{
			this.AddNumericalFilter(key, value, LobbyComparison.LessThan);
			return this;
		}

		/// <summary>
		/// Numerical filter where value is greater than the value provided
		/// </summary>
		public LobbyQuery WithHigher(string key, int value)
		{
			this.AddNumericalFilter(key, value, LobbyComparison.GreaterThan);
			return this;
		}

		/// <summary>
		/// Numerical filter where value must be equal to the value provided
		/// </summary>
		public LobbyQuery WithEqual(string key, int value)
		{
			this.AddNumericalFilter(key, value, LobbyComparison.Equal);
			return this;
		}

		/// <summary>
		/// Numerical filter where value must not equal the value provided
		/// </summary>
		public LobbyQuery WithNotEqual(string key, int value)
		{
			this.AddNumericalFilter(key, value, LobbyComparison.NotEqual);
			return this;
		}

		/// <summary>
		/// Test key, initialize numerical filter list if necessary, then add new numerical filter
		/// </summary>
		public void AddNumericalFilter(string key, int value, LobbyComparison compare)
		{
			if (string.IsNullOrEmpty(key))
				throw new System.ArgumentException("Key string provided for LobbyQuery filter is null or empty", nameof(key));

			if (key.Length > SteamMatchmaking.MaxLobbyKeyLength)
				throw new System.ArgumentException($"Key length is longer than {SteamMatchmaking.MaxLobbyKeyLength}", nameof(key));

			if (this.numericalFilters == null)
				this.numericalFilters = new List<NumericalFilter>();

			this.numericalFilters.Add(new NumericalFilter(key, value, compare));
		}
		#endregion

		#region Near value filter
		public Dictionary<string, int> nearValFilters;

		/// <summary>
		/// Order filtered results according to key/values nearest the provided key/value pair.
		/// Can specify multiple near value filters; each successive filter is lower priority than the previous.
		/// </summary>
		public LobbyQuery OrderByNear(string key, int value)
		{
			if (string.IsNullOrEmpty(key))
				throw new System.ArgumentException("Key string provided for LobbyQuery filter is null or empty", nameof(key));

			if (key.Length > SteamMatchmaking.MaxLobbyKeyLength)
				throw new System.ArgumentException($"Key length is longer than {SteamMatchmaking.MaxLobbyKeyLength}", nameof(key));

			if (this.nearValFilters == null)
				this.nearValFilters = new Dictionary<string, int>();

			this.nearValFilters.Add(key, value);

			return this;
		}
		#endregion

		#region Slots Filter
		public int? slotsAvailable;

		/// <summary>
		/// returns only lobbies with the specified number of slots available
		/// </summary>
		public LobbyQuery WithSlotsAvailable(int minSlots)
		{
			this.slotsAvailable = minSlots;
			return this;
		}

		#endregion

		#region Max results filter
		public int? maxResults;

		/// <summary>
		/// sets how many results to return, the lower the count the faster it is to download the lobby results
		/// </summary>
		public LobbyQuery WithMaxResults(int max)
		{
			this.maxResults = max;
			return this;
		}

		#endregion

		private void ApplyFilters()
		{
			if (this.distance.HasValue)
			{
				SteamMatchmaking.Internal.AddRequestLobbyListDistanceFilter(this.distance.Value);
			}

			if (this.slotsAvailable.HasValue)
			{
				SteamMatchmaking.Internal.AddRequestLobbyListFilterSlotsAvailable(this.slotsAvailable.Value);
			}

			if (this.maxResults.HasValue)
			{
				SteamMatchmaking.Internal.AddRequestLobbyListResultCountFilter(this.maxResults.Value);
			}

			if (this.stringFilters != null)
			{
				foreach (var k in this.stringFilters)
				{
					SteamMatchmaking.Internal.AddRequestLobbyListStringFilter(k.Key, k.Value, LobbyComparison.Equal);
				}
			}

			if (this.numericalFilters != null)
			{
				foreach (var n in this.numericalFilters)
				{
					SteamMatchmaking.Internal.AddRequestLobbyListNumericalFilter(n.Key, n.Value, n.Comparer);
				}
			}

			if (this.nearValFilters != null)
			{
				foreach (var v in this.nearValFilters)
				{
					SteamMatchmaking.Internal.AddRequestLobbyListNearValueFilter(v.Key, v.Value);
				}
			}
		}

		/// <summary>
		/// Run the query, get the matching lobbies
		/// </summary>
		public async Task<Lobby[]> RequestAsync()
		{
			this.ApplyFilters();

			var list = await SteamMatchmaking.Internal.RequestLobbyList();
			if (!list.HasValue || list.Value.LobbiesMatching == 0)
			{
				return null;
			}

			var lobbies = new Lobby[list.Value.LobbiesMatching];

			for (var i = 0; i < list.Value.LobbiesMatching; i++)
			{
				lobbies[i] = new Lobby { Id = SteamMatchmaking.Internal.GetLobbyByIndex(i) };
			}

			return lobbies;
		}
	}
}