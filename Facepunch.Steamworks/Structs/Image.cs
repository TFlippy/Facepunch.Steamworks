
namespace Steamworks.Data
{
	public struct Image
	{
		public uint Width;
		public uint Height;
		public byte[] Data;

		public Color GetPixel(int x, int y)
		{
			if (x < 0 || x >= this.Width) throw new System.Exception("x out of bounds");
			if (y < 0 || y >= this.Height) throw new System.Exception("y out of bounds");

			var c = new Color();

			var i = (y * this.Width + x) * 4;

			c.r = this.Data[i + 0];
			c.g = this.Data[i + 1];
			c.b = this.Data[i + 2];
			c.a = this.Data[i + 3];

			return c;
		}

		public override string ToString()
		{
			return $"{this.Width}x{this.Height} ({this.Data.Length}bytes)";
		}
	}

	public struct Color
	{
		public byte r, g, b, a;
	}
}