using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Illuminum.Projectiles;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class Radiance : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiance");
			Tooltip.SetDefault("Shining like the sun.");
		}

		public override void SetDefaults()
		{
			item.damage = 76;
			item.melee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Green;
			item.shoot = ModContent.ProjectileType<RadianceProj>();
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shootSpeed = 8f;
			item.scale *= 1.2f;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Daybreak, 120);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.PixieDust, 20);
			recipe.AddIngredient(mod, "Daylight");
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