using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class BloodyDartPistol : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Bloody Dart Pistol"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			 Tooltip.SetDefault("Lumpy and smooth.");
		}

		public override void SetDefaults() 
		{
			item.damage = 17;
			item.ranged = true;
			item.width = 32;
			item.height = 22;
			item.useTime = 36;
			item.useAnimation = 36;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 17);
			item.rare = ItemRarityID.Blue;
			item.shoot = ProjectileID.UnholyArrow;
			item.noMelee = true;
			item.shootSpeed = 3f;
			item.UseSound = SoundID.Item98;
			item.autoReuse = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAmmo = AmmoID.Dart;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}