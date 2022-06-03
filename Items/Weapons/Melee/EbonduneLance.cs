using Illuminum.Projectiles;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Melee
{
	public class EbonduneLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebondune Lance");
			Tooltip.SetDefault("Leaves a Corrupt Thorn");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 32;
			item.useTime = 60;
			item.shootSpeed = 2.5f;
			item.knockBack = 6.5f;
			item.width = 66;
			item.height = 66;
			item.scale = 0.9f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 30);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<EbonduneLanceProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

		// How can I shoot 2 different projectiles at the same time?
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
			Projectile.NewProjectile(position.X, position.Y, speedX * 10, speedY * 10, ProjectileID.VilethornBase, damage, knockBack = 2, player.whoAmI);
			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			return true;
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