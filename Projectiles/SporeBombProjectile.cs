using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles
{
	// to investigate: Projectile.Damage, (8843)
	internal class SporeBombProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			// while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
			projectile.width = 15;
			projectile.height = 15;
			projectile.friendly = true;
			projectile.penetrate = 1;

			// 5 second fuse.
			projectile.timeLeft = 300;

			// These 2 help the projectile hitbox be centered on the projectile sprite.
			drawOffsetX -= 1;
			drawOriginOffsetY = 5;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			// Vanilla explosions do less damage to Eater of Worlds in expert mode, so we will too.
			if (Main.expertMode)
			{
				if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail)
				{
					damage /= 5;
				}
			}
		}

		public override void AI()
		{
			if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
			{
				projectile.tileCollide = false;
				// Set to transparent. This projectile technically lives as  transparent for about 3 frames
				projectile.alpha = 255;
				// change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
				projectile.position = projectile.Center;
				//projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
				//projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
				projectile.width = 250;
				projectile.height = 250;
				projectile.Center = projectile.position;
				//projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
				//projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
				projectile.damage = 250;
				projectile.knockBack = 10f;
			}
			else
			
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 5f)
			{
				projectile.ai[0] = 10f;
				// Roll speed dampening.
				if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
				{
					projectile.velocity.X = projectile.velocity.X * 0.97f;
					//if (projectile.type == 29 || projectile.type == 470 || projectile.type == 637)
					{
						projectile.velocity.X = projectile.velocity.X * 0.99f;
					}
					if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01)
					{
						projectile.velocity.X = 0f;
						projectile.netUpdate = true;
					}
				}
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			}
			// Rotation increased by velocity.X 
			projectile.rotation += projectile.velocity.X * 0.1f;
			return;
		}


		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 14);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ProjectileID.SporeCloud, projectile.damage /= 2, projectile.knockBack, projectile.owner);
			for (int i = 0; i < 5; i++)
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.JungleSpore);
				Main.dust[d].scale = .5f;
			}
		}
	}
}