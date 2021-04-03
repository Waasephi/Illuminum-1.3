using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Waters
{
	public class VoidWaterfallStyle : ModWaterfallStyle
	{
		// Makes the waterfall provide light
		// Learn how to make a waterfall: https://terraria.gamepedia.com/Waterfall
		public override void AddLight(int i, int j) =>
			Lighting.AddLight(new Vector2(i, j).ToWorldCoordinates(), Color.Black.ToVector3() * 0.5f);
	}
}