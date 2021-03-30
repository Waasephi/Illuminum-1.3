﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class FrostStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Stone");
			Tooltip.SetDefault("Cold to the touch. " +
                "\nGives Frostburn To Melee And Ranged Weapons");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.frostBurn = true;
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FrostCore, 5);
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}