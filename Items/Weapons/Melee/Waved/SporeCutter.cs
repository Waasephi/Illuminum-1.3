using Illuminum.Projectiles.Waved;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Melee.Waved
{
	public class SporeCutter : ModItem
	{
		float shootCD;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore Cutter");
			Tooltip.SetDefault("Creates a small spore slash that repels and poisons enemies.");
		}

		public override void SetDefaults()
		{
			item.damage = 23;
			item.melee = true;
			item.noMelee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 8;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.noUseGraphic = true;
			item.value = Item.sellPrice(0, 0, 75, 0);
			item.shoot = mod.ProjectileType("SporeCutter1");
			item.shootSpeed = 40f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position += new Vector2(speedX, speedY);
			Projectile.NewProjectile(position.X, position.Y, speedX / 30, speedY / 30, type, damage, knockBack, player.whoAmI, speedX, speedY);
			if (item.shoot == mod.ProjectileType("SporeCutter1"))
			{
				item.shoot = mod.ProjectileType("SporeCutter2");
			}
			else
			{
				item.shoot = mod.ProjectileType("SporeCutter1");
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BladeofGrass);
			recipe.AddTile(TileID.Sawmill);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}