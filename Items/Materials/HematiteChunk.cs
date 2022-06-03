using Illuminum.Items.Materials;
using Illuminum.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class HematiteChunk : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Hematite Chunk"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A chunk of fossilized blood, it is very smooth.");
		}

		public override void SetDefaults() 
		{
			item.width = 28;
			item.height = 28;
			item.value = Item.sellPrice(silver: 50);
			item.rare = ItemRarityID.Blue;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 2);
			recipe.AddIngredient(ItemID.TissueSample, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 1);
			recipe.AddIngredient(ItemID.Bone, 2);
			recipe.AddTile(mod, "CursedForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}