using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Quartz
{
	[AutoloadEquip(EquipType.Head)]
	public class QuartzHood : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Quartz Hood");
			Tooltip.SetDefault("+6% Ranged Damage");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 750;
			item.rare = ItemRarityID.White;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage *= 1.06f;
			//player.endurance *= 1.05f;
			//player.statManaMax2 += 20;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool DrawHead()
		{
			return false;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<QuartzCoat>() && legs.type == ModContent.ItemType<QuartzPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Reduced enemy aggression";
			player.calmed = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<QuartzIngot>(), 5);
			recipe.AddIngredient(ItemID.Leather, 10);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}