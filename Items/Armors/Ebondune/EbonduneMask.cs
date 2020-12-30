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
			Tooltip.SetDefault("+6% Melee Damage");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 1000;
			item.rare = ItemRarityID.Blue;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage *= 1.06f;
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
			player.setBonus = "+7% Increased Melee Damage, Permanent Rage Affect";
			player.meleeDamage *= 1.07f;
			player.AddBuff(BuffID.Rage, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddIngredient(3271, 50); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}