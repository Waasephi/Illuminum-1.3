using Illuminum.Items.Pets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class DragonScale : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Dragon Scale"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("It is warm to the touch.");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 24;
			item.value = Item.sellPrice(silver: 27);
			item.rare = ItemRarityID.LightRed;
			item.maxStack = 999;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(mod, "DragonScale", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.DD2SquireBetsySword); //Flying Dragon
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe2.AddIngredient(mod, "DragonScale", 10);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.SetResult(ItemID.ApprenticeStaffT3); //Betsy's Wrath
			recipe2.AddRecipe();

			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe3.AddIngredient(mod, "DragonScale", 10);
			recipe3.AddTile(TileID.MythrilAnvil);
			recipe3.SetResult(ItemID.DD2BetsyBow); //Aerial Bane
			recipe3.AddRecipe();

			ModRecipe recipe4 = new ModRecipe(mod);
			recipe4.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe4.AddIngredient(mod, "DragonScale", 10);
			recipe4.AddTile(TileID.MythrilAnvil);
			recipe4.SetResult(ItemID.MonkStaffT3); //Sky Dragon's Fury
			recipe4.AddRecipe();

			ModRecipe recipe5 = new ModRecipe(mod);
			recipe5.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe5.AddIngredient(mod, "DragonScale", 20);
			recipe5.AddIngredient(ItemID.SoulofFlight, 20);
			recipe5.AddTile(TileID.MythrilAnvil);
			recipe5.SetResult(ItemID.BetsyWings); //Betsy's Wings
			recipe5.AddRecipe();
		}
	}
}