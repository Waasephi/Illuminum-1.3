using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class Virulence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Virulence");
			Tooltip.SetDefault("Turns musket balls into cursed bullets");
		}

		public override void SetDefaults()
		{
			item.damage = 28;
			item.ranged = true;
			item.width = 46;
			item.height = 26;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 1, 50, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item41;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;    //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 12f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet) // or ProjectileID.WoodenArrowFriendly
			{
				type = ProjectileID.CursedBullet; // or ProjectileID.FireArrow;
			}
			return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.TheUndertaker);
			recipe.AddIngredient(mod,"VialofEvil", 10);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}