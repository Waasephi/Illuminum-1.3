using Illuminum.Tiles;
using Illuminum.Tiles.Voidlands;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace Illuminum
{
	public class IlluminumWorld : ModWorld
	{
		public static bool downedFrigidConstruct = false;
		public static bool Illuminated = false;
		public static bool VoidlandsSpawned = false;
		public static int Voidlands = 0;

        public override void PreUpdate()
        {
			//Update all DrawEntities
			
			foreach (DrawEffect drawEffect in Illuminum.drawEffects)
			{
				drawEffect.Update();
			}
        }

        public override void PostDrawTiles()
		{
			//Draw all DrawEntities

			SpriteBatch spriteBatch = Main.spriteBatch;

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);

			foreach (DrawEffect drawEffect in Illuminum.drawEffects)
			{
				drawEffect.PreDrawAll(spriteBatch);
			}

			foreach (DrawEffect drawEffect in Illuminum.drawEffects)
			{
				if (drawEffect.PreDraw(spriteBatch))
				{
					drawEffect.Draw(spriteBatch);
					drawEffect.PostDraw(spriteBatch);
				}
			}

			spriteBatch.End();
		}

        public override void Initialize()
		{
			downedFrigidConstruct = false;
			Illuminated = false;
			VoidlandsSpawned = false;
		}

		public override void Load(TagCompound tag)
		{
			IList<string> downed = tag.GetList<string>("downed");
			downedFrigidConstruct = downed.Contains("FrigidConstruct");
		}

		public override TagCompound Save()
		{
			List<string> downed = new List<string>();

			if (downedFrigidConstruct)
				downed.Add("FrigidConstruct");

			return new TagCompound {
				{"downed", downed},
			};
		}

		public override void ResetNearbyTileEffects()
		{
			Voidlands = 0;
		}

		public override void TileCountsAvailable(int[] tileCounts)
		{
			Voidlands = tileCounts[ModContent.TileType<VoidStoneTile>()]; //this make the public static int customBiome counts as customtileblock
		}
	}
}