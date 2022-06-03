using Illuminum.Projectiles;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Magic
{
	public class EbonduneStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebondune Staff");
			Tooltip.SetDefault("Spawns a Corrupt Thorn at the Cursor");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.magic = true;
			item.mana = 10;
			item.width = 50;
			item.height = 50;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 0, 60, 0);
			item.shoot = ProjectileID.VilethornTip;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item43;
			item.shootSpeed = 0.1f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position = Main.MouseWorld;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod,"VialofEvil", 8);
			recipe.AddIngredient(ItemID.Sandstone, 75); //Sandstone Block
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}