using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Quartz
{
	[AutoloadEquip(EquipType.Legs)]
	public class QuartzLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Quartz Leggings");
			Tooltip.SetDefault("+2% Movement Speed");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 1000;
			item.rare = ItemRarityID.White;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1.02f;
			//player.statManaMax2 += 20;
			//player.maxMinions+=2;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<QuartzIngot>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}