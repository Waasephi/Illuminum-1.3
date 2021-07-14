using Illuminum.Projectiles;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Melee
{
	public class CrimriseBroadsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Crimrise Broadsword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Gives Regeneration on hit by blade." +
                "\nGives Bleeding to targets hit by blade.");
		}

		public override void SetDefaults() 
		{
			item.damage = 23;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 15);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = ProjectileType<CrimriseBolt>();
			item.shootSpeed = 6f;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			player.AddBuff(BuffID.Regeneration, 120);
			target.AddBuff(BuffID.Bleeding, 120);
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			speedY -= Math.Abs(speedY) * 0.5f;
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileType<CrimriseBolt>(), damage / 2, knockBack = 0.1f, player.whoAmI, ai1: 1);
			Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY * 0.95f, ProjectileType<CrimriseBolt>(), damage / 2, knockBack = 0.1f, player.whoAmI, ai1: 1);
			Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY * 0.95f, ProjectileType<CrimriseBolt>(), damage / 2, knockBack = 0.1f, player.whoAmI, ai1: 1);
			return false;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.Sandstone, 75); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}