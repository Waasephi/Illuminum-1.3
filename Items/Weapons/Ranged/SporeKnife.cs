using Microsoft.Xna.Framework;
using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Projectiles;

namespace Illuminum.Items.Weapons.Ranged
{
	public class SporeKnife : ModItem

	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore Knife");
		}

		public override void SetDefaults()
		{
			item.damage = 23;           //this is the item damage
			item.ranged = true;             //this make the item do throwing damage
			item.noMelee = true;
			item.width = 28;
			item.height = 28;
			item.useTime = 14;       //this is how fast you use the item
			item.useAnimation = 14;   //this is how fast the animation when the item is used
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
			item.reuseDelay = 6;    //this is the item delay
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;       //this make the item auto reuse
			item.shoot = ModContent.ProjectileType<SporeKnifeProjectile>();
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
			recipe.AddIngredient(ItemID.MudBlock, 15);
			recipe.AddIngredient(ItemID.JungleSpores, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}