using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.DarkSteel
{
	[AutoloadEquip(EquipType.Head)]
	public class DarkSteelVisor : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Dark Steel Visor");
			Tooltip.SetDefault("+9% Ranged Crit Chance");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 8;
			item.value = 1000;
			item.rare = ItemRarityID.Green;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedCrit += 9;
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
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			player.setBonus = "Cannot be set on fire, Immune to Cursed Inferno, All weapons inflict Cursed Inferno";
			modPlayer.darkSteelSet = true;
			player.buffImmune[39] = true;
			player.fireWalk = true;
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}

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