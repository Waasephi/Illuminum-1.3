using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Tiles.Furniture.Angelite
{
	public class AngeliteLantern : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 34;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 100;
			item.createTile = ModContent.TileType<AngeliteLanternTile>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(ModContent.TileType<AngeliteAltar>());
			recipe.AddIngredient(ModContent.ItemType<AngeliteBrick>(), 6);
			recipe.AddIngredient(ItemID.Torch, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}