using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class PalmWoodReed : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Palm Wood Reed"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			 Tooltip.SetDefault("Don't get a splinter.");
		}

		public override void SetDefaults() 
		{
			item.damage = 6;
			item.ranged = true;
			item.width = 28;
			item.height = 10;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 2);
			item.rare = ItemRarityID.White;
			item.shoot = ProjectileID.UnholyArrow;
			item.noMelee = true;
			item.shootSpeed = 3f;
			item.UseSound = SoundID.Item63;
			item.autoReuse = false;
			item.useAmmo = AmmoID.Dart;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalmWood, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}