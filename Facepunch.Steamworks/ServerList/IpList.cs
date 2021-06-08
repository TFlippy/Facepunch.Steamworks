using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steamworks.ServerList
{
	public class IpList: Internet
	{
		public List<string> Ips = new List<string>();
		private bool wantsCancel;

		public IpList(IEnumerable<string> list)
		{
			this.Ips.AddRange(list);
		}

		public IpList(params string[] list)
		{
			this.Ips.AddRange(list);
		}

		public override async Task<bool> RunQueryAsync(float timeoutSeconds = 10)
		{
			var blockSize = 16;
			var pointer = 0;

			var ips = this.Ips.ToArray();

			while (true)
			{
				var sublist = ips.Skip(pointer).Take(blockSize);
				if (sublist.Count() == 0)
					break;

				using (var list = new ServerList.Internet())
				{
					list.AddFilter("or", sublist.Count().ToString());

					foreach (var server in sublist)
					{
						list.AddFilter("gameaddr", server);
					}

					await list.RunQueryAsync(timeoutSeconds);

					if (this.wantsCancel)
						return false;

					this.Responsive.AddRange(list.Responsive);
					this.Responsive = this.Responsive.Distinct().ToList();
					this.Unresponsive.AddRange(list.Unresponsive);
					this.Unresponsive = this.Unresponsive.Distinct().ToList();
				}

				pointer += sublist.Count();

				this.InvokeChanges();
			}

			return true;
		}

		public override void Cancel()
		{
			this.wantsCancel = true;
		}
	}
}