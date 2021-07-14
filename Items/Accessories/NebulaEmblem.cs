﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class NebulaEmblem : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Emblem");
			Tooltip.SetDefault("A proof of mastery." +
                "\n+25% Magic Damage.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.magicDamage *= 1.25f;
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.value = Item.sellPrice(gold: 20);
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
			item.expert = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SorcererEmblem);
			recipe.AddIngredient(mod, "NebulaCore");
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}