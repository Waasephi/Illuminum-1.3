using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class HoneyHeart : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Heart");
			Tooltip.SetDefault("Tempting to eat... except it isn't edible" +
                "\nPermanent Honey Buff.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.AddBuff(BuffID.Honey, 2);
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 30;
			item.value = 10000;
			item.rare = 1;
			item.accessory = true;
			item.expert = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeeWax, 7);
			recipe.AddIngredient(ItemID.JungleSpores, 12);
			recipe.AddTile(114); //Tinkerer's Workshop
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}