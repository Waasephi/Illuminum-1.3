using Illuminum.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Consumables.Potions
{
	public class AbyssalBrew : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Causes the consumer to go berserk." +
				"\nIt smells awful");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 26;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.maxStack = 30;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.value = Item.buyPrice(gold: 1);
			item.potion = true;
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<AbyssalBerserk>(), 5 * 60 * 60, true);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Deathweed, 2);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(mod, "VoidFin");
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}