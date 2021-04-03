using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Backgrounds
{
	public class VoidlandsBackgroundUG : ModUgBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return Main.LocalPlayer.GetModPlayer<IlluminumPlayer>().ZoneVoidlands;
		}

		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/VoidlandsUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/VoidlandsUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/VoidlandsUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/VoidlandsUG3");
		}
	}
}