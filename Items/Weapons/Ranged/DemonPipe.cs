using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class DemonPipe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Demon Pipe"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			 Tooltip.SetDefault("I don't know if you should put this by your mouth...");
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.ranged = true;
			item.width = 32;
			item.height = 12;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 13);
			item.rare = ItemRarityID.Blue;
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
			recipe.AddIngredient(ItemID.DemoniteBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}