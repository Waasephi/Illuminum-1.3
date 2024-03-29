using Illuminum.Items.Materials;
using Illuminum.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Tiles
{
	public class AngeliteBrick : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Angelite Brick"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			item.width = 16;
			item.height = 16;
			item.value = 0;
			item.rare = ItemRarityID.Blue;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.AngeliteBrickTile>();
			item.placeStyle = 0;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AngeliteChunk>(), 2);
			recipe.AddIngredient(ItemID.StoneBlock, 50);
			recipe.AddTile(mod, "AngeliteAltar");
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}