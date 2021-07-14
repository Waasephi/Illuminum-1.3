using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class BugBite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bug Bite");
			Tooltip.SetDefault("Turns musket balls into stingers.");
		}

		public override void SetDefaults()
		{
			item.damage = 23;
			item.ranged = true;
			item.width = 44;
			item.height = 24;
			item.useTime = 43;
			item.useAnimation = 43;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 2, 50, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item36;
			item.autoReuse = false;
			item.shoot = ProjectileID.PurificationPowder;    //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 12f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{				
			if (type == ProjectileID.Bullet) // or ProjectileID.WoodenArrowFriendly
				{
					type = ProjectileID.HornetStinger; // or ProjectileID.FireArrow;
				}
			int numberProjectiles = 3 + Main.rand.Next(5); // 1 or 2 shots
			for (int i = 2; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); // 20 degree spread.
				Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); // If you want to randomize the speed to stagger the projectiles
																											    // float scale = 1f - (Main.rand.NextFloat() * .3f);
																											    // perturbedSpeed = perturbedSpeed * scale;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed2.Y, type, damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, type, damage, knockBack, player.whoAmI);


				return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.Boomstick);
			recipe.AddIngredient(mod, "VialofEvil", 10);
			recipe.AddTile(TileID.HoneyDispenser);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}