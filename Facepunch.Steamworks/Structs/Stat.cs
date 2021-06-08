using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Steamworks.Data
{
	public struct Stat
	{
		public string Name { get; set; }
		public SteamId UserId { get; set; }

		public Stat(string name)
		{
			this.Name = name;
			this.UserId = 0;
		}

		public Stat(string name, SteamId user)
		{
			this.Name = name;
			this.UserId = user;
		}

		public void LocalUserOnly([CallerMemberName] string caller = null)
		{
			if (this.UserId == 0) return;
			throw new System.Exception($"Stat.{caller} can only be called for the local user");
		}

		public double GetGlobalFloat()
		{
			var val = 0.0;

			if (SteamUserStats.Internal.GetGlobalStat(this.Name, ref val))
				return val;

			return 0;
		}

		public long GetGlobalInt()
		{
			long val = 0;
			SteamUserStats.Internal.GetGlobalStat(this.Name, ref val);
			return val;
		}

		public async Task<long[]> GetGlobalIntDaysAsync(int days)
		{
			var result = await SteamUserStats.Internal.RequestGlobalStats(days);
			if (result?.Result != Result.OK) return null;

			var r = new long[days];

			var rows = SteamUserStats.Internal.GetGlobalStatHistory(this.Name, r, (uint)r.Length * sizeof(long));

			if (days != rows)
				r = r.Take(rows).ToArray();

			return r;
		}

		public async Task<double[]> GetGlobalFloatDays(int days)
		{
			var result = await SteamUserStats.Internal.RequestGlobalStats(days);
			if (result?.Result != Result.OK) return null;

			var r = new double[days];

			var rows = SteamUserStats.Internal.GetGlobalStatHistory(this.Name, r, (uint)r.Length * sizeof(double));

			if (days != rows)
				r = r.Take(rows).ToArray();

			return r;
		}

		public float GetFloat()
		{
			var val = 0.0f;

			if (this.UserId > 0)
			{
				SteamUserStats.Internal.GetUserStat(this.UserId, this.Name, ref val);
			}
			else
			{
				SteamUserStats.Internal.GetStat(this.Name, ref val);
			}

			return 0;
		}

		public int GetInt()
		{
			var val = 0;

			if (this.UserId > 0)
			{
				SteamUserStats.Internal.GetUserStat(this.UserId, this.Name, ref val);
			}
			else
			{
				SteamUserStats.Internal.GetStat(this.Name, ref val);
			}

			return val;
		}

		public bool Set(int val)
		{
			this.LocalUserOnly();
			return SteamUserStats.Internal.SetStat(this.Name, val);
		}

		public bool Set(float val)
		{
			this.LocalUserOnly();
			return SteamUserStats.Internal.SetStat(this.Name, val);
		}

		public bool Add(int val)
		{
			this.LocalUserOnly();
			return this.Set(this.GetInt() + val);
		}

		public bool Add(float val)
		{
			this.LocalUserOnly();
			return this.Set(this.GetFloat() + val);
		}

		public bool UpdateAverageRate(float count, float sessionlength)
		{
			this.LocalUserOnly();
			return SteamUserStats.Internal.UpdateAvgRateStat(this.Name, count, sessionlength);
		}

		public bool Store()
		{
			this.LocalUserOnly();
			return SteamUserStats.Internal.StoreStats();
		}
	}
}