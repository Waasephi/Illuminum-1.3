using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum
{
	public class Illuminum : Mod
	{
		// Ariam was here!
		public override void AddRecipeGroups()
		{
			Core.ModLoadables.RecipeGroups.Load();
		}
	}
}