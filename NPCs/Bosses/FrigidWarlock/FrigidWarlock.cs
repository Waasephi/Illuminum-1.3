using Illuminum.Items.Vanity.BossMasks;
using Illuminum.Items.Weapons.Melee;
using Illuminum.Items.Weapons.Magic;
using Illuminum.Items.Weapons.Ranged;
using Illuminum.Items.Weapons.Summoner;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace Illuminum.NPCs.Bosses.FrigidWarlock
{
    [AutoloadBossHead]
    public class FrigidWarlock : BaseNPC
    {

        private ref float AIIncrementer => ref npc.ai[0]; // Timer for state change
        private ref float State => ref npc.ai[1]; // State keeper
        private ref float AttackTimer => ref npc.ai[2]; // Communal timer between attacks
        private ref float AttackFourTimer => ref npc.ai[3]; // Specific to attack four! Do not use outside of that.

        private bool _phase2;
        private bool _shouldMoveDuringAttack; // Also specific to attack four!
        private Vector2 savedPos;
        private const int MAXSTATES = 3; // Increment if you add more attacks

        #region Basic Overridable Stuff
        public override void SetDefaults()
        {
            npc.width = 54;
            npc.height = 80;
            npc.damage = 40;
            npc.lifeMax = 4000;
            npc.defense = 5;
            npc.boss = true;

            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath5;

            npc.value = 17000f;

            npc.knockBackResist = 0f;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/FrigidFury");
            bossBag = mod.ItemType("FrigidWarlockTreasureBag");
            npc.lavaImmune = true; // why? it's a prehardmode boss...
            npc.noGravity = true;
            npc.noTileCollide = true;
        }
        public override void AI()
        {
            npc.TargetClosest();
            ChangeState();
            GetState(State);
            CheckIfPhaseShouldChange();
            RotateBoss();
        }
        public override void NPCLoot()
        {
            if (!Main.expertMode)
            {
                int loots = Main.rand.Next(4);
                switch (loots)
                {
                    case 0:
                        Item.NewItem(npc.getRect(), mod.ItemType("FrigidFlayer"), 1);
                        break;
                    case 1:
                        Item.NewItem(npc.getRect(), mod.ItemType("FrigidStaff"), 1);
                        break;
                    case 2:
                        Item.NewItem(npc.getRect(), mod.ItemType("FrigidWand"), 1);
                        break;
                    case 3:
                        Item.NewItem(npc.getRect(), mod.ItemType("FrigidSniper"), 1);
                        break;
                }
                int loots3 = Main.rand.Next(7);
                switch (loots3)
                {
                    case 0:
                        Item.NewItem(npc.getRect(), mod.ItemType("FrigidWarlockMask"), 1);
                        break;
                }
            }
            {
                int loots2 = Main.rand.Next(10);
                switch (loots2)
                {
                    case 1: Item.NewItem(npc.getRect(), mod.ItemType("FrigidWarlockTrophy"), 1); break;
                    case 2: break;
                }
            }
            IlluminumWorld.downedFrigidWarlock = true;
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
        }
        private void RotateBoss() => npc.rotation = npc.velocity.Y * (float)npc.direction * 0.05f;
        private void ChangeState()
        {
            AIIncrementer++;
            AttackTimer += _phase2 == false ? 1 : 2f;
            if (AIIncrementer >= 10.ToSeconds())
            {
                State++;
                if (State > MAXSTATES)
                    State = 0;
                // Main.NewText("State: " + State);
            }
            else return;
            if (State == 2)
            {
                savedPos = target.position + new Vector2(0, -32);
                Main.PlaySound(SoundID.DD2_DrakinBreathIn, npc.position);
            }
            AttackTimer = 0;
            AIIncrementer = 0;
            _shouldMoveDuringAttack = true;
        }
        private void GetState(float st)
        {
            switch (st)
            {
                case 0:
                    MovementStyleOne();
                    AttackStyleOne();
                    break;
                case 1:
                    MovementStyleOne();
                    AttackStyleTwo();
                    break;
                case 2:
                    MovementStyleTwo();
                    AttackStyleThree();
                    break;
                case 3:
                    if (_phase2)
                    {
                        if (_shouldMoveDuringAttack)
                            MovementStyleOne();
                        AttackStyleFour();
                    }
                    else State = 0;
                    break;

                default:
                    State = 0;
                    break;
            }
        }
        private bool CheckIfPhaseShouldChange()
        {
            if (npc.life <= npc.lifeMax / 2 && !_phase2)
            {
                _phase2 = true;
                // Main.NewText("Phase 2 activated!");
            }
            return true;
        }
        #endregion
        public Player target => Main.player[npc.target];
        #region MovementStyles
        private void MovementStyleOne()
        {
            BasicMover(target.Center + new Vector2(0, -200), 16f, 15);
        }
        private void MovementStyleTwo()
        {
            BasicMover(savedPos, 3f, 0f);
        }
        #endregion

        #region AttackStyles
        private void AttackStyleOne()
        {
            if (AttackTimer < 3.ToSeconds())
                return;
            float desiredVel = 13;
            var possiblePositions = new Vector2[] { // could use math.sign and some if statements but whatever
                new Vector2(-desiredVel, 0),
                new Vector2(desiredVel, 0)
            };

            for (int i = 0; i < 2; i++)
            {
                WarlockProj p = (WarlockProj)Projectile.NewProjectileDirect(npc.Center, possiblePositions[i], ModContent.ProjectileType<WarlockProj>(), 10, 10).modProjectile;
                p.target = target;
                p.speed = 10f;
                p.timeUntilTurning = 1.ToSeconds();
                p.maxTimesTurned = 7;
            }
            AttackTimer = 0;
        }
        private void AttackStyleTwo()
        {
            if (AttackTimer < 3.ToSeconds())
                return;
            float desiredVel = 12;
            var possiblePositions = new Vector2[] { // could use math.sign and some if statements but whatever
                new Vector2(-desiredVel, 0),
                new Vector2(desiredVel, 0)
            };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Vector2 rotatedVect = possiblePositions[i].RotatedByRandom(Math.PI / 2);
                    WarlockProj2 p = (WarlockProj2)Projectile.NewProjectileDirect(npc.Center, rotatedVect, ModContent.ProjectileType<WarlockProj2>(), 15, 15).modProjectile;
                }
            }

            AttackTimer = 0;
        }
        private void AttackStyleThree()
        {
            if (AttackTimer < 1.ToSeconds())
                return;
            float desiredVel = 10;
            var possiblePositions = new Vector2[] { // could use math.sign and some if statements but whatever
                new Vector2(-desiredVel, 0),
                new Vector2(desiredVel, 0)
            };

            for (int i = 0; i < 2; i++)
            {
                WarlockProj3 p = (WarlockProj3)Projectile.NewProjectileDirect(npc.Center, possiblePositions[i], ModContent.ProjectileType<WarlockProj3>(), 10, 10).modProjectile;
                p.target = target;
                p.speed = 15f;
                p.timeUntilTurning = 1.ToSeconds();
                p.maxTimesTurned = 1;
            }
            AttackTimer = 0;
        }
        private void AttackStyleFour()
        {
            if (AttackTimer < 3.ToSeconds())
                return;
            _shouldMoveDuringAttack = false;
            npc.velocity = Vector2.Zero;
            AttackFourTimer++;
            var possiblePositions = new Vector2[] {
                new Vector2(0, 1).RotatedBy(-(Math.PI / 6)),
                new Vector2(0, 1),
                new Vector2(0, 1).RotatedBy(Math.PI / 6)
            };

            if (AttackFourTimer >= 0.75f.ToSeconds())
            {
                for (int i = 0; i < 2; i++)
                {
                    WarlockProj p = (WarlockProj)Projectile.NewProjectileDirect(npc.Center, possiblePositions[i], ModContent.ProjectileType<WarlockProj>(), 15, 15).modProjectile;
                    p.target = target;
                    p.speed = 20f;
                    p.timeUntilTurning = 1.ToSeconds();
                    p.maxTimesTurned = 7;
                }
                AttackFourTimer = 0;
                AttackTimer = 0;
                _shouldMoveDuringAttack = true;
            }
        }
        #endregion

        #region Sharing Fields
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.WriteVector2(savedPos);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            savedPos = reader.ReadVector2();
        }
        #endregion
    }
    public class WarlockProj : ModProjectile
    {
        public Player target;
        public float speed;
        public byte maxTimesTurned;
        public int timeUntilTurning;

        private int upCounter;
        private byte timesTurned;
        private const int _MAXTIMELEFT = 1000;

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 28;

            projectile.hostile = true;
            projectile.damage = 20;
            projectile.timeLeft = _MAXTIMELEFT;
        }

        public override void AI()
        {
            upCounter++;
            if (upCounter == timeUntilTurning && timesTurned < maxTimesTurned)
            {
                projectile.velocity = (new Vector2(projectile.Center.X - target.Center.X, projectile.Center.Y - target.Center.Y).SafeNormalize(Vector2.Zero) * speed) * -1;
                timesTurned++;
                upCounter = 0;
            }
            projectile.rotation = projectile.velocity.ToRotation() - MathHelper.PiOver2;
            Dust.NewDustPerfect(projectile.Center, DustID.Ice, Scale: 0.8f);
            Main.projFrames[projectile.type] = 4;
            projectile.tileCollide = false;
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 4) //once the frameCounter has reached 10 - change the 10 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 3) //if past the last frame
                    projectile.frame = 0; //go back to the first frame
            }
            return true;
        }
    }
    public class WarlockProj2 : ModProjectile
    {
        public Player target;
        public float speed;
        public byte maxTimesTurned;
        public int timeUntilTurning;

        private int upCounter;
        private byte timesTurned;
        private const int _MAXTIMELEFT = 1000;

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 26;

            projectile.hostile = true;
            projectile.damage = 40;
            projectile.timeLeft = _MAXTIMELEFT;
        }

        public override void AI()
        {
            upCounter++;
            if (upCounter == timeUntilTurning && timesTurned < maxTimesTurned)
            {
                projectile.velocity = (new Vector2(projectile.Center.X - target.Center.X, projectile.Center.Y - target.Center.Y).SafeNormalize(Vector2.Zero) * speed) * -1;
                timesTurned++;
                upCounter = 0;
            }
            projectile.rotation = projectile.velocity.ToRotation() - MathHelper.PiOver2;
            Dust.NewDustPerfect(projectile.Center, DustID.Ice, Scale: 0.8f);
            projectile.tileCollide = false;
        }
    }
    public class WarlockProj3 : ModProjectile
    {
        public Player target;
        public float speed;
        public byte maxTimesTurned;
        public int timeUntilTurning;

        private int upCounter;
        private byte timesTurned;
        private const int _MAXTIMELEFT = 1000;

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 26;

            projectile.hostile = true;
            projectile.damage = 20;
            projectile.timeLeft = _MAXTIMELEFT;
        }

        public override void AI()
        {
            upCounter++;
            if (upCounter == timeUntilTurning && timesTurned < maxTimesTurned)
            {
                projectile.velocity = (new Vector2(projectile.Center.X - target.Center.X, projectile.Center.Y - target.Center.Y).SafeNormalize(Vector2.Zero) * speed) * -1;
                timesTurned++;
                upCounter = 0;
            }
            projectile.rotation = projectile.velocity.ToRotation() - MathHelper.PiOver2;
            Dust.NewDustPerfect(projectile.Center, 19, Scale: 0.8f);
            Main.projFrames[projectile.type] = 4;
            projectile.tileCollide = false;
        }

        public override bool PreDraw(SpriteBatch sb, Color lightColor) //this is where the animation happens
        {
            projectile.frameCounter++; //increase the frameCounter by one
            if (projectile.frameCounter >= 4) //once the frameCounter has reached 10 - change the 10 to change how fast the projectile animates
            {
                projectile.frame++; //go to the next frame
                projectile.frameCounter = 0; //reset the counter
                if (projectile.frame > 3) //if past the last frame
                    projectile.frame = 0; //go back to the first frame
            }
            return true;
        }
    }
}
