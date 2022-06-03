using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Dragon
{
	[AutoloadEquip(EquipType.Body)]
	public class DragonscalePlatemail : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Dragonscale Platemail");
			Tooltip.SetDefault("Increased Flight Time" +
                "\n+2 Max Minions" +
                "\n+10% Melee Damage");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 20;
			item.value = 1500;
			item.rare = ItemRarityID.Red;
			item.defense = 18;
		}

		public override void UpdateEquip(Player player)
		{
			player.wingTimeMax += 70;
			player.maxMinions += 2;
			player.meleeDamage *= 1.18f;
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