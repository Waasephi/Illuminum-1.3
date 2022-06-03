using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Melee
{
	public class MahoganyKnives : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mahogany Knives");
			Tooltip.SetDefault("Shoots a spread of leaves");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 35;
			item.useAnimation = 35;
			item.noUseGraphic = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = Item.sellPrice(silver: 60);
			item.rare = ItemRarityID.Blue;
			item.shootSpeed = 6f;
			item.shoot = ProjectileID.Leaf;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2 + Main.rand.Next(2); // 1 or 4 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // 20 degree spread.
																												// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.JungleSpores, 7);
			recipe.AddIngredient(ItemID.RichMahogany, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}