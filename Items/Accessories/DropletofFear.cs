using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class DropletofFear : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Droplet of Fear");
			Tooltip.SetDefault("Power of the Dead." +
                "\n+10% Movement Speed.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.moveSpeed *= 1.1f;
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 20;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.expert = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddTile(TileID.MythrilAnvil); //Tinkerer's Workshop
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}