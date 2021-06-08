namespace Steamworks.Data
{
	public struct DepotId
	{
		public uint Value;

		public static implicit operator DepotId(uint value) => new DepotId { Value = value };

		public static implicit operator DepotId(int value) => new DepotId { Value = (uint)value };

		public static implicit operator uint(DepotId value) => value.Value;

		public override string ToString()
		{
			return this.Value.ToString();
		}
	}
}