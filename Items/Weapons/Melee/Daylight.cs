using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Illuminum.Projectiles;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class Daylight : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Daylight");
			Tooltip.SetDefault("A sparkling star.");
		}

		public override void SetDefaults()
		{
			item.damage = 52;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Green;
			item.shoot = ModContent.ProjectileType<RadianceProj>();
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 8f;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Daybreak, 60);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LightShard, 2);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX * 2, speedY * 2, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}