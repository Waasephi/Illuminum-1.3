using Illuminum.Items.Materials;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Illuminum.Projectiles;

namespace Illuminum.Items.Weapons.Ranged
{
	public class AngeliteLongbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Angelite Longbow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Wooden Arrows turn into Crystal Bolts.");
		}

		public override void SetDefaults() 
		{
			item.damage = 40;
			item.ranged = true;
			item.width = 38;
			item.height = 68;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2;
			item.value = 2000;
			item.rare = ItemRarityID.Blue;
			item.shoot = ProjectileID.UnholyArrow;
			item.noMelee = true;
			item.shootSpeed = 8f;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
			{
				type = 521; // or ProjectileID.FireArrow;
			}
		return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "RefinedAngelite", 15);
			recipe.AddTile(mod, "AngeliteAltar");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}