using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Dragon
{
	[AutoloadEquip(EquipType.Body)]
	public class DragonPlate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Dragon Plate");
			Tooltip.SetDefault("Increased Flight Time" +
                "\n+2 Max Minions");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 22;
			item.value = 1500;
			item.rare = ItemRarityID.Red;
			item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.wingTimeMax += 70;
			player.maxMinions += 2;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DragonScale>(), 20);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}