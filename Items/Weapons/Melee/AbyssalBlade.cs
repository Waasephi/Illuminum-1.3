using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles;

namespace Illuminum.Items.Weapons.Melee
{
	public class AbyssalBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyssal Blade");
			Tooltip.SetDefault("Shoots abyssal tendrils.");
		}

		public override void SetDefaults()
		{
			item.damage = 87;
			item.melee = true;
			item.width = 58;
			item.height = 64;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 6;
			item.value = Item.sellPrice(gold: 5);
			item.shoot = ModContent.ProjectileType<AbyssalTendril>();
			item.shootSpeed = 16f;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.channel = true;
			item.UseSound = SoundID.Item111;
			item.rare = ItemRarityID.Green;
			item.autoReuse = true;
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
	}
}