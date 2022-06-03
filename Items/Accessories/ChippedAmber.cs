using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class ChippedAmber : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chipped Amber");
			Tooltip.SetDefault("It is smooth to the touch... Except for the chipped part..." +
                "\n+5% Summon Damage.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.minionDamage *= 1.05f;
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;
			item.value = Item.sellPrice(silver: 20);
			item.rare = ItemRarityID.Blue;
			item.accessory = true;
			item.expert = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amber, 7);
			recipe.AddTile(TileID.Sawmill); //Tinkerer's Workshop
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}