using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles
{
	class PhantomGGlaive : ModProjectile
	{
		int timer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phantom Glaive");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.timeLeft = 200;
			projectile.height = 18;
			projectile.width = 25;
			projectile.penetrate = 1;
			aiType = ProjectileID.Bullet;
			projectile.extraUpdates = 1;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y, 1);
			for (int num623 = 0; num623 < 50; num623++)
			{
				int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.BlueFairy, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 1.5f;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
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
			return new Color(98, 200, 222, 100);
		}

	}
}