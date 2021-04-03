/*using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class OldIron : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Old Iron"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			 Tooltip.SetDefault("A used chunk of Iron. Can't be used for much in this state.");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 28;
			item.value = 100;
			item.rare = 1;
			item.maxStack = 999;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "OldIron", 5);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(ItemID.IronBar);
			recipe.AddRecipe();
		}
	}
}*/