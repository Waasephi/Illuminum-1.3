using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories
{
	public class FlowerofSteel : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flower of Steel");
			Tooltip.SetDefault("Grants Immunity to Electrified" +
                "\n+7% Damage Reduction" +
                "\nA Flower of the highest quality.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.endurance *= 1.07f;
			player.buffImmune[BuffID.Electrified] = true;
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.value = Item.sellPrice(gold: 25);
			item.rare = 5;
			item.accessory = true;
			item.expert = false;
			item.defense = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "SteelPetal1");
			recipe.AddIngredient(mod, "SteelPetal2");
			recipe.AddIngredient(mod, "SteelPetal3");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}