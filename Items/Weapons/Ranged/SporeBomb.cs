using Microsoft.Xna.Framework;
using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class SporeBomb : ModItem

	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore Bomb");
		}

		public override void SetDefaults()
		{
			item.damage = 35;           //this is the item damage
			item.ranged = true;             //this make the item do throwing damage
			item.noMelee = true;
			item.width = 18;
			item.height = 24;
			item.useTime = 40;       //this is how fast you use the item
			item.useAnimation = 40;   //this is how fast the animation when the item is used
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = Item.sellPrice(silver: 1);
			item.rare = ItemRarityID.Blue;
			item.reuseDelay = 10;    //this is the item delay
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;       //this make the item auto reuse
			item.shoot = ModContent.ProjectileType<SporeBombProjectile>();
			item.shootSpeed = 9f;     //projectile speed
			item.useTurn = true;
			item.maxStack = 999;       //this is the max stack of this item
			item.consumable = true;  //this make the item consumable when used
			item.noUseGraphic = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "VialofEvil");
			recipe.AddIngredient(ItemID.RichMahogany, 15);
			recipe.AddIngredient(ItemID.JungleSpores, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}