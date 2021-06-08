namespace Steamworks
{
	public struct SteamId
	{
		public ulong Value;

		public static implicit operator SteamId(ulong value) => new SteamId { Value = value };

		public static implicit operator ulong(SteamId value) => value.Value;

		public override string ToString()
		{
			return this.Value.ToString();
		}

		public uint AccountId => (uint)(this.Value & 0xFFFFFFFFul);

		public bool IsValid => this.Value != default;
	}
}