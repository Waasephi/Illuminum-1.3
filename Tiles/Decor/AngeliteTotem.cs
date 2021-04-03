using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Illuminum.Items.Materials;
using Illuminum.Tiles;

namespace Illuminum.Tiles.Decor
{
	internal class AngeliteTotem : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Angelite Totem");
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
			Item.NewItem(i * 16, j * 16, 32, 48, ModContent.ItemType<AngeliteTotemItem>());
		}
	}

	internal class AngeliteTotemItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angelite Totem");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Hellforge);
			item.createTile = ModContent.TileType<AngeliteTotem>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "RefinedAngelite", 10);
			recipe.AddTile(mod,"AngeliteAltar");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}