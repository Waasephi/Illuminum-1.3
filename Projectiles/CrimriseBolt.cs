using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using System.Runtime.Remoting.Messaging;

namespace Illuminum.Projectiles
{
	public class CrimriseBolt : ModProjectile
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
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66, 0f, 0f, 100, new Color(92, 3, 13));
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