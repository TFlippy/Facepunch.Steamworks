using Steamworks.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Steamworks
{
	public class InventoryDef: IEquatable<InventoryDef>
	{
		public InventoryDefId _id;
		public Dictionary<string, string> _properties;

		public InventoryDef(InventoryDefId defId)
		{
			this._id = defId;
		}

		public int Id => this._id.Value;

		/// <summary>
		/// Shortcut to call GetProperty( "name" )
		/// </summary>
		public string Name => this.GetProperty("name");

		/// <summary>
		/// Shortcut to call GetProperty( "description" )
		/// </summary>
		public string Description => this.GetProperty("description");

		/// <summary>
		/// Shortcut to call GetProperty( "icon_url" )
		/// </summary>
		public string IconUrl => this.GetProperty("icon_url");

		/// <summary>
		/// Shortcut to call GetProperty( "icon_url_large" )
		/// </summary>
		public string IconUrlLarge => this.GetProperty("icon_url_large");

		/// <summary>
		/// Shortcut to call GetProperty( "price_category" )
		/// </summary>
		public string PriceCategory => this.GetProperty("price_category");

		/// <summary>
		/// Shortcut to call GetProperty( "type" )
		/// </summary>
		public string Type => this.GetProperty("type");

		/// <summary>
		/// Returns true if this is an item that generates an item, rather 
		/// than something that is actual an item
		/// </summary>
		public bool IsGenerator => this.Type == "generator";

		/// <summary>
		/// Shortcut to call GetProperty( "exchange" )
		/// </summary>
		public string ExchangeSchema => this.GetProperty("exchange");

		/// <summary>
		/// Get a list of exchanges that are available to make this item
		/// </summary>
		public InventoryRecipe[] GetRecipes()
		{
			if (string.IsNullOrEmpty(this.ExchangeSchema)) return null;

			var parts = this.ExchangeSchema.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

			return parts.Select(x => InventoryRecipe.FromString(x, this)).ToArray();
		}

		/// <summary>
		/// Shortcut to call GetBoolProperty( "marketable" )
		/// </summary>
		public bool Marketable => this.GetBoolProperty("marketable");

		/// <summary>
		/// Shortcut to call GetBoolProperty( "tradable" )
		/// </summary>
		public bool Tradable => this.GetBoolProperty("tradable");

		/// <summary>
		/// Gets the property timestamp
		/// </summary>
		public DateTime Created => this.GetProperty<DateTime>("timestamp");

		/// <summary>
		/// Gets the property modified
		/// </summary>
		public DateTime Modified => this.GetProperty<DateTime>("modified");

		/// <summary>
		/// Get a specific property by name
		/// </summary>
		public string GetProperty(string name)
		{
			if (this._properties != null && this._properties.TryGetValue(name, out var val))
				return val;

			var _ = (uint)Helpers.MemoryBufferSize;

			if (!SteamInventory.Internal.GetItemDefinitionProperty(this.Id, name, out var vl, ref _))
				return null;

			if (name == null) //return keys string
				return vl;

			if (this._properties == null)
				this._properties = new Dictionary<string, string>();

			this._properties[name] = vl;

			return vl;
		}

		/// <summary>
		/// Read a raw property from the definition schema
		/// </summary>
		public bool GetBoolProperty(string name)
		{
			var val = this.GetProperty(name);

			if (val.Length == 0) return false;
			if (val[0] == '0' || val[0] == 'F' || val[0] == 'f') return false;

			return true;
		}

		/// <summary>
		/// Read a raw property from the definition schema
		/// </summary>
		public T GetProperty<T>(string name)
		{
			var val = this.GetProperty(name);

			if (string.IsNullOrEmpty(val))
				return default;

			try
			{
				return (T)Convert.ChangeType(val, typeof(T));
			}
			catch (System.Exception)
			{
				return default;
			}
		}

		/// <summary>
		/// Gets a list of all properties on this item
		/// </summary>
		public IEnumerable<KeyValuePair<string, string>> Properties
		{
			get
			{
				var list = this.GetProperty(null);
				var keys = list.Split(',');

				foreach (var key in keys)
				{
					yield return new KeyValuePair<string, string>(key, this.GetProperty(key));
				}
			}
		}

		/// <summary>
		/// Returns the price of this item in the local currency (SteamInventory.Currency)
		/// </summary>
		public int LocalPrice
		{
			get
			{
				ulong curprice = 0;
				ulong baseprice = 0;

				if (!SteamInventory.Internal.GetItemPrice(this.Id, ref curprice, ref baseprice))
					return 0;

				return (int)curprice;
			}
		}

		public string LocalPriceFormatted => Utility.FormatPrice(SteamInventory.Currency, this.LocalPrice / 100.0);

		/// <summary>
		/// If the price has been discounted, LocalPrice will differ from LocalBasePrice
		/// (assumed, this isn't documented)
		/// </summary>
		public int LocalBasePrice
		{
			get
			{
				ulong curprice = 0;
				ulong baseprice = 0;

				if (!SteamInventory.Internal.GetItemPrice(this.Id, ref curprice, ref baseprice))
					return 0;

				return (int)baseprice;
			}
		}

		public string LocalBasePriceFormatted => Utility.FormatPrice(SteamInventory.Currency, this.LocalPrice / 100.0);

		private InventoryRecipe[] _recContaining;

		/// <summary>
		/// Return a list of recepies that contain this item
		/// </summary>
		public InventoryRecipe[] GetRecipesContainingThis()
		{
			if (this._recContaining != null) return this._recContaining;

			var allRec = SteamInventory.Definitions
							.Select(x => x.GetRecipes())
							.Where(x => x != null)
							.SelectMany(x => x);

			this._recContaining = allRec.Where(x => x.ContainsIngredient(this)).ToArray();
			return this._recContaining;
		}

		public static bool operator ==(InventoryDef a, InventoryDef b)
		{
			if (Object.ReferenceEquals(a, null))
				return Object.ReferenceEquals(b, null);

			return a.Equals(b);
		}
		public static bool operator !=(InventoryDef a, InventoryDef b) => !(a == b);
		public override bool Equals(object p)
		{
			return this.Equals((InventoryDef)p);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}

		public bool Equals(InventoryDef p)
		{
			if (p == null) return false;
			return p.Id == this.Id;
		}

	}
}
