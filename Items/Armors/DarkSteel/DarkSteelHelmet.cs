using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.DarkSteel
{
	[AutoloadEquip(EquipType.Head)]
	public class DarkSteelHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Dark Steel Helmet");
			Tooltip.SetDefault("+9% Melee Crit Chance");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.value = 1000;
			item.rare = 2;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 9;
			//player.endurance *= 1.05f;
			//player.statManaMax2 += 20;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DarkSteelChestguard>() && legs.type == ModContent.ItemType<DarkSteelGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Cannot be set on fire, Immune to Cursed Inferno, All melee weapons inflict Cursed Inferno";
			player.AddBuff(73, 2);
			player.buffImmune[39] = true;
			player.fireWalk = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "DarkSteelPlating", 10);
			recipe.AddIngredient(231); //Molten Helmet
			recipe.AddTile(mod, "CursedForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}