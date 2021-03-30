using Illuminum.Tiles.Voidlands;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Consumables
{
	public class AbyssalResonator : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyssal Resonator");
			Tooltip.SetDefault("A strange crystal... You can hardly see it despite it being in your hand..." +
				"\nWARNING: This overtakes a small chunk of the underground." +
				"\nIt is possible you lose blocks you want to keep. You have been warned." +
				"\nRight click on an underground area after use.");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 34;
			item.maxStack = 1;
			item.rare = ItemRarityID.Purple;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item119;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			if (IlluminumWorld.VoidlandsSpawned == false) ;
			return true;
		}

		public override bool UseItem(Player player)
		{
			if (IlluminumWorld.VoidlandsSpawned == false)
			{
				player.GetModPlayer<IlluminumPlayer>().createVoidlands = true;
				Main.mapFullscreen = true; //opens map by force.
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.Ectoplasm, 25);
			recipe.AddTile(mod, "AngeliteAltar");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}