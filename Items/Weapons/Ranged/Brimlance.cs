using Terraria.ID;
using Terraria;
using Illuminum.Projectiles;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
    public class Brimlance : ModItem

	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brimlance");
		}

		public override void SetDefaults()
		{
			item.damage = 56;           //this is the item damage
			item.ranged = true;             //this make the item do throwing damage
			item.noMelee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 32;       //this is how fast you use the item
			item.useAnimation = 32;   //this is how fast the animation when the item is used
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Green;
			item.reuseDelay = 6;    //this is the item delay
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;       //this make the item auto reuse
			item.shoot = ModContent.ProjectileType<BrimlanceProjectile>();
			item.shootSpeed = 14f;     //projectile speed
			item.useTurn = true;
			item.maxStack = 1;       //this is the max stack of this item
			item.consumable = false;  //this make the item consumable when used
			item.noUseGraphic = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "BrimstoneCrystal", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}