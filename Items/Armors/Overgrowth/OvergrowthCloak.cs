using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Overgrowth
{
	[AutoloadEquip(EquipType.Body)]
	public class OvergrowthCloak : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Overgrowth Cloak");
			Tooltip.SetDefault("+1 Max Minion");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.value = 1500;
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "VialofEvil", 16);
			recipe.AddIngredient(ItemID.JungleSpores, 25);
			recipe.AddIngredient(ItemID.MudBlock, 125);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}