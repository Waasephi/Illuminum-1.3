using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Illuminum
{
    class IlluminumGlobalProjectile : GlobalProjectile //Need to add a global projectile class.
    {
        public override void PostAI(Projectile projectile) //Using this for dust effects.
        {
            Player player = Main.player[projectile.owner];
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();

            if (modPlayer.venomGauntlet && projectile.melee && Main.rand.NextFloat() <= 0.8f)
            {
                int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Venom, 0, 0, 100, default, 1.2f); //Haven't updated tML, 171 is DustID.Venom.
                Main.dust[d].noGravity = true;
                Main.dust[d].velocity = Vector2.Zero;
            }
            if (modPlayer.poisonGlove && projectile.melee && Main.rand.NextFloat() <= 0.8f)
            {
                int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Poisoned, 0, 0, 100, default, 1.2f); //Haven't updated tML, 171 is DustID.Venom.
                Main.dust[d].noGravity = true;
                Main.dust[d].velocity = Vector2.Zero;
            }
            if (modPlayer.frostStone && !projectile.minion && Main.rand.NextFloat() <= 0.8f)
            {
                int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Frost, 0, 0, 100, default, 1.2f); //Haven't updated tML, 171 is DustID.Venom.
                Main.dust[d].noGravity = true;
                Main.dust[d].velocity = Vector2.Zero;
            }
            base.PostAI(projectile);
        }

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (modPlayer.venomGauntlet && projectile.melee)
            {
                target.AddBuff(BuffID.Venom, 10 * 60);

            }
            base.OnHitNPC(projectile, target, damage, knockback, crit);
            if (modPlayer.poisonGlove && projectile.melee)
            {
                target.AddBuff(BuffID.Poisoned, 10 * 60);
            }
            base.OnHitNPC(projectile, target, damage, knockback, crit);
            if (modPlayer.frozenQuiver && projectile.ranged)
            {
                target.AddBuff(BuffID.Frostburn, 10 * 60);
            }
            base.OnHitNPC(projectile, target, damage, knockback, crit);
            if (modPlayer.frostStone)
            {
                target.AddBuff(BuffID.Frostburn, 10 * 60);
            }
            base.OnHitNPC(projectile, target, damage, knockback, crit);

        }
    }
}