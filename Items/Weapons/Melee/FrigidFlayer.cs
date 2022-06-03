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
			Tooltip.SetDefault("Creates a frozen slash that repels and freezes enemies.");
		}

		public override void SetDefaults()
		{
			item.damage = 37;
			item.melee = true;
			item.noMelee = true;
			item.width = 48;
			item.height = 52;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 5;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.noUseGraphic = true;
			item.value = Item.sellPrice(0, 1, 50, 0);
			item.shoot = mod.ProjectileType("FrigidFlayer1");
			item.shootSpeed = 30f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position += new Vector2(speedX, speedY);
			Projectile.NewProjectile(position.X, position.Y, speedX / 30, speedY / 30, type, damage, knockBack, player.whoAmI, speedX, speedY);
			if (item.shoot == mod.ProjectileType("FrigidFlayer1"))
			{
				item.shoot = mod.ProjectileType("FrigidFlayer2");
			}
			else
			{
				item.shoot = mod.ProjectileType("FrigidFlayer1");
			}
			return false;
		}
	}
}