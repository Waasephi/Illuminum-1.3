using Illuminum.Items.Materials;
using Illuminum.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class RefinedAngelite : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Refined Angelite"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			item.width = 26;
			item.height = 24;
			item.value = 400;
			item.rare = 3;
			item.maxStack = 999;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AngeliteChunk>(), 4);
			recipe.AddTile(mod, "AngeliteAltar");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}