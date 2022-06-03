using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Magic
{
	public class GlacialTrident : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacial Trident");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 22;
			item.magic = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 60);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shoot = ProjectileID.SkyFracture;
			item.shootSpeed = 12f;
			item.mana = 8;
			item.noMelee = true;
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