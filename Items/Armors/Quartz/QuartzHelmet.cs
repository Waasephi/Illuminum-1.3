using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Quartz
{
	[AutoloadEquip(EquipType.Head)]
	public class QuartzHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Quartz Helmet");
			Tooltip.SetDefault("+3% Ranged Damage");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 750;
			item.rare = ItemRarityID.White;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage *= 1.03f;
			//player.endurance *= 1.05f;
			//player.statManaMax2 += 20;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<QuartzChestplate>() && legs.type == ModContent.ItemType<QuartzLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+4% Increased Ranged Damage";
			player.rangedDamage *= 1.04f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<QuartzIngot>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}