using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Hematite
{
	[AutoloadEquip(EquipType.Head)]
	public class HematiteRose : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Hematite Rose");
			Tooltip.SetDefault("+12% Magic Crit Chance, +30 Mana");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 26;
			item.value = 1000;
			item.rare = 2;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicCrit += 12;
			//player.endurance *= 1.05f;
			player.statManaMax2 += 30;
			//player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<HematiteChestplate>() && legs.type == ModContent.ItemType<HematiteLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Cannot be set on fire, Immune to Ichor, +3 Life Regeneration.";
			player.lifeRegen += 3;
			player.buffImmune[69] = true; //Nice
			player.fireWalk = true;
		}

			public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
			{
				drawHair = true;
			}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "HematiteChunk", 10);
			recipe.AddIngredient(151); //Necro Helmet
			recipe.AddTile(mod, "CursedForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}