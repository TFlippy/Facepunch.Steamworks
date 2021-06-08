using Steamworks.Data;
using System;
using System.Runtime.InteropServices;

namespace Steamworks.Ugc
{
	public struct SteamParamStringArray: IDisposable
	{
		public SteamParamStringArray_t Value;
		private IntPtr[] NativeStrings;
		private IntPtr NativeArray;

		public static SteamParamStringArray From(string[] array)
		{
			var a = new SteamParamStringArray();

			a.NativeStrings = new IntPtr[array.Length];
			for (var i = 0; i < a.NativeStrings.Length; i++)
			{
				a.NativeStrings[i] = Marshal.StringToHGlobalAnsi(array[i]);
			}

			var size = Marshal.SizeOf(typeof(IntPtr)) * a.NativeStrings.Length;
			a.NativeArray = Marshal.AllocHGlobal(size);
			Marshal.Copy(a.NativeStrings, 0, a.NativeArray, a.NativeStrings.Length);

			a.Value = new SteamParamStringArray_t
			{
				Strings = a.NativeArray,
				NumStrings = array.Length
			};

			return a;
		}

		public void Dispose()
		{
			foreach (var x in this.NativeStrings)
				Marshal.FreeHGlobal(x);

			Marshal.FreeHGlobal(this.NativeArray);
		}
	}
}