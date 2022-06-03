using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Magic
{
	public class BrimstoneTome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brimstone Wave");
		}

		public override void SetDefaults()
		{
			item.damage = 47;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<BrimstoneWave>();
			item.shootSpeed = 12f;
			item.mana = 15;
			item.noMelee = true;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile proj = Projectile.NewProjectileDirect(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI, ai1: 3);
			Projectile proj2 = Projectile.NewProjectileDirect(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI, ai1: 4);
			proj.timeLeft = 60;
			proj2.timeLeft = 60;
			return false;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "BrimstoneCrystal", 12);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}