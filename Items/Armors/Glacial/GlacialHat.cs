using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Glacial
{
	[AutoloadEquip(EquipType.Head)]
	public class GlacialHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Glacial Hat");
			Tooltip.SetDefault("+6% Ranged Crit");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			//player.endurance *= 1.05f;
			player.rangedCrit += 6;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<GlacialLongcoat>() && legs.type == ModContent.ItemType<GlacialPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Permanent Archery Buff, +6% Ranged Damage.";
			player.AddBuff(BuffID.Archery, 2);
			player.rangedDamage *= 1.06f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddIngredient(mod,"VialofEvil", 10);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}