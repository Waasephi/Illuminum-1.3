using Illuminum.Items.Materials;
using Illuminum.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class BrimstoneCrystal : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Brimstone Crystal"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A red crystal stuck in solidified ash. It is very warm.");
		}

		public override void SetDefaults() 
		{
			item.width = 34;
			item.height = 32;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Green;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AshBlock, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 1);
			recipe.AddIngredient(ItemID.LivingFireBlock, 5);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}