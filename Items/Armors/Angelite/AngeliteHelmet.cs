using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Angelite
{
	[AutoloadEquip(EquipType.Head)]
	public class AngeliteHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Angelite Helmet");
			Tooltip.SetDefault("+12% Damage" +
                "\n+40 Mana");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 750;
			item.rare = ItemRarityID.Blue;
			item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.allDamage *= 1.12f;
			//player.endurance *= 1.05f;
			player.statManaMax2 += 40;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<AngeliteChestplate>() && legs.type == ModContent.ItemType<AngeliteGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Gives a short amount of increased flight time.";
			player.wingTimeMax += 50;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RefinedAngelite>(), 10);
			recipe.AddTile(mod, "AngeliteAltar");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}