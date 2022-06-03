using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Quartz
{
	[AutoloadEquip(EquipType.Body)]
	public class QuartzCoat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Quartz Coat");
			Tooltip.SetDefault("+2% Damage Reduction");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 22;
			item.value = 1500;
			item.rare = ItemRarityID.White;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.endurance *= 1.02f;
			//player.statManaMax2 += 20;
			//player.maxMinions++;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<QuartzIngot>(), 10);
			recipe.AddIngredient(ItemID.Leather, 20);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}