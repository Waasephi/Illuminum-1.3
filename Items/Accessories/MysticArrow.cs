using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class MysticArrow : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystic Arrow");
			Tooltip.SetDefault("Its cursed." +
                "\n+5% Magic Damage" +
                "\n-20% Chance to consume ammo" +
                "\n-3% Ranged Damage.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.magicDamage *= 1.05f;
			player.rangedDamage *= 0.95f;
			player.ammoCost80 = true;
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 34;
			item.value = Item.sellPrice(silver: 50);
			item.rare = ItemRarityID.Blue;
			item.accessory = true;
			item.expert = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddIngredient(ItemID.SilverBar, 10);
			recipe.AddTile(TileID.TinkerersWorkbench); //Tinkerer's Workshop
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}