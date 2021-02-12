using Illuminum.Items.Materials;
using Illuminum.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class VialofEvil : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Vial of Evil"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			item.width = 30;
			item.height = 24;
			item.value = 400;
			item.rare = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddRecipeGroup("Illuminum:EvilBar", 2);
			recipe.AddRecipeGroup("Illuminum:EvilMaterial");
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}