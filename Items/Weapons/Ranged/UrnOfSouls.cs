using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles;

namespace Illuminum.Items.Weapons.Ranged
{

	public class UrnOfSouls : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Urn of Souls");
		}

		// Our ExampleDamageItem abstract class handles all code related to our custom damage class
		public override void SetDefaults()
		{
			item.shootSpeed = 10f;
			item.shoot = ModContent.ProjectileType<UrnOfSoulsHoldout>();
			item.width = 32;
			item.height = 40;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.ranged = true;
			item.damage = 90;
			item.crit = 4;
			item.knockBack = 5;
			item.channel = true;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(gold: 8);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddIngredient(mod, "AbyssalFlesh", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<UrnOfSoulsHoldout>()] <= 0;
	}
}