using Terraria.ModLoader;

namespace Illuminum.Projectiles
{
	public class CursedFlamarangProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.magic = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 3000;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
		}
	}
}