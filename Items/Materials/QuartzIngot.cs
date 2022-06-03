using Illuminum.Items.Materials;
using Illuminum.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class QuartzIngot : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Quartz Ingot"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			item.width = 30;
			item.height = 24;
			item.value = Item.sellPrice(silver: 4);
			item.rare = ItemRarityID.White;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.Ores.QuartzIngotTile>();
			item.placeStyle = 0;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<QuartzChunk>(), 2);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}