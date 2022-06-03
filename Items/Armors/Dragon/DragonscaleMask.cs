using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Dragon
{
	[AutoloadEquip(EquipType.Head)]
	public class DragonscaleMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Dragonscale Mask");
			Tooltip.SetDefault("+14% Summon Damage" +
                "\n+5% Damage Reduction");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 750;
			item.rare = ItemRarityID.Red;
			item.defense = 14;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage *= 1.14f;
			player.endurance *= 1.05f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DragonscalePlatemail>() && legs.type == ModContent.ItemType<DragonscaleGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			player.setBonus = "Taking damage makes the player explode, Melee attacks inflict Betsy's Curse, +2 minion and sentry slots.";
			modPlayer.dragonSet = true;
			player.maxMinions += 2;
			player.maxTurrets += 2;
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