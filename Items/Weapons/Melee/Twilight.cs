using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Illuminum.Projectiles;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class Twilight : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight");
			Tooltip.SetDefault("A remnant of the past.");
		}

		public override void SetDefaults()
		{
			item.damage = 38;
			item.melee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.shoot = ModContent.ProjectileType<TwilightProj>();
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DarkShard, 2);
			recipe.AddIngredient(ItemID.LightShard, 2);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y - 10, speedX * 2, speedY * 2, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y + 10, speedX * 2, speedY * 2, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}