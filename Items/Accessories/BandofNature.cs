using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class BandofNature : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Band of Nature");
			Tooltip.SetDefault("Infused with the gifts of the earth." +
                "\n+20 Mana" +
                "\n-5% Mana Cost" +
                "\n+3 Mana Regeneration.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.manaRegen += 3;
			player.statManaMax2 += 20;
			player.manaCost *= 0.95f;
		}

		public override void SetDefaults()
		{
			item.width = 42;
			item.height = 36;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.accessory = true;
			item.expert = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ManaRegenerationBand);
			recipe.AddIngredient(ItemID.NaturesGift);
			recipe.AddTile(TileID.TinkerersWorkbench); //Tinkerer's Workshop
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}