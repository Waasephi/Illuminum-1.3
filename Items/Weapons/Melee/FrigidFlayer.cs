using Illuminum.Projectiles;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Melee
{
	public class FrigidFlayer : ModItem
	{
		float shootCD;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frigid Flayer");
			Tooltip.SetDefault("Shoots a frost bolt on original swing");
		}

		public override void SetDefaults()
		{
			shootCD = 0f; //Just reset to zero on dropped/crafted/etc.
			item.damage = 10;
			item.useStyle = 1; //Swing/Throw? Not holding out like arkhalis and terragrim?
			item.useAnimation = 20;
			item.useTime = 10; //Altered some values for useTime and Animation. This is because it will continually shoot arkhalis projectiles or smth if timing is wrong.
			item.shootSpeed = 40f;
			item.channel = true;
			item.knockBack = 6.5f;
			item.width = 40;
			item.height = 40;
			item.scale = 1f;
			item.rare = ItemRarityID.Blue;
			item.value = 11000*5; //1 gold, 10 silver.

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = 595;
		}
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(shootCD == 0)
            {
				shootCD = 1*60f;
                int p = Projectile.NewProjectile(position, new Vector2(speedX, speedY) / 3, ProjectileID.IceBolt, damage * 3, knockBack, player.whoAmI);
                Projectile projectile = Main.projectile[p];
                //Change whatever you'd like to the projectile with projectile.field = someValue;
                
            }
            return true;
        }
        public override void HoldItem(Player player)
        {
            if(shootCD > 0)
                shootCD--; //Reduce shootCD by 1 every tick if it's greater than 0 (to prevent float-wrapping)
        }
	}
}