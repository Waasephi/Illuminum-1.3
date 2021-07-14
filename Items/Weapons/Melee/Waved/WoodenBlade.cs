using Illuminum.Projectiles.Waved;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Melee.Waved
{
	public class WoodenBlade : ModItem
	{
		float shootCD;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Blade");
			Tooltip.SetDefault("Creates a small wooden slash that repels and cuts enemies.");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.melee = true;
			item.noMelee = true;
			item.width = 38;
			item.height = 40;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 5;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.noUseGraphic = true;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.shoot = mod.ProjectileType("WoodenBlade1");
			item.shootSpeed = 35f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position += new Vector2(speedX, speedY);
			Projectile.NewProjectile(position.X, position.Y + 8, speedX / 30, speedY / 30, type, damage, knockBack, player.whoAmI, speedX, speedY);
			if (item.shoot == mod.ProjectileType("WoodenBlade1"))
			{
				item.shoot = mod.ProjectileType("WoodenBlade2");
			}
			else
			{
				item.shoot = mod.ProjectileType("WoodenBlade1");
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenSword);
			recipe.AddTile(TileID.Sawmill);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}