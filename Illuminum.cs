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
	public class Illuminum : Mod
	{

		public static List<DrawEffect> drawEffects = new List<DrawEffect>();

		public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
				return;

			// Make sure your logic here goes from lowest priority to highest so your intended priority is maintained.
			if (Main.LocalPlayer.GetModPlayer<IlluminumPlayer>().ZoneVoidlands)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/Vacancy");
				priority = MusicPriority.BiomeHigh;
			}
		}

		// Ariam was here!
		public override void AddRecipeGroups()
		{
			Core.ModLoadables.RecipeGroups.Load();
		}
		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");

			if (bossChecklist != null)
			{
				bossChecklist.Call("AddBossWithInfo", "Frigid Construct", 3.001f, (Func<bool>)(() => IlluminumWorld.downedFrigidConstruct), string.Format("Use [i:{0}] in the tundra", ItemType("IllustriousCloth")));
			}
		}
		public override void Load()
		{
			if (!Main.dedServ) // do not run this code on the server
			{
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/FrigidFury"), ItemType("FrigidConstructMusicBox"), TileType("FrigidConstructMusicBoxTile"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Vacancy"), ItemType("VoidLandsMusicBox"), TileType("VoidLandsMusicBoxTile"));
			}
		}
	}
}