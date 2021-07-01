using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.DarkSteel
{
	[AutoloadEquip(EquipType.Head)]
	public class DarkSteelHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Dark Steel Hat");
			Tooltip.SetDefault("+9% Magic Crit Chance, +40 Mana");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 8;
			item.value = 1000;
			item.rare = ItemRarityID.Green;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicCrit += 9;
			//player.endurance *= 1.05f;
			player.statManaMax2 += 40;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DarkSteelChestguard>() && legs.type == ModContent.ItemType<DarkSteelGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Cannot be set on fire, Immune to Cursed Inferno.";
			player.buffImmune[39] = true;
			player.fireWalk = true;
		}

	/*	public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}*/

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "DarkSteelPlating", 10);
			recipe.AddIngredient(ItemID.MoltenHelmet); //Molten Helmet
			recipe.AddTile(mod, "CursedForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}