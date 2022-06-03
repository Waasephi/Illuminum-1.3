using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Projectiles.Minions
{
    // PurityWisp uses inheritace as an example of how it can be useful in modding.
    // HoverShooter and Minion classes help abstract common functionality away, which is useful for mods that have many similar behaviors.
    // Inheritance is an advanced topic and could be confusing to new programmers, see ExampleSimpleMinion.cs for a simpler minion example.
    public class MiniDragon : HoverShooter
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 36;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            inertia = 20f;
            shoot = ProjectileID.Flames;
            shootSpeed = 8f;
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (player.dead)
            {
                modPlayer.miniDragon = false;
            }
            if (modPlayer.miniDragon)
            { // Make sure you are resetting this bool in ModPlayer.ResetEffects. See ExamplePlayer.ResetEffects
                projectile.timeLeft = 2;
            }
        }

        public override void SelectFrame()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 3;
            }
        }
    }
}