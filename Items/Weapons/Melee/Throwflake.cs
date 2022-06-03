using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class Throwflake : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Throwflake");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 30;
			item.useAnimation = 30;
			item.noUseGraphic = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3;
			item.value = Item.sellPrice(silver: 80);
			item.rare = ItemRarityID.Blue;
			item.shootSpeed = 12f;
			item.shoot = ModContent.ProjectileType<ThrowflakeProjectile>();
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.IceBlock, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}