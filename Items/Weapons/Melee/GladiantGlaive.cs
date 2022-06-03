using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Melee
{
	public class GladiantGlaive : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Gladiant Glaive"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Shoots a lingering spectral glaive.");
		}

		public override void SetDefaults() 
		{
			item.damage = 18;
			item.melee = true;
			item.width = 48;
			item.height = 54;
			item.useAnimation = 35;
			item.useTime = 70;
			item.shootSpeed = 2f;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 5;
			item.value = Item.sellPrice(silver: 50);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shoot = ProjectileType<GladiantGlaiveProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
			Projectile.NewProjectile(position.X, position.Y, speedX * 2.5f, speedY * 2.5f, ProjectileType<PhantomGGlaive>(), (int)(damage * 0.8f), knockBack = 0.1f, player.whoAmI);
			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			return true;
		}
	}
}