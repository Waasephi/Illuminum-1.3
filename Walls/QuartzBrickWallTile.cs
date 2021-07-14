using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Walls
{
	public class QuartzBrickWallTile : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			 
			drop = ModContent.ItemType<QuartzBrickWall>();
			AddMapEntry(new Color(69, 69, 71));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}