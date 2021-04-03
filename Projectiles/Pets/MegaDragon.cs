using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles.Pets
{
    public class MegaDragon : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Paper Airplane"); // Automatic from .lang files
            Main.projFrames[projectile.type] = 3;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(701);
            aiType = 701;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.zephyrfish = false; // Relic from aiType
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (player.dead)
            {
                modPlayer.megaDragon = false;
            }
            if (modPlayer.megaDragon)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}