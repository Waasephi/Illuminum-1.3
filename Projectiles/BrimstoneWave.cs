using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles
{
	class BrimstoneWave : ModProjectile
	{
		int timer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brimstone Wave");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.timeLeft = 210;
			projectile.height = 20;
			projectile.width = 30;
			projectile.penetrate = 2;
			aiType = ProjectileID.Bullet;
			projectile.extraUpdates = 1;
		}

        public override void AI()
        {
			projectile.ai[0]++;
			if (projectile.ai[1] == 3) projectile.velocity = projectile.velocity.RotatedBy(Math.Cos(projectile.ai[0] * 0.1f) * MathHelper.ToRadians(2f));
			if (projectile.ai[1] == 4) projectile.velocity = projectile.velocity.RotatedBy(Math.Cos(projectile.ai[0] * 0.1f) * MathHelper.ToRadians(-2f));
			if (projectile.ai[1] < 3)
            {
				projectile.velocity *= 0.97f;
				if (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) / 2 < 0.2f)
                {
					projectile.Kill();
                }
			}
			projectile.tileCollide = false;
		}
        public override void Kill(int timeLeft)
		{
			for (int num623 = 0; num623 < 50; num623++)
			{
				int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 1.5f;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			float vel = MathHelper.Clamp(Vector2.Distance(projectile.Center, projectile.Center + projectile.velocity) / 10, 0, 0.6f);

			Vector2 sc = new Vector2(1, 1);
			if (projectile.ai[1] < 3) sc = new Vector2(1 - vel, 1 + vel);
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, sc, SpriteEffects.None, 0f);
			}
			return false;
		}

		public override bool PreAI()
		{
			projectile.alpha++;
			float num = 1f - (float)projectile.alpha / 255f;
			projectile.velocity *= .98f;
			projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
			num *= projectile.scale;
			Lighting.AddLight(projectile.Center, 0.3f * num, 0.2f * num, 0.1f * num);
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			return true;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 200, 122, 100);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
				target.AddBuff(BuffID.OnFire, 240);
		}

	}
}