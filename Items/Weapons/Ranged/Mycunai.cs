/*using Microsoft.Xna.Framework;
using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Ranged
{
	public class Mycunai : ModItem

	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mycunai");
		}

		public override void SetDefaults()
		{
			item.damage = 12;           //this is the item damage
			item.ranged = true;             //this make the item do throwing damage
			item.noMelee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 17;       //this is how fast you use the item
			item.useAnimation = 17;   //this is how fast the animation when the item is used
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 1;
			item.value = 1;
			item.rare = ItemRarityID.Green;
			item.reuseDelay = 6;    //this is the item delay
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;       //this make the item auto reuse
			item.shoot = ModContent.ProjectileType<MycunaiProjectile>();
			item.shootSpeed = 7f;     //projectile speed
			item.useTurn = true;
			item.maxStack = 999;       //this is the max stack of this item
			item.consumable = true;  //this make the item consumable when used
			item.noUseGraphic = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "ParasiticFungi", 3);
			recipe.AddIngredient(mod, "OldIron", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}*/