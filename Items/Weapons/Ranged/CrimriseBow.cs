using Illuminum.Items.Materials;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Illuminum.Projectiles;

namespace Illuminum.Items.Weapons.Ranged
{
	public class CrimriseBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Crimrise Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Wooden Arrows turn into slightly glowing Crimrise Arrows.");
		}

		public override void SetDefaults() 
		{
			item.damage = 19;
			item.ranged = true;
			item.width = 34;
			item.height = 46;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 2000;
			item.rare = 1;
			item.shoot = 4;
			item.noMelee = true;
			item.shootSpeed = 7f;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
		if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
		{
			type = mod.ProjectileType("CrimriseArrowProjectile"); // or ProjectileID.FireArrow;
		}
		return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "VialofEvil", 8);
			recipe.AddIngredient(3271, 50); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}