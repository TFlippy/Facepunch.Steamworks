
using Steamworks.Data;

namespace Steamworks.Data
{
	public unsafe struct NetErrorMessage
	{
		public fixed char Value[1024];
	}
}