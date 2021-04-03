using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Items.Materials;

namespace Illuminum.Items.Accessories
{
	public class BlackenedCrystal : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blackened Crystal");
			Tooltip.SetDefault("It emanates cursed energy." +
                "\nImmunity to blackout... At a cost.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.buffImmune[BuffID.Blackout] = true;
			player.AddBuff(BuffID.Cursed, 2);
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 26;
			item.value = 10000;
			item.rare = 3;
			item.accessory = true;
			item.expert = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Diamond, 7);
			recipe.AddIngredient(mod, "AbyssalFlesh", 10);
			recipe.AddTile(TileID.TinkerersWorkbench); //Tinkerer's Workshop
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}