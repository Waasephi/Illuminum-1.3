using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Dragon
{
	[AutoloadEquip(EquipType.Head)]
	public class DragonMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Dragon Mask");
			Tooltip.SetDefault("+14% Summoner Damage" +
                "\n+50 Mana" +
                "\n+1 Max Minion");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 750;
			item.rare = ItemRarityID.Red;
			item.defense = 11;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage *= 1.14f;
			//player.endurance *= 1.05f;
			player.statManaMax2 += 50;
			player.maxMinions += 1;
			//player.AddBuff(BuffID.Shine, 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DragonPlate>() && legs.type == ModContent.ItemType<DragonGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+30% Summon Damage.";
			player.minionDamage *= 1.3f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DragonScale>(), 10);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}