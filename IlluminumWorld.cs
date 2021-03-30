using Illuminum.Tiles;
using Illuminum.Tiles.Voidlands;
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
		public static bool downedFrigidWarlock = false;
		public static bool Illuminated = false;
		public static bool VoidlandsSpawned = false;
		public static int Voidlands = 0;

		public override void Initialize()
		{
			downedFrigidWarlock = false;
			Illuminated = false;
			VoidlandsSpawned = false;
		}

		public override void Load(TagCompound tag)
		{
			IList<string> downed = tag.GetList<string>("downed");
			downedFrigidWarlock = downed.Contains("FrigidWarlock");
		}

		public override TagCompound Save()
		{
			List<string> downed = new List<string>();

			if (downedFrigidWarlock)
				downed.Add("FrigidWarlock");

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