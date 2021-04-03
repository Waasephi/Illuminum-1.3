using Illuminum.Items.Banners;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.NPCs.Enemies
{
	public class AngeliteTotem : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angelite Totem");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.width = 26;
			npc.height = 44;
			npc.damage = 50;
			npc.lifeMax = 400;
			npc.life = 400;
			npc.defense = 20;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.knockBackResist = 0f;
			npc.value = 1000f;
			banner = npc.type;
			bannerItem = ModContent.ItemType<AngeliteTotemBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.player.ZoneHoly ? 0.5f : 0f;
		}

		public override void NPCLoot()
		{
					Item.NewItem(npc.getRect(), ModContent.ItemType<AngeliteChunk>(), Main.rand.Next(5, 10));
		}
	}
}