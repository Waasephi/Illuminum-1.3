using Illuminum.Projectiles.Waved;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Melee.Waved
{
	public class DemonFlayer : ModItem
	{
		float shootCD;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demon Flayer");
			Tooltip.SetDefault("Creates a demonic slash that repels and poisons enemies.");
		}

		public override void SetDefaults()
		{
			item.damage = 17;
			item.melee = true;
			item.noMelee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 5;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.noUseGraphic = true;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.shoot = mod.ProjectileType("DemonFlayer1");
			item.shootSpeed = 30f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position += new Vector2(speedX, speedY);
			Projectile.NewProjectile(position.X, position.Y, speedX / 30, speedY / 30, type, damage, knockBack, player.whoAmI, speedX, speedY);
			if (item.shoot == mod.ProjectileType("DemonFlayer1"))
			{
				item.shoot = mod.ProjectileType("DemonFlayer2");
			}
			else
			{
				item.shoot = mod.ProjectileType("DemonFlayer1");
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LightsBane);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}