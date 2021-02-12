using Microsoft.Xna.Framework;
using Illuminum.Items;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.NPCs.Bosses.FrigidWarlock
{
	[AutoloadBossHead]
	public class FrigidWarlock : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frigid Warlock");
		}

		public override void SetDefaults()
		{
			npc.width = 54;
			npc.height = 80;
			npc.damage = 30;
			npc.lifeMax = 5000;
			npc.life = 5000;
			npc.defense = 5;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath5;
			npc.value = 17000f;
			npc.knockBackResist = 0f;
			npc.boss = true;
			//bossBag = ModContent.ItemType<FrigidWarlockTreasureBag>();
			//music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/boss2");
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
		}

		public override void NPCLoot()
		{
			if (!Main.expertMode)
			{

			}

			/* {
                 int loots2 = Main.rand.Next(10);
                 switch (loots2)
                 {
                     case 1: Item.NewItem(npc.getRect(), ModContent.ItemType<FrigidWarlockTrophy>(), 1); break;
                     case 2: break;
                 }
             }*/
			/*MyWorld.downedFrigidWarlock = true;
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}*/
		}

		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = 188;
		}

        float[] ai = { 0, 0, 0, 0, 0 };
        float smallShootCD = 60f; //Constant, low-damage attack (think ice queen when it rains ice shards or angry nimbus)
        float largeShootCD = 120f; //Larger attack pattern (think Skeletron hands, or pumpking flaming scythes)
        ushort projectileType; //This is used and set throughout the code. Do not change its null value here.
        float baseAccel = 0.1f; //This is the AI's base acceleration modifier (adds to velocity).
        float accel = 0f; //This is used later. When the npc is close to the player, it reverts to baseAccel value.
        public override void AI()
        {
            float distance = float.MaxValue;
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Vector2.Distance(Main.player[i].Center, npc.Center) < distance && !Main.player[i].dead) //If another player is closer and alive, target THAT one.
                {
                    npc.target = i;
                    distance = Vector2.Distance(Main.player[i].Center, npc.Center); //Distance correctly set now. Previously remained float.MaxValue
                }
            }
            if (distance == float.MaxValue) //If there are no players found, disable this boss/npc.
            {
                npc.active = false;
                npc.timeLeft = 20;
            }
            Player target = Main.player[npc.target]; //This is our player target.
            if (ai[0] == 0) //PHASE 1
            {
                if (ai[3] == 0)
                {
                    npc.takenDamageMultiplier = 1f;

                    //npc.velocity = Vector2.Normalize(new Vector2(npc.Center.X - target.Center.X, npc.Center.Y - target.Center.Y - 320f)) * (3f * (1f + accel)); //Set the npc's velocity
                    npc.velocity = (new Vector2(target.Center.X - npc.Center.X, (target.Center.Y - 64f) - npc.Center.Y).SafeNormalize(Vector2.Zero)) * (3f * (0.9f + accel)); //Replaced Vector2.Normalize with Vector2().SafeNormalize() in multiple places.
                    if (Vector2.Distance(npc.Center, target.Center) > 160f) //If the npc is too far away, "slowly" increase acceleration.
                    {
                        if (accel < 0.2f)
                        {
                            accel += 0.001f;
                        }
                    }
                    else //If the npc is close enough, set velocity to its base value.
                    {
                        accel = baseAccel;
                    }
                    if (ai[1] > 0f) //Small shoot cooldown. This is its constant attack.
                    {
                        ai[1] += 1f;
                    }
                    if (ai[1] >= smallShootCD) //Small shoot cooldown over. This allows it to attack.
                    {
                        ai[1] = 0f;
                    }
                    if (target != null && ai[1] == 0f && ai[2] != 0f) //This is constant attack code. Disables when enemy is able to do a larger attack.
                    {
                        projectileType = (ushort)(ProjectileID.IceBolt); //Setting projectileType for NewProjectile
                        Vector2 shootVel = Vector2.Normalize(new Vector2(target.Center.X - npc.Center.X, target.Center.Y - npc.Center.Y)) * 10.5f; //Change 10.5f to the speed you want.
                        int p = Projectile.NewProjectile(npc.Center, shootVel, projectileType, 10, 2f, npc.whoAmI); //Creates new projectile at the npc's centre, with 10.5f speed, of type projectileType with 10 damage and 2f kb.
                        Main.projectile[p].penetrate = 2; //Pierces twice.
                        Main.projectile[p].timeLeft = 2000; //Should basically go until it hits something.
                        Main.projectile[p].friendly = false; //Doesn't hit enemies.
                        Main.projectile[p].hostile = true; //Hits players and town NPC's.
                    }
                    if (ai[2] > 0f) //Large shoot cooldown. This is a larger attack.
                    {
                        ai[2] += 1f;
                    }
                    if (ai[2] >= largeShootCD) //Large shoot cooldown over. This allows it to preform its larger attack.
                    {
                        ai[2] = 0f;
                    }
                }
                if (target != null && ai[2] == 0f) //The larger attack code
                {
                    ai[3] = 1f;
                    //Input large attacks here.
                    if (ai[3] == 1f)
                    {
                        ai[4] = Main.rand.NextFloat(1, 4);
                    }
                    if (ai[4] == 1f) //Attack type 1.
                    {
                        float seconds = 1f; //HOW LONG DOES THIS ATTACK LAST?
                        npc.velocity = Vector2.Zero;
                        projectileType = (ushort)(ProjectileID.IceBolt);
                        int p = Projectile.NewProjectile(new Vector2(npc.Center.X - 64f - Main.rand.NextFloat(0f, 32f), npc.Center.Y), Vector2.Zero, projectileType, 20, 0.5f, npc.whoAmI);
                        Main.projectile[p].velocity = Vector2.Normalize(new Vector2(Main.projectile[p].Center.X - target.Center.X, Main.projectile[p].Center.Y - target.Center.Y)) * 12.3f;
                        p = Projectile.NewProjectile(new Vector2(npc.Center.X + 64f + Main.rand.NextFloat(0f, 32f), npc.Center.Y), Vector2.Zero, projectileType, 20, 0.5f, npc.whoAmI);
                        Main.projectile[p].velocity = Vector2.Normalize(new Vector2(Main.projectile[p].Center.X - target.Center.X, Main.projectile[p].Center.Y - target.Center.Y)) * 12.3f;
                        if (ai[3] >= (seconds * 60f))
                        {
                            ai[4] = 0f; //Reset attack type
                            ai[3] = 0f; //Reset velocity and normal AI
                            ai[2] = 0f; //Reset can attack.
                        }
                        else
                        {
                            ai[3] += 1f;
                        }
                    }
                    if (ai[4] == 2f)
                    {
                        float seconds = 4f; //HOW LONG DOES THIS ATTACK LAST?
                        npc.velocity = Vector2.Zero;
                        if ((ai[3] % (seconds * 20)) - 1 == 0) //3 times in 2 seconds with maxValue 120f;
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                projectileType = (ushort)(ProjectileID.IceSpike);
                                int p = Projectile.NewProjectile(new Vector2(npc.Center.X - 64f - Main.rand.NextFloat(0f, 32f), npc.Center.Y + (i - 1f) * 32f), Vector2.Zero, projectileType, 20, 0.5f, npc.whoAmI);
                                Main.projectile[p].velocity = Vector2.Normalize(new Vector2(3, 5)) * 6.3f;
                                p = Projectile.NewProjectile(new Vector2(npc.Center.X + 64f + Main.rand.NextFloat(0f, 32f), npc.Center.Y + (i - 1f) * 32f), Vector2.Zero, projectileType, 20, 0.5f, npc.whoAmI);
                                Main.projectile[p].velocity = Vector2.Normalize(new Vector2(-3, 5)) * 6.3f;
                            }
                        }
                        if (ai[3] >= seconds * 60f)
                        {
                            ai[4] = 0f; //Reset attack type
                            ai[3] = 0f; //Reset velocity and normal AI
                            ai[2] = 0f; //Reset can attack.
                        }
                        else
                        {
                            ai[3] += 1f;
                        }
                    }
                    if (ai[4] == 3f)
                    {
                        float seconds = 6f; //HOW LONG DOES THIS ATTACK LAST?
                        npc.takenDamageMultiplier += 0.05f; //npc takes 5% more damage (reset at the top)
                        //npc.velocity = Vector2.Normalize(new Vector2(npc.Center.X - target.Center.X, npc.Center.Y - target.Center.Y - 32f)) * (3f * (1f + accel)); //Set the npc's velocity
                        npc.velocity = new Vector2(target.Center.X - npc.Center.X, target.Center.Y - npc.Center.Y - 32f).SafeNormalize(Vector2.Zero) * (3f * (0.9f + accel));
                        if (ai[3] >= (seconds * 60f)) //Reset after 6 sec.
                        {
                            ai[4] = 0f; //Reset attack type
                            ai[3] = 0f; //Reset velocity and normal AI
                            ai[2] = 0f; //Reset can attack.
                        }
                        else
                        {
                            ai[3] += 1f;
                        }
                    }
                }
            } //END OF PHASE 1
            if (npc.life <= (int)(npc.lifeMax * 0.40)) //PHASE 2
            {
                largeShootCD = 100f; //Adjust values
                smallShootCD = 45f; //Adjust values
            } //END OF PHASE 2
        }
    }
}