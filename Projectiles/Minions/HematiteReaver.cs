using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles.Minions
{
    public class HematiteReaver : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 78;
            projectile.height = 42;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.aiStyle = 66;
            projectile.minionSlots = 1f;
            projectile.timeLeft = 18000;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            aiType = 388;
            Main.projFrames[projectile.type] = 2;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);// + 1.57f;

            if (projectile.velocity.X < 0) projectile.frame = 1;
            else projectile.frame = 0;

            Player player = Main.player[projectile.owner];
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (player.dead)
            {
                modPlayer.hematiteReaver = false;
            }
            if (modPlayer.hematiteReaver)
            {
                projectile.timeLeft = 2;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
    }
}