using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Items.Weapons.Ranged;

namespace Illuminum.Projectiles
{
	public class GlacialKunaiProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.aiStyle = 1;
			projectile.ranged = true;
			projectile.penetrate = 2;      //this is how many enemy this projectile penetrate before disappear
			projectile.extraUpdates = 1;
			aiType = 507;
			Main.projFrames[projectile.type] = 1;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.position, 0f, 0f, 2f);
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 250f)       //how much time the projectile can travel before landing
			{
				projectile.velocity.Y = projectile.velocity.Y * 0.2f;    // projectile fall velocity
				projectile.velocity.X = projectile.velocity.X * 2f;    // projectile velocity
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{                                                           // sound that the projectile make when hitting the terrain
			projectile.Kill();
			Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 50);
			for (int i = 1; i < 5; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Ice, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 1, default(Color), 3.50f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
				Main.dust[dust].noGravity = true; //this make so the dust has no gravity
				Main.dust[dust].velocity *= 0f;
			}
			return false;

		}
	}
}