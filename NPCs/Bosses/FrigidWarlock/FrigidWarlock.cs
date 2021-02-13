using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Illuminum.NPCs.Bosses.FrigidWarlock {
    [AutoloadBossHead]
    public class FrigidWarlock : BaseNPC {

        private ref float AIIncrementer => ref npc.ai[0];
        private ref float State => ref npc.ai[1];
        public ref float AttackTimer => ref npc.ai[2];
        private const int MAXSTATES = 3;

        #region Basic Overridable Stuff
        public override void SetDefaults() {
            npc.width = 54;
            npc.height = 80;
            npc.damage = 30;

            npc.lifeMax = 5000;
            npc.life = 5000;
            npc.defense = 5;
            npc.boss = true;

            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath5;

            npc.value = 17000f;

            npc.knockBackResist = 0f;

            npc.lavaImmune = true; // why? it's a prehardmode boss...
            npc.noGravity = true;
            npc.noTileCollide = true;
        }
        public override void AI() {
            npc.TargetClosest();
            ChangeState();
            GetState(State);
        }
        private void ChangeState() {
            AIIncrementer++;
            AttackTimer++;

            if (AIIncrementer >= 10.ToSeconds()) {
                State = State == MAXSTATES ? 0 : State++;
                Main.NewText("State: " + State);
            }
            else return;
            AttackTimer = 0;
            AIIncrementer = 0;
        }
        private void GetState(float st) {
            switch (st) {
                case 0:
                    MovementStyleOne();
                    AttackStyleOne();
                    break;
                default:
                    State = 0;
                    goto case 0;
            }
        }
        #endregion
        public Player target => Main.player[npc.target];
        #region MovementStyles
        private void MovementStyleOne() {
            BasicMover(target.Center + new Vector2(0, -200), 8f, 15);
        }
        #endregion

        #region AttackStyles
        private void AttackStyleOne() {
            if (AttackTimer < 2.ToSeconds())
                return;
            Vector2 shootVel = Vector2.Normalize(new Vector2(target.Center.X - npc.Center.X, target.Center.Y - npc.Center.Y)) * 10f;
            float desiredVel = 5;
            var possiblePositions = new Vector2[] { // could use math.sign and some if statements but whatever
                new Vector2(-desiredVel, 0),
                new Vector2(desiredVel, 0)
            };

            for (int i = 0; i < 2; i++) {
                WarlockProj p = (WarlockProj)Projectile.NewProjectileDirect(npc.Center, possiblePositions[i], ModContent.ProjectileType<WarlockProj>(), 10, 10).modProjectile;
                p.timeUntilTurning = (0.5f).ToSeconds();
                p.target = target;
                p.speed = 8f;
            }
            AttackTimer = 0;
        }
        #endregion
    }
    public class WarlockProj : ModProjectile {
        public float timeUntilTurning;
        public Player target;
        public float speed;
        const int _MAXTIMELEFT = 1000;

        public override void SetDefaults() {
            projectile.width = 16;
            projectile.height = 16;

            projectile.hostile = true;
            projectile.damage = 20;
            projectile.timeLeft = _MAXTIMELEFT;
        }

        public override void AI() {
            if(projectile.timeLeft == _MAXTIMELEFT - timeUntilTurning) {
                projectile.velocity = (projectile.DirectionTo(target.Center) * speed) + target.velocity;
            }
            Dust.NewDustPerfect(projectile.Center, DustID.Ice, Scale: 0.8f);
        }
    }
}
