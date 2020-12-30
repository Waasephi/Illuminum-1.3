using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Crimrise
{
	[AutoloadEquip(EquipType.Body)]
	public class CrimriseChestpiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Crimrise Chestpiece");
			Tooltip.SetDefault("+2% Damage, Immunity to Bleeding");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 24;
			item.value = Item.sellPrice(silver: 20);
			item.rare = ItemRarityID.Blue;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.allDamage *= 1.02f;
			player.buffImmune[BuffID.Bleeding] = true;
			//player.statManaMax2 += 20;
			//player.maxMinions++;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 20);
			recipe.AddIngredient(3271, 150); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}