using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class DropletofVision : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Droplet of Vision");
			Tooltip.SetDefault("Power of the Sky." +
                "\n+10 Crit.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.meleeCrit += 10;
			player.magicCrit += 10;
			player.rangedCrit += 10;
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 18;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.expert = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddTile(TileID.MythrilAnvil); //Tinkerer's Workshop
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}