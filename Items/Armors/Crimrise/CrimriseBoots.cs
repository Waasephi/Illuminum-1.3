using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Crimrise
{
	[AutoloadEquip(EquipType.Legs)]
	public class CrimriseBoots : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Crimrise Boots");
			Tooltip.SetDefault("+4% Movement Speed");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 16;
			item.value = Item.sellPrice(silver: 15);
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1.04f;
			//player.statManaMax2 += 20;
			//player.maxMinions+=2;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 15);
			recipe.AddIngredient(3271, 100); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}