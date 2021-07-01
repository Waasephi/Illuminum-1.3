using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Projectiles
{
	public class BrimlanceProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.aiStyle = 1;
			projectile.thrown = true;
			projectile.penetrate = 1;      //this is how many enemy this projectile penetrate before disappear
			projectile.extraUpdates = 1;
			aiType = 507;
			Main.projFrames[projectile.type] = 1;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, 0f, 0f, 1f);
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 500f)       //how much time the projectile can travel before landing
			{
				projectile.velocity.Y = projectile.velocity.Y;    // projectile fall velocity
				projectile.velocity.X = projectile.velocity.X * 5f;    // projectile velocity
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 69);
			Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 27);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ProjectileID.DD2ExplosiveTrapT2Explosion, projectile.damage, projectile.knockBack, projectile.owner);
			for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire);
				Main.dust[d].scale = .5f;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
				target.AddBuff(BuffID.Burning, 180);
		}
		public override bool PreAI()
		{
			//    projectile.rotation += 0.1f;
			return true;
		}
	}
}