using Illuminum.Projectiles.Waved;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Melee.Waved
{
	public class BlazingCutter : ModItem
	{
		//float shootCD;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blazing Flayer");
			Tooltip.SetDefault("Creates a large burning slash that repels and burns enemies.");
		}

		public override void SetDefaults()
		{
			item.damage = 53;
			item.melee = true;
			item.noMelee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 43;
			item.useAnimation = 43;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 9;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.noUseGraphic = true;
			item.value = Item.sellPrice(0, 1, 50, 0);
			item.shoot = mod.ProjectileType("BlazingCutter1");
			item.shootSpeed = 30f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position += new Vector2(speedX, speedY);
			Projectile.NewProjectile(position.X / 1.5f - 32, position.Y / 1.5f + 32, speedX / 30, speedY / 30, type, damage, knockBack, player.whoAmI, speedX, speedY);
			if (item.shoot == mod.ProjectileType("BlazingCutter1"))
			{
				item.shoot = mod.ProjectileType("BlazingCutter2");
			}
			else
			{
				item.shoot = mod.ProjectileType("BlazingCutter1");
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FieryGreatsword);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}