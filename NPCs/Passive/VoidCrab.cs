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
	public class VoidCrab : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Crab");
			Main.npcFrameCount[npc.type] = 8;
		}

		public override void SetDefaults()
		{
			npc.width = 38;
			npc.height = 28;
			npc.damage = 0;
			npc.lifeMax = 5;
			npc.life = 5;
			npc.defense = 20;
			npc.HitSound = SoundID.NPCHit13;
			npc.DeathSound = SoundID.NPCDeath11;
			npc.aiStyle = 3;
			aiType = NPCID.Crab;
			animationType = NPCID.Crab;
			npc.knockBackResist = 0f;
			banner = npc.type;
			npc.friendly = true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.GetModPlayer<IlluminumPlayer>().ZoneVoidlands ? 1f : 0f;
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ModContent.ItemType<VoidCrabItem>(), Main.rand.Next(1, 5));
		}
	}
}