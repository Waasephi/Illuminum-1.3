using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class SolarEmblem : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Emblem");
			Tooltip.SetDefault("A proof of mastery." +
                "\n+25% Melee Damage.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.meleeDamage *= 1.25f;
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.value = Item.sellPrice(gold: 20);
			item.rare = 7;
			item.accessory = true;
			item.expert = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.AddIngredient(mod, "SolarCore");
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}