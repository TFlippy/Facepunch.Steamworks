using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Steamworks
{
	public struct InventoryItem: IEquatable<InventoryItem>
	{
		public InventoryItemId _id;
		public InventoryDefId _def;
		public SteamItemFlags _flags;
		public ushort _quantity;
		public Dictionary<string, string> _properties;

		public InventoryItemId Id => this._id;

		public InventoryDefId DefId => this._def;

		public int Quantity => this._quantity;

		public InventoryDef Def => SteamInventory.FindDefinition(this.DefId);


		/// <summary>
		/// Only available if the result set was created with the getproperties
		/// </summary>
		public Dictionary<string, string> Properties => this._properties;

		/// <summary>
		/// This item is account-locked and cannot be traded or given away. 
		/// This is an item status flag which is permanently attached to specific item instances
		/// </summary>
		public bool IsNoTrade => this._flags.HasFlag(SteamItemFlags.NoTrade);

		/// <summary>
		/// The item has been destroyed, traded away, expired, or otherwise invalidated. 
		/// This is an action confirmation flag which is only set one time, as part of a result set.
		/// </summary>
		public bool IsRemoved => this._flags.HasFlag(SteamItemFlags.Removed);

		/// <summary>
		/// The item quantity has been decreased by 1 via ConsumeItem API. 
		/// This is an action confirmation flag which is only set one time, as part of a result set.
		/// </summary>
		public bool IsConsumed => this._flags.HasFlag(SteamItemFlags.Consumed);

		/// <summary>
		/// Consumes items from a user's inventory. If the quantity of the given item goes to zero, it is permanently removed.
		/// Once an item is removed it cannot be recovered.This is not for the faint of heart - if your game implements item removal at all, 
		/// a high-friction UI confirmation process is highly recommended.ConsumeItem can be restricted to certain item definitions or fully
		/// blocked via the Steamworks website to minimize support/abuse issues such as the classic "my brother borrowed my laptop and deleted all of my rare items".
		/// </summary>
		public async Task<InventoryResult?> ConsumeAsync(int amount = 1)
		{
			var sresult = Defines.k_SteamInventoryResultInvalid;
			if (!SteamInventory.Internal.ConsumeItem(ref sresult, this.Id, (uint)amount))
				return null;

			return await InventoryResult.GetAsync(sresult);
		}

		/// <summary>
		/// Split stack into two items
		/// </summary>
		public async Task<InventoryResult?> SplitStackAsync(int quantity = 1)
		{
			var sresult = Defines.k_SteamInventoryResultInvalid;
			if (!SteamInventory.Internal.TransferItemQuantity(ref sresult, this.Id, (uint)quantity, ulong.MaxValue))
				return null;

			return await InventoryResult.GetAsync(sresult);
		}

		/// <summary>
		/// Add x units of the target item to this item
		/// </summary>
		public async Task<InventoryResult?> AddAsync(InventoryItem add, int quantity = 1)
		{
			var sresult = Defines.k_SteamInventoryResultInvalid;
			if (!SteamInventory.Internal.TransferItemQuantity(ref sresult, add.Id, (uint)quantity, this.Id))
				return null;

			return await InventoryResult.GetAsync(sresult);
		}


		public static InventoryItem From(SteamItemDetails_t details)
		{
			var i = new InventoryItem
			{
				_id = details.ItemId,
				_def = details.Definition,
				_flags = (SteamItemFlags)details.Flags,
				_quantity = details.Quantity
			};

			return i;
		}

		public static Dictionary<string, string> GetProperties(SteamInventoryResult_t result, int index)
		{
			var strlen = (uint)Helpers.MemoryBufferSize;

			if (!SteamInventory.Internal.GetResultItemProperty(result, (uint)index, null, out var propNames, ref strlen))
				return null;

			var props = new Dictionary<string, string>();

			foreach (var propertyName in propNames.Split(','))
			{
				strlen = (uint)Helpers.MemoryBufferSize;

				if (SteamInventory.Internal.GetResultItemProperty(result, (uint)index, propertyName, out var strVal, ref strlen))
				{
					props.Add(propertyName, strVal);
				}
			}

			return props;
		}

		/// <summary>
		/// Will try to return the date that this item was aquired. You need to have for the items
		/// with their properties for this to work.
		/// </summary>
		public DateTime Acquired
		{
			get
			{
				if (this.Properties == null) return DateTime.UtcNow;

				if (this.Properties.TryGetValue("acquired", out var str))
				{
					var y = int.Parse(str.Substring(0, 4));
					var m = int.Parse(str.Substring(4, 2));
					var d = int.Parse(str.Substring(6, 2));

					var h = int.Parse(str.Substring(9, 2));
					var mn = int.Parse(str.Substring(11, 2));
					var s = int.Parse(str.Substring(13, 2));

					return new DateTime(y, m, d, h, mn, s, DateTimeKind.Utc);
				}

				return DateTime.UtcNow;
			}
		}

		/// <summary>
		/// Tries to get the origin property. Need properties for this to work.
		/// Will return a string like "market"
		/// </summary>
		public string Origin
		{
			get
			{
				if (this.Properties == null) return null;

				if (this.Properties.TryGetValue("origin", out var str))
					return str;

				return null;
			}
		}

		/// <summary>
		/// Small utility class to describe an item with a quantity
		/// </summary>
		public struct Amount
		{
			public InventoryItem Item;
			public int Quantity;
		}

		public static bool operator ==(InventoryItem a, InventoryItem b) => a._id == b._id;
		public static bool operator !=(InventoryItem a, InventoryItem b) => a._id != b._id;
		public override bool Equals(object p)
		{
			return this.Equals((InventoryItem)p);
		}

		public override int GetHashCode()
		{
			return this._id.GetHashCode();
		}

		public bool Equals(InventoryItem p)
		{
			return p._id == this._id;
		}
	}
}