using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum
{
	public class Illuminum : Mod
	{
		public override void AddRecipeGroups()
		{
			RecipeGroup EvilBar = new RecipeGroup(() => Lang.misc[37] + " Evil Bar", new int[]
			{
				ItemID.DemoniteBar,
				ItemID.CrimtaneBar
			});
			RecipeGroup.RegisterGroup("Illuminum:EvilBar", EvilBar);

			RecipeGroup EvilMaterial = new RecipeGroup(() => Lang.misc[37] + " Evil Material", new int[]
			{
				ItemID.ShadowScale,
				ItemID.TissueSample
			});
			RecipeGroup.RegisterGroup("Illuminum:EvilMaterial", EvilMaterial);

		}
	}
}