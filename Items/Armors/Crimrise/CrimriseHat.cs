using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Armors.Crimrise
{
	[AutoloadEquip(EquipType.Head)]
	public class CrimriseHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Crimrise Hat");
			Tooltip.SetDefault("+50 Mana");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 50;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<CrimriseChestpiece>() && legs.type == ModContent.ItemType<CrimriseBoots>();
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = false;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+8% Increased Magic Damage, 5% Reduced Mana Usage, Increased Life Regeneration by 1.";
			player.magicDamage *= 1.08f;
			player.manaCost *= 0.95f;
			player.lifeRegen += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "VialofEvil", 5);
			recipe.AddIngredient(ItemID.Sandstone, 50); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}