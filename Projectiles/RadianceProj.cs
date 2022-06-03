using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Runtime.Remoting.Messaging;
using Microsoft.Xna.Framework.Graphics;

namespace Illuminum.Projectiles
{
	public class RadianceProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.aiStyle = 0;
			projectile.thrown = false;
			projectile.penetrate = 5;      //this is how many enemy this projectile penetrate before disappear
			projectile.extraUpdates = 1;
			aiType = 507;
			Main.projFrames[projectile.type] = 1;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiance");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 30;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void AI()
		{
			projectile.ai[0]++;

			if (projectile.ai[0] == 20)
            {
				projectile.velocity *= 0.5f;
				projectile.penetrate = 1;


				for (int i = 0; i < projectile.oldPos.Length; i++)
				{
					for (int k = 0; k < 8; k++)
                    {
						Dust dust;
						// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
						Vector2 position = projectile.oldPos[i];
						dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, DustID.SolarFlare, 0f, 0f, 0, new Color(255, 255, 255), 0.828947f)];
						dust.noGravity = true;
					}
				}
			}
			if (projectile.ai[0] > 20)
            {
				projectile.velocity.Y += 0.1f;
            }
            else
            {
				projectile.velocity *= 1.01f;
			}

			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
		}

        public override Color? GetAlpha(Color lightColor)
		{
			if (projectile.ai[0] < 20) return Color.Yellow;
			else return Color.Yellow;
		}

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			spriteBatch.End();
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);
			if (projectile.ai[0] < 20)
			{
				for (int i = 0; i < projectile.oldPos.Length; i++)
				{
					Color col = Color.Yellow;
					col.A = 255;
					spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.oldPos[i] + new Vector2(projectile.width / 2, projectile.height / 2) - Main.screenPosition,
					new Rectangle(0, 0, 14, 30), col, projectile.rotation,
					new Vector2(10 * 0.5f, 10 * 0.5f), Vector2.Lerp(new Vector2(1, 1), new Vector2(1, 0.3f), i / projectile.oldPos.Length), SpriteEffects.None, 0f);
					spriteBatch.Draw(Main.projectileTexture[projectile.type], Vector2.Lerp(projectile.oldPos[i], projectile.oldPos[(int)MathHelper.Clamp(i - 1, 0, projectile.oldPos.Length)], 0.5f) + new Vector2(projectile.width / 2, projectile.height / 2) - Main.screenPosition,
					new Rectangle(0, 0, 14, 30), col, projectile.rotation,
					new Vector2(10 * 0.5f, 10 * 0.5f), Vector2.Lerp(new Vector2(1, 1), new Vector2(1, 0.3f), i / projectile.oldPos.Length), SpriteEffects.None, 0f);
				}
			}
			else
			{
				for (int i = 0; i < projectile.oldPos.Length / 2; i++)
				{
					Color col = Color.Orange;
					col.A = 255;
					spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.oldPos[i] + new Vector2(projectile.width / 2, projectile.height / 2) - Main.screenPosition,
					new Rectangle(0, 0, 14, 30), col, projectile.rotation,
					new Vector2(10 * 0.5f, 10 * 0.5f), Vector2.Lerp(new Vector2(1, 1), new Vector2(1, 0.3f), i / projectile.oldPos.Length / 2), SpriteEffects.None, 0f);
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
		{
			projectile.Kill();
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
			return false;
		}
	}
}