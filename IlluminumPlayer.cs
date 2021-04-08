using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace Illuminum
{
	public class IlluminumPlayer : ModPlayer
	{
		public bool Drained;
		public bool frigidWarlite;

		public override void ResetEffects()
		{
			Drained = false;
			frigidWarlite = false;
		}
	}
}