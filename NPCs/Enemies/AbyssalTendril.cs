using Illuminum.Items.Banners;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace Illuminum.NPCs.Enemies
{
	public class AbyssalTendril : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyssal Tendril");
			Main.npcFrameCount[npc.type] = 8;
		}

		public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 34;
			npc.damage = 60;
			npc.lifeMax = 800;
			npc.life = 800;
			npc.defense = 5;
			npc.HitSound = SoundID.NPCHit13;
			npc.DeathSound = SoundID.NPCDeath11;
			npc.knockBackResist = 0f;
			npc.value = 1000f;
			banner = npc.type;
			bannerItem = ModContent.ItemType<AbyssalTendrilBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.GetModPlayer<IlluminumPlayer>().ZoneVoidlands ? 1f : 0f;
		}

		public override void NPCLoot()
		{
					Item.NewItem(npc.getRect(), ModContent.ItemType<AbyssalFlesh>(), Main.rand.Next(5, 10));
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