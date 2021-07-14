using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles.Ammo
{
    public class StoneSpikeProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 1;                       //this is the projectile penetration
            Main.projFrames[projectile.type] = 1;           //this is projectile frames
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.aiStyle = 1;
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {                                                           // sound that the projectile make when hitting the terrain
            {
                projectile.Kill();

                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }
    }
}