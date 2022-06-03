using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Magic
{
	public class CursedBloom : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Bloom");
		}

		public override void SetDefaults()
		{
			item.damage = 52;
			item.magic = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 90);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = ProjectileID.CursedFlameFriendly;
			item.shootSpeed = 8f;
			item.mana = 14;
			item.noMelee = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "DarkSteelPlating", 8);
			recipe.AddIngredient(ItemID.FlowerofFire); //Flower of Fire
			recipe.AddTile(mod, "CursedForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}