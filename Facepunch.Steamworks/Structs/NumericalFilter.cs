namespace Steamworks.Data
{
	public struct NumericalFilter
	{
		public string Key { get; set; }
		public int Value { get; set; }
		public LobbyComparison Comparer { get; set; }

		public NumericalFilter ( string k, int v, LobbyComparison c )
		{
			Key = k;
			Value = v;
			Comparer = c;
		}
	}
}
