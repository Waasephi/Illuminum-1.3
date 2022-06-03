using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Illuminum.Items.Materials;

namespace Illuminum.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class AngeliteWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("(200 wing time, 3 accel)");
		}

		public override void SetDefaults()
		{
			item.width = 56;
			item.height = 38;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Blue;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 200;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.5f;
			maxCanAscendMultiplier = 1.5f;
			maxAscentMultiplier = 1.5f;
			constantAscend = 1.5f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 8f;
			acceleration *= 3f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Feather, 15);
			recipe.AddIngredient(mod, "RefinedAngelite", 30);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddTile(mod, "AngeliteAltar");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}