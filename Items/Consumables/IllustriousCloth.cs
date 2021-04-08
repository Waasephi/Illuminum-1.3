using Illuminum.NPCs.Bosses.FrigidWarlock;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Consumables
{
	public class IllustriousCloth : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Illustrious Cloth");
			Tooltip.SetDefault("A mysterious piece of cloth... it is very cold...");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 26;
			item.maxStack = 999;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item15;
			item.consumable = true;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "RelicShard", 5);
			recipe.AddIngredient(mod, "AncientStone", 100);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/

		public override bool CanUseItem(Player player)
		{
			return true; // player.ZoneSnow;
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<FrigidWarlock>());
			return true;
		}
	}
}