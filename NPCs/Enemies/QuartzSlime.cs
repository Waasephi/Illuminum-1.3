using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.NPCs.Enemies
{
	public class QuartzSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.width = 30;
			npc.height = 18;
			npc.damage = 5;
			npc.lifeMax = 40;
			npc.life = 40;
			npc.defense = 1;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 100f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 1;
			aiType = NPCID.BlueSlime;
			animationType = NPCID.BlueSlime;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.ZoneRockLayerHeight ? 0.1f : 0f;
		}

		public override void NPCLoot()
		{
			int loots = Main.rand.Next(2);
			switch (loots)
			{
				case 1:
					Item.NewItem(npc.getRect(), ModContent.ItemType<QuartzChunk>(), Main.rand.Next(2, 3));
					break;
				case 2:
					Item.NewItem(npc.getRect(), ModContent.ItemType<QuartzChunk>(), Main.rand.Next(4, 6));
					break;
			}
		}
	}
}