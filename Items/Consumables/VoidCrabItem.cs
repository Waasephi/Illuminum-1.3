using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Illuminum.Items.Consumables
{
	public class VoidCrabItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Crab");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}" +
                "\nVoid Crab");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 8));
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 42;
			item.height = 30;
			item.rare = -1;
			item.expert = false;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.QuickSpawnItem(ModContent.ItemType<VoidCrabItem>());
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "VoidCrabItem");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}