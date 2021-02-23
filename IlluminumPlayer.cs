using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace Illuminum
{
	public class IlluminumPlayer : ModPlayer
	{
		public bool Drained; //reset to false
		public bool frigidWarlite; //reset to false
		
		public bool frostDefense; //reset to false
		
		public override void ResetEffects()
		{
			Drained = false;
			frigidWarlite = false;
			frostDefense = false;
		}
		
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
		if(frostDefense)
		{
			float xVel = Main.rand.NextFloat(-16f, 16f);
			float yVel = Main.rand.NextFloat(-16f, 16f);
			for(int i = 0; i < 3; i++)
			{
                        	int p = Projectile.NewProjectile(player.position, new Vector2(xVel, yVel), ProjectileID.BallofFrost, 13, 0.5f, player.whoAmI);
                        	//Tweak values as you'd like.
                        	Main.projectile[p].timeLeft = 60;
			}
		}
	}
}
}
