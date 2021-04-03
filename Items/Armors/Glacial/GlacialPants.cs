using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Glacial
{
	[AutoloadEquip(EquipType.Legs)]
	public class GlacialPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Glacial Pants");
			Tooltip.SetDefault("\n+10 %Movement Speed");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1.10f;
			//player.maxMinions+=2;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.IceBlock, 100);
			recipe.AddIngredient(mod,"VialofEvil", 15);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}