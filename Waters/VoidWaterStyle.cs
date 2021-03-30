using Illuminum.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Waters
{
	public class VoidWaterStyle : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
			=> Main.bgStyle == mod.GetSurfaceBgStyleSlot("VoidlandsBackgroundUGStyle");

		public override int ChooseWaterfallStyle()
			=> mod.GetWaterfallStyleSlot("VoidWaterfallStyle");

		public override int GetSplashDust()
			=> ModContent.DustType<VoidWaterSplash>();

		public override int GetDropletGore()
			=> mod.GetGoreSlot("Gores/VoidDroplet");

		public override void LightColorMultiplier(ref float r, ref float g, ref float b)
		{
			r = 0.1f;
			g = 0.1f;
			b = 0.1f;
		}

		public override Color BiomeHairColor()
			=> Color.Black;
	}
}