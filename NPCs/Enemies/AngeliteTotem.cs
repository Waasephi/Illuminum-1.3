using Illuminum.Items.Banners;
using Illuminum.Items.Materials;
using Microsoft.Xna.Framework;
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
		int _delay = 0;
		int _reload = 0;
		public override void SetDefaults()
		{
			_reload = 0;
			_delay = 0;
			npc.width = 26;
			npc.height = 44;
			npc.damage = 35;
			npc.lifeMax = 800;
			npc.life = 800;
			npc.defense = 40;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.knockBackResist = 0f;
			npc.value = 1000f;
			npc.lavaImmune	=	true;
			banner = npc.type;
			bannerItem = ModContent.ItemType<AngeliteTotemBanner>();
		}

		public override void AI()
		{
			if (Main.player[npc.target].Center.X > npc.Center.X)
				npc.spriteDirection = 0;
			else
				npc.spriteDirection = 0;
			Vector2 adj;
			adj.X = -npc.width / 4;
			adj.Y = -npc.height / 2;
			_delay--;
			if (_delay <= 0)
			{
				_reload++;
				if (_reload < 45)
				{
					if (Main.rand.Next(4) == 0)
					{
						if (Main.netMode != NetmodeID.MultiplayerClient)
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, npc.velocity.X - 4 + Main.rand.Next(9), -Main.rand.Next(6, 9), ProjectileID.DD2DarkMageBolt, (int)(npc.damage / 2), 3, Main.myPlayer);
					}
				}
				else
				{
					_reload = 0;
					_delay = 240;
				}
			}

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