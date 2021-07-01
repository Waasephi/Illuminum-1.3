using Illuminum.Items.Banners;
using Illuminum.Items.Materials;
using Illuminum.Items.Consumables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace Illuminum.NPCs.Passive
{
	public class Mosscreep : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mosscreep");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.width = 32;
			npc.height = 30;
			npc.damage = 0;
			npc.lifeMax = 5;
			npc.life = 5;
			npc.defense = 0;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.aiStyle = 7;
			aiType = NPCID.Bunny;
			animationType = NPCID.Frog;
			npc.knockBackResist = 0f;
			banner = npc.type;
			npc.friendly = true;
			bannerItem = ModContent.ItemType<MosscreepBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.ZoneJungle ? 2f : 0f;
		}

		int frame = 0;
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter++;
			if (npc.frameCounter > 7)
			{  //7 frames between each "frame" of animation
				npc.frameCounter = 0;
				frame++;
				if (frame >= Main.npcFrameCount[npc.type])
				{
					frame = 0;
				}
			}
			npc.frame.Y = frame * frameHeight;
		}
	}
}