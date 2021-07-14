using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using System.Runtime.Remoting.Messaging;
using Microsoft.Xna.Framework.Graphics;

namespace Illuminum.Projectiles
{
	public class CrimriseBolt2 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.aiStyle = 0;
			projectile.thrown = false;
			projectile.penetrate = 1;      //this is how many enemy this projectile penetrate before disappear
			projectile.extraUpdates = 1;
			aiType = 507;
			Main.projFrames[projectile.type] = 1;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 20;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

        public override void AI()
		{
			projectile.ai[0] += 1f;
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			projectile.localAI[0] += 1f;
			if (projectile.ai[0] >= 100f)       //how much time the projectile can travel before landing
			{
				projectile.velocity.X = projectile.velocity.X * 1.5f;    // projectile velocity
				projectile.Kill();
			}
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Rainbow, 0f, 0f, 100, new Color(92, 3, 13));
			Main.dust[dust].velocity *= 0.1f;
			if (projectile.velocity == Vector2.Zero)
			{
				Main.dust[dust].velocity.Y -= 1f;
				Main.dust[dust].scale = 1.2f;
			}
			else
			{
				Main.dust[dust].velocity += projectile.velocity * 0.2f;
			}
			Main.dust[dust].position.X = projectile.Center.X + 4f + Main.rand.Next(-2, 3);
			Main.dust[dust].position.Y = projectile.Center.Y + Main.rand.Next(-2, 3);
			Main.dust[dust].noGravity = true;
		}


        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			for (int i = 1; i < projectile.oldPos.Length; i++)
			{
				projectile.oldPos[i] = projectile.oldPos[i - 1] + (projectile.oldPos[i] - projectile.oldPos[i - 1]).SafeNormalize(Vector2.Zero) * MathHelper.Min(Vector2.Distance(projectile.oldPos[i - 1], projectile.oldPos[i]), 6);
			}

			spriteBatch.End();
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);
			{
				for (int i = 0; i < projectile.oldPos.Length; i++)
				{
					Color col = Color.Lerp(Color.White, Color.Red, i / projectile.oldPos.Length);
					col.A = 255;
					spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.oldPos[i] + new Vector2(projectile.width / 2, projectile.height / 2) - Main.screenPosition,
					new Rectangle(0, 0, 8, 8), col, projectile.rotation,
					new Vector2(8 * 0.5f, 8 * 0.5f), Vector2.Lerp(new Vector2(1, 1), new Vector2(0, 0), (float)i / (float)projectile.oldPos.Length), SpriteEffects.None, 0f);
				}
			}
			return true;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			spriteBatch.End();
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);
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