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
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
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


		public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
		{
			// Tweak the frame drawn by x position so tiles next to each other are off-sync and look much more interesting.
			int uniqueAnimationFrame = Main.tileFrame[Type] + i;
			if (i % 1 == 0)
			{
				uniqueAnimationFrame += 3;
			}
			if (i % 2 == 0)
			{
				uniqueAnimationFrame += 3;
			}
			if (i % 3 == 0)
			{
				uniqueAnimationFrame += 3;
			}
			uniqueAnimationFrame = uniqueAnimationFrame % 4;
		}

		// Below is an example completely manually drawing a tile. It shows some interesting concepts that may be useful for more advanced things.
		/*public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
			// Flips the sprite
			SpriteEffects effects = SpriteEffects.None;
			if (i % 2 == 1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			// Tweak the frame drawn by x position so tiles next to each other are off-sync and look much more interesting.
			int k = Main.tileFrame[Type] + i % 6;
			if (i % 2 == 0)
			{
				k += 3;
			}
			if (i % 3 == 0)
			{
				k += 3;
			}
			if (i % 4 == 0)
			{
				k += 3;
			}
			k = k % 6;
			Tile tile = Main.tile[i, j];
			Texture2D texture;
			if (Main.canDrawColorTile(i, j))
			{
				texture = Main.tileAltTexture[Type, (int)tile.color()];
			}
			else
			{
				texture = Main.tileTexture[Type];
			}
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
			int animate = k * animationFrameWidth;
			Main.spriteBatch.Draw(
				texture,
				new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
				new Rectangle(tile.frameX + animate, tile.frameY, 16, 16),
				Lighting.GetColor(i, j), 0f, default(Vector2), 1f, effects, 0f);
			return false; // return false to stop vanilla draw.
		}*/

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			
			// Spend 9 ticks on each of 6 frames, looping
			// Or, more compactly:
			if (++frameCounter >= 9)
			{
				frameCounter = 0;
				frame = ++frame % 4;
			}
			
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, ModContent.ItemType<CursedForgeItem>());
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
			recipe.AddIngredient(36); //Wooden Workbench
			recipe.AddIngredient(ItemID.IronAnvil);
			recipe.AddIngredient(ItemID.Hellforge);
			recipe.AddIngredient(398); //Tinkerer's Workshop
			recipe.AddIngredient(ItemID.Bone, 50);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(36); //Wooden Workbench
			recipe2.AddIngredient(ItemID.LeadAnvil);
			recipe2.AddIngredient(ItemID.Hellforge);
			recipe2.AddIngredient(398); //Tinkerer's Workshop
			recipe2.AddIngredient(ItemID.Bone, 50);
			recipe2.AddTile(TileID.DemonAltar);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}