using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Illuminum.Tiles
{
	internal class CursedForge : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
			adjTiles = new int[] { TileID.WorkBenches, TileID.Furnaces, TileID.Anvils, TileID.Hellforge, 114 /*Tinkerer's Workshop */, TileID.CookingPots };
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Cursed Forge");
			AddMapEntry(new Color(150, 0, 170), name);

			//Can't use this since texture is vertical.
			//animationFrameHeight = 56;
		}

		// Our textures animation frames are arranged horizontally, which isn't typical, so here we specify animationFrameWidth which we use later in AnimateIndividualTile
		private readonly int animationFrameWidth = 18;

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 1f;
			g = 0f;
			b = 1.2f;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 48, ModContent.ItemType<CursedForgeItem>());
		}
	}

	internal class CursedForgeItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Forge");
			Tooltip.SetDefault("Combines many stations into one, used for new crafting recipes." +
                "\nWorkbench, Anvil, Hellforge, Tinkerer's Workshop, Cooking Pot all included.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Hellforge);
			item.createTile = ModContent.TileType<CursedForge>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WorkBench);
			recipe.AddIngredient(ItemID.IronAnvil);
			recipe.AddIngredient(ItemID.Hellforge);
			recipe.AddIngredient(ItemID.TinkerersWorkshop);
			recipe.AddIngredient(ItemID.Bone, 50);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.WorkBench);
			recipe2.AddIngredient(ItemID.LeadAnvil);
			recipe2.AddIngredient(ItemID.Hellforge);
			recipe2.AddIngredient(ItemID.TinkerersWorkshop);
			recipe2.AddIngredient(ItemID.Bone, 50);
			recipe2.AddTile(TileID.DemonAltar);
			recipe2.SetResult(this);
			recipe2.AddRecipe();

			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(ItemID.DemoniteBar);
			recipe3.AddTile(mod, "CursedForge");
			recipe3.SetResult(ItemID.CrimtaneBar);
			recipe3.AddRecipe();

			ModRecipe recipe4 = new ModRecipe(mod);
			recipe4.AddIngredient(ItemID.CrimtaneBar);
			recipe4.AddTile(mod, "CursedForge");
			recipe4.SetResult(ItemID.DemoniteBar);
			recipe4.AddRecipe();

			ModRecipe recipe5 = new ModRecipe(mod);
			recipe5.AddIngredient(ItemID.ShadowScale);
			recipe5.AddTile(mod, "CursedForge");
			recipe5.SetResult(ItemID.TissueSample);
			recipe5.AddRecipe();

			ModRecipe recipe6 = new ModRecipe(mod);
			recipe6.AddIngredient(ItemID.TissueSample);
			recipe6.AddTile(mod, "CursedForge");
			recipe6.SetResult(ItemID.ShadowScale);
			recipe6.AddRecipe();
		}
	}
}