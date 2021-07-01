using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Walls
{
	public class AngeliteBrickWall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angelite Brick Wall");
			Tooltip.SetDefault("Good with paints.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 0;
			item.createWall = ModContent.WallType<AngeliteBrickWallTile>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "AngeliteBrick");
			recipe.AddTile(mod, "AngeliteAltar");
			recipe.SetResult(this, 4);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(mod, "AngeliteBrickWall", 4);
			recipe2.AddTile(mod, "AngeliteAltar");
			recipe2.SetResult(mod, "AngeliteBrick");
			recipe2.AddRecipe();
		}
	}
}