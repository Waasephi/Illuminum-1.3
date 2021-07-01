using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class VoidHeart : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Heart");
			Tooltip.SetDefault("It is increadibly painful to hold." +
                "\nEmpowers your body, at a cost.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.statLifeMax2 -= 150;
			if(player.statLifeMax2 <= 150)
            {
				player.statLifeMax2 = 1;
				player.buffImmune[BuffID.Lifeforce] = true;
			}
			player.allDamage *= 1.5f;
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 32;
			item.value = 10000;
			item.rare = ItemRarityID.Cyan;
			item.accessory = true;
			item.expert = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "HoneyHeart");
			recipe.AddIngredient(mod, "HeartofGaia");
			recipe.AddIngredient(mod, "AbyssalFlesh", 100);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}