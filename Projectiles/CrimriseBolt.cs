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
	public class CrimriseBolt : ModProjectile
	{
		public float start = 0;

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.aiStyle = 0;
			projectile.thrown = false;
			projectile.penetrate = 1;      //this is how many enemy this projectile penetrate before disappear
			projectile.extraUpdates = 1;
			aiType = 507;
			projectile.timeLeft = 200;
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
			start = MathHelper.Lerp(start, 6, 0.05f);
			projectile.ai[0] += 1f;
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			projectile.localAI[0] += 1f;
			if (projectile.ai[0] >= 100f)       //how much time the projectile can travel before landing
			{
				projectile.velocity.X = projectile.velocity.X * 1.5f;    // projectile velocity
				projectile.Kill();
            }
            if (projectile.ai[1] == 1)
			{
				if (projectile.ai[0] > 20)
				{
					projectile.velocity.X *= 0.98f;
					projectile.velocity.Y += 0.18f;
				}
			}
			if (projectile.ai[1] == 2)
            {
				Player projOwner = Main.player[projectile.owner];

				if (projOwner.itemAnimation > projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
				{
					projectile.position += projOwner.velocity / 2; 
				}
				if (projOwner.itemAnimation == (float)Math.Floor((decimal)projOwner.itemAnimationMax / 3))
				{
					projectile.velocity *= 2.4f;
					projectile.velocity.X += Main.rand.NextFloat(-2f, 2f);
					projectile.velocity.Y += Main.rand.NextFloat(-2f, 2f);
				}
            }
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			for (int i = 1; i < projectile.oldPos.Length; i++)
			{
				projectile.oldPos[i] = projectile.oldPos[i - 1] + (projectile.oldPos[i] - projectile.oldPos[i - 1]).SafeNormalize(Vector2.Zero) * MathHelper.Min(Vector2.Distance(projectile.oldPos[i - 1], projectile.oldPos[i]), start);
			}

			spriteBatch.End();
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);
			{
				Color col = Color.Red;
				col.A = 255;
				for (int i = 0; i < projectile.oldPos.Length; i++)
				{
					spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.oldPos[i] + new Vector2(projectile.width / 2, projectile.height / 2) - Main.screenPosition,
					new Rectangle(0, 0, 16, 16), col, projectile.rotation,
					new Vector2(16 * 0.5f, 16 * 0.5f), Vector2.Lerp(new Vector2(0.5f, 0.5f), new Vector2(0, 0), (float)i / (float)projectile.oldPos.Length), SpriteEffects.None, 0f);
				}

				spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.position + new Vector2(projectile.width / 2, projectile.height / 2) - Main.screenPosition,
				   new Rectangle(0, 0, 16, 16), col, projectile.rotation,
				   new Vector2(16 * 0.5f, 16 * 0.5f), 1f, SpriteEffects.None, 0f);
			}
			return false;
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

				for (int i = 0; i < 6; i++)
                {
					Dust dust;
					Vector2 position = projectile.Center;
					dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 174, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
					dust.noGravity = true;
				}

				Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
			}
			return false;
		}
	}
}