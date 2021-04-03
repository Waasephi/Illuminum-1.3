using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Angelite
{
	[AutoloadEquip(EquipType.Body)]
	public class AngeliteChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Angelite Chestplate");
			Tooltip.SetDefault("+12% all Crit Chance" +
                "\n+2 Max Minions");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 22;
			item.value = 1500;
			item.rare = ItemRarityID.Blue;
			item.defense = 14;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 12;
			player.rangedCrit += 12;
			player.magicCrit += 12;
			//player.statManaMax2 += 20;
			player.maxMinions += 2;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RefinedAngelite>(), 20);
			recipe.AddTile(mod, "AngeliteAltar");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}