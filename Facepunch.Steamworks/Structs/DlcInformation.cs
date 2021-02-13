using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


namespace Steamworks.Data
{
	public struct DlcInformation
	{
		public AppId AppId { get; set; }
		public string Name { get; set; }
		public bool Available { get; set; }
	}
}