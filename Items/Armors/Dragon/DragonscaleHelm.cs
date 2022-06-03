using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Dragon
{
	[AutoloadEquip(EquipType.Head)]
	public class DragonscaleHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Dragonscale Helm");
			Tooltip.SetDefault("+14% Melee Damage" +
                "\n+15% Damage Reduction");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.value = 750;
			item.rare = ItemRarityID.Red;
			item.defense = 20;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage *= 1.14f;
			player.endurance *= 1.15f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DragonscalePlatemail>() && legs.type == ModContent.ItemType<DragonscaleGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			player.setBonus = "Taking damage makes the player explode, Melee attacks inflict Betsy's Curse, +20% melee speed.";
			modPlayer.dragonSet = true;
			player.meleeSpeed *= 1.3f;
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