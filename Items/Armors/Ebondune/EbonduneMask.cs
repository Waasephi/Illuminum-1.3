using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Ebondune
{
	[AutoloadEquip(EquipType.Head)]
	public class EbonduneMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Ebondune Mask");
			Tooltip.SetDefault("+7% Melee Damage");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 18;
			item.value = 1000;
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage *= 1.07f;
			//player.endurance *= 1.05f;
			//player.statManaMax2 += 20;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<EbonduneBody>() && legs.type == ModContent.ItemType<EbonduneBoots>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+8% Melee Crit";
			player.meleeCrit += 8;
		}

		public override bool DrawHead()
		{
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "VialofEvil", 5);
			recipe.AddIngredient(ItemID.Sandstone, 50); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}