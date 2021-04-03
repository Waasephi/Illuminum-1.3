using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Glacial
{
	[AutoloadEquip(EquipType.Body)]
	public class GlacialLongcoat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Glacial Longcoat");
			Tooltip.SetDefault("+7% Ranged Damage, Immunity to Chilled");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 18;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage *= 1.07f;
			player.buffImmune[BuffID.Chilled] = true;
			//player.maxMinions++;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.IceBlock, 150);
			recipe.AddIngredient(mod, "VialofEvil", 20);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}