using Illuminum.Items.Materials;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Illuminum.Projectiles;

namespace Illuminum.Items.Weapons.Ranged
{
	public class CursedFury : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Cursed Fury"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Wooden Arrows turn into Cursed Flame Arrows.");
		}

		public override void SetDefaults() 
		{
			item.damage = 35;
			item.ranged = true;
			item.width = 24;
			item.height = 52;
			item.useTime = 25;
			item.useAnimation = 25;
			item.knockBack = 2;
			item.value = 2000;
			item.rare = ItemRarityID.Green;
			item.shoot = ProjectileID.UnholyArrow;
			item.noMelee = true;
			item.shootSpeed = 9f;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
			{
				type = ProjectileID.CursedArrow; // or ProjectileID.FireArrow;
			}
		return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "DarkSteelPlating", 8);
			recipe.AddIngredient(ItemID.MoltenFury);
			recipe.AddTile(mod, "CursedForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}