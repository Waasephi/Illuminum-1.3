using Illuminum.Items.Banners;
using Illuminum.Items.Materials;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.NPCs.Enemies
{
	public class VoidWraith : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Wraith");
			Main.npcFrameCount[npc.type] = 4;
		}
		private Player player;
		private float speed;
		public override void SetDefaults()
		{
			npc.width = 16;
			npc.height = 40;
			npc.damage = 35;
			npc.lifeMax = 400;
			npc.life = 400;
			npc.defense = 5;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 100f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 5;
			aiType = NPCID.DungeonSpirit;
			banner = npc.type;
			bannerItem = ModContent.ItemType<VoidWraithBanner>();
			npc.lavaImmune = true; // why? it's a prehardmode boss...
			npc.noGravity = true;
			npc.noTileCollide = true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.GetModPlayer<IlluminumPlayer>().ZoneVoidlands ? 0.7f : 0f;
		}

		public override void NPCLoot()
		{
					Item.NewItem(npc.getRect(), ModContent.ItemType<AbyssalFlesh>(), Main.rand.Next(1, 5));
		}
		private void Target()
		{
			player = Main.player[npc.target];
		}
		public override void AI()
		{
			Target();
			Move(Vector2.Zero);

			float wantedSpeed = 9f;
		}
		private float Magnitude(Vector2 mag)
		{
			return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);

		}
		private void Move(Vector2 offset)
		{
			speed = 6f;
			Vector2 goalPosition = player.Center;
			Vector2 move = goalPosition - npc.Center;
			float magnitude = Magnitude(move);
			if (magnitude > speed)
			{
				move *= speed / magnitude;
			}
			magnitude = Magnitude(move);
			if (magnitude > speed)
			{
				move *= speed / magnitude;
			}
			npc.velocity = move;
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