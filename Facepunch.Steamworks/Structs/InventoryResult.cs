using Steamworks.Data;
using System;
using System.Threading.Tasks;

namespace Steamworks
{
	public struct InventoryResult: IDisposable
	{
		public SteamInventoryResult_t _id;

		public bool Expired { get; set; }

		public InventoryResult(SteamInventoryResult_t id, bool expired)
		{
			this._id = id;
			this.Expired = expired;
		}

		public int ItemCount
		{
			get
			{
				uint cnt = 0;

				if (!SteamInventory.Internal.GetResultItems(this._id, null, ref cnt))
					return 0;

				return (int)cnt;
			}
		}

		/// <summary>
		/// Checks whether an inventory result handle belongs to the specified Steam ID.
		/// This is important when using Deserialize, to verify that a remote player is not pretending to have a different user's inventory
		/// </summary>
		public bool BelongsTo(SteamId steamId)
		{
			return SteamInventory.Internal.CheckResultSteamID(this._id, steamId);
		}

		public InventoryItem[] GetItems(bool includeProperties = false)
		{
			var cnt = (uint)this.ItemCount;
			if (cnt <= 0) return null;

			var pOutItemsArray = new SteamItemDetails_t[cnt];

			if (!SteamInventory.Internal.GetResultItems(this._id, pOutItemsArray, ref cnt))
				return null;

			var items = new InventoryItem[cnt];

			for (var i = 0; i < cnt; i++)
			{
				var item = InventoryItem.From(pOutItemsArray[i]);

				if (includeProperties)
					item._properties = InventoryItem.GetProperties(this._id, i);

				items[i] = item;
			}


			return items;
		}

		public void Dispose()
		{
			if (this._id.Value == -1) return;

			SteamInventory.Internal.DestroyResult(this._id);
		}

		public static async Task<InventoryResult?> GetAsync(SteamInventoryResult_t sresult)
		{
			var _result = Result.Pending;
			while (_result == Result.Pending)
			{
				_result = SteamInventory.Internal.GetResultStatus(sresult);
				await Task.Delay(10);
			}

			if (_result != Result.OK && _result != Result.Expired)
				return null;

			return new InventoryResult(sresult, _result == Result.Expired);
		}

		/// <summary>
		/// Serialized result sets contain a short signature which can't be forged or replayed across different game sessions.
		/// A result set can be serialized on the local client, transmitted to other players via your game networking, and 
		/// deserialized by the remote players.This is a secure way of preventing hackers from lying about posessing 
		/// rare/high-value items. Serializes a result set with signature bytes to an output buffer.The size of a serialized 
		/// result depends on the number items which are being serialized.When securely transmitting items to other players, 
		/// it is recommended to use GetItemsByID first to create a minimal result set.
		/// Results have a built-in timestamp which will be considered "expired" after an hour has elapsed.See DeserializeResult
		/// for expiration handling.
		/// </summary>
		public unsafe byte[] Serialize()
		{
			uint size = 0;

			if (!SteamInventory.Internal.SerializeResult(this._id, IntPtr.Zero, ref size))
				return null;

			var data = new byte[size];

			fixed (byte* ptr = data)
			{
				if (!SteamInventory.Internal.SerializeResult(this._id, (IntPtr)ptr, ref size))
					return null;
			}

			return data;
		}
	}
}