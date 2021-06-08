﻿using System;
using System.Linq;

namespace Steamworks
{
	/// <summary>
	/// A structured description of an item exchange
	/// </summary>
	public struct InventoryRecipe: IEquatable<InventoryRecipe>
	{
		public struct Ingredient
		{
			/// <summary>
			/// The definition ID of the ingredient.
			/// </summary>
			public int DefinitionId;

			/// <summary>
			/// If we don't know about this item definition this might be null.
			/// In which case, DefinitionId should still hold the correct id.
			/// </summary>
			public InventoryDef Definition;

			/// <summary>
			/// The amount of this item needed. Generally this will be 1.
			/// </summary>
			public int Count;

			public static Ingredient FromString(string part)
			{
				var i = new Ingredient();
				i.Count = 1;

				try
				{
					if (part.Contains("x"))
					{
						var idx = part.IndexOf('x');

						var count = 0;
						if (int.TryParse(part.Substring(idx + 1), out count))
							i.Count = count;

						part = part.Substring(0, idx);
					}

					i.DefinitionId = int.Parse(part);
					i.Definition = SteamInventory.FindDefinition(i.DefinitionId);

				}
				catch (System.Exception)
				{
					return i;
				}

				return i;
			}
		}

		/// <summary>
		/// The item that this will create.
		/// </summary>
		public InventoryDef Result;

		/// <summary>
		/// The items, with quantity required to create this item.
		/// </summary>
		public Ingredient[] Ingredients;

		public string Source;

		public static InventoryRecipe FromString(string part, InventoryDef Result)
		{
			var r = new InventoryRecipe
			{
				Result = Result,
				Source = part
			};

			var parts = part.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

			r.Ingredients = parts.Select(x => Ingredient.FromString(x)).Where(x => x.DefinitionId != 0).ToArray();
			return r;
		}

		public bool ContainsIngredient(InventoryDef inventoryDef)
		{
			return this.Ingredients.Any(x => x.DefinitionId == inventoryDef.Id);
		}

		public static bool operator ==(InventoryRecipe a, InventoryRecipe b) => a.GetHashCode() == b.GetHashCode();
		public static bool operator !=(InventoryRecipe a, InventoryRecipe b) => a.GetHashCode() != b.GetHashCode();
		public override bool Equals(object p)
		{
			return this.Equals((InventoryRecipe)p);
		}

		public override int GetHashCode()
		{
			return this.Source.GetHashCode();
		}

		public bool Equals(InventoryRecipe p)
		{
			return p.GetHashCode() == this.GetHashCode();
		}
	}
}