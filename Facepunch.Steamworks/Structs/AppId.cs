namespace Steamworks
{
	public struct AppId
	{
		public uint Value;

		public override string ToString()
		{
			return this.Value.ToString();
		}

		public static implicit operator AppId(uint value) => new AppId { Value = value };

		public static implicit operator AppId(int value) => new AppId { Value = (uint)value };

		public static implicit operator uint(AppId value) => value.Value;
	}
}