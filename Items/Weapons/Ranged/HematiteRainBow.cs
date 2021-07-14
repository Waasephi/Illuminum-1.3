using Terraria;
using Illuminum.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Ranged
{
	public class HematiteRainBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hematite Rain-Bow");
			Tooltip.SetDefault("Wooden Arrows turn into Bones that rain from the sky.");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.ranged = true;
			item.width = 24;
			item.height = 66;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.autoReuse = false;
			item.knockBack = 3;
			item.shoot = ProjectileID.UnholyArrow;
			item.value = Item.sellPrice(0, 0, 72, 0);
			item.useAmmo = AmmoID.Arrow;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{			
			if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
			{
				type = 532; // or ProjectileID.FireArrow;
			}
			//return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal

			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			for (int i = 0; i < 2; i++)
			{
				position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
				position.Y -= (100 * i);
				Vector2 heading = target - position;
				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}
				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}
				heading.Normalize();
				heading *= new Vector2(speedX, speedY).Length();
				speedX = heading.X;
				speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f, ceilingLimit);
			}
			return false;


		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "HematiteChunk", 12);
			recipe.AddTile(mod, "CursedForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}