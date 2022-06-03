using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Overgrowth
{
	[AutoloadEquip(EquipType.Head)]
	public class OvergrowthCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Overgrowth Crown");
			Tooltip.SetDefault("+7% Summoner Damage" +
                "\n+40 Mana" +
                "\n+1 Max Minion");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 10;
			item.value = 750;
			item.rare = ItemRarityID.Blue;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage *= 1.05f;
			//player.endurance *= 1.05f;
			player.statManaMax2 += 20;
			player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.JungleShirt && legs.type == ItemID.JunglePants;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+10% Summon Damage, +1 Minion Slot.";
			player.minionDamage *= 1.1f;
			player.maxMinions += 1;
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.JungleSpores, 10);
			recipe.AddIngredient(ItemID.MudBlock, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}