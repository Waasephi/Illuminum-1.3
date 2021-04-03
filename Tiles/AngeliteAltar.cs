using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Illuminum.Items.Materials;
using Illuminum.Tiles;

namespace Illuminum.Tiles
{
	internal class AngeliteAltar : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
			adjTiles = new int[] { TileID.WorkBenches, TileID.Furnaces, TileID.Anvils, TileID.Hellforge, 114 /*Tinkerer's Workshop */, TileID.CookingPots, 134 /*Hardmode Anvils*/, 133 /*Hardmode Forge*/, 26 /*Altars*/ };
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Angelite Altar");
			AddMapEntry(new Color(238, 90, 167), name);

			//Can't use this since texture is vertical.
			//animationFrameHeight = 56;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 2f;
			g = 1.5f;
			b = 1.5f;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 48, ModContent.ItemType<AngeliteAltarItem>());
		}
	}

	internal class AngeliteAltarItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angelite Altar");
			Tooltip.SetDefault("Combines many stations into one, used for new crafting recipes." +
                "\nCursed Forge, Hardmode Anvils, Hardmode Forges, and Altars Included.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Hellforge);
			item.createTile = ModContent.TileType<AngeliteAltar>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "CursedForgeItem");
			recipe.AddIngredient(ItemID.MythrilAnvil);
			recipe.AddIngredient(ItemID.AdamantiteForge);
			recipe.AddIngredient(mod, "AngeliteChunk", 30);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(mod, "CursedForgeItem");
			recipe2.AddIngredient(ItemID.MythrilAnvil);
			recipe2.AddIngredient(ItemID.TitaniumForge);
			recipe2.AddIngredient(mod,"AngeliteChunk", 30);
			recipe2.AddTile(TileID.DemonAltar);
			recipe2.SetResult(this);
			recipe2.AddRecipe();

			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(mod, "CursedForgeItem");
			recipe3.AddIngredient(ItemID.OrichalcumAnvil);
			recipe3.AddIngredient(ItemID.AdamantiteForge);
			recipe3.AddIngredient(mod, "AngeliteChunk", 30);
			recipe3.AddTile(TileID.DemonAltar);
			recipe3.SetResult(this);
			recipe3.AddRecipe();

			ModRecipe recipe4 = new ModRecipe(mod);
			recipe4.AddIngredient(mod, "CursedForgeItem");
			recipe4.AddIngredient(ItemID.OrichalcumAnvil);
			recipe4.AddIngredient(ItemID.TitaniumForge);
			recipe4.AddIngredient(mod, "AngeliteChunk", 30);
			recipe4.AddTile(TileID.DemonAltar);
			recipe4.SetResult(this);
			recipe4.AddRecipe();
		}
	}
}