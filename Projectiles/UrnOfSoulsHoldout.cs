using Illuminum.Items.Weapons.Ranged;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Projectiles
{
	public class UrnOfSoulsHoldout : ModProjectile
	{

		// The vanilla Last Prism is an animated item with 5 frames of animation. We copy that here.
		private const int NumAnimationFrames = 1;

		// This value controls how sluggish the Prism turns while being used. Vanilla Last Prism is 0.08f.
		// Higher values make the Prism turn faster.
		private const float AimResponsiveness = 0.15f;

		public const int NumBeams = 5;

		private const int SoundInterval = 20;

		// This property encloses the internal AI variable projectile.ai[0]. It makes the code easier to read.
		private float FrameCounter
		{
			get => projectile.ai[0];
			set => projectile.ai[0] = value;
		}

		// This property encloses the internal AI variable projectile.localAI[0].
		// localAI is not automatically synced over the network, but that does not cause any problems in this case.

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Urn of Souls");
			Main.projFrames[projectile.type] = NumAnimationFrames;

			// Signals to Terraria that this projectile requires a unique identifier beyond its index in the projectile array.
			// This prevents the issue with the vanilla Last Prism where the beams are invisible in multiplayer.
			ProjectileID.Sets.NeedsUUID[projectile.type] = true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			Vector2 rrp = player.RotatedRelativePoint(player.MountedCenter, true);

			// Update the Prism's position in the world and relevant variables of the player holding it.
			UpdatePlayerVisuals(player, rrp);

			// Update the Prism's behavior: project beams on frame 1, consume mana, and despawn if out of mana.
			if (projectile.owner == Main.myPlayer)
			{
				// Slightly re-aim the Prism every frame so that it gradually sweeps to point towards the mouse.
				UpdateAim(rrp, player.HeldItem.shootSpeed);
			}

			// The Prism immediately stops functioning if the player is Cursed (player.noItems) or "Crowd Controlled", e.g. the Frozen debuff.
			// player.channel indicates whether the player is still holding down the mouse button to use the item.
			bool stillInUse = player.channel && !player.noItems && !player.CCed;

			projectile.tileCollide = false;

			projectile.ai[0]++;
			projectile.ranged = true;

			if (projectile.ai[0] > 20f && stillInUse)
            {
				Main.PlaySound(SoundID.Item103, projectile.position);
				projectile.ai[0] = 0;
				Projectile.NewProjectile(projectile.Center, Vector2.UnitX.RotatedBy(projectile.rotation + -MathHelper.PiOver2) * 6f, ProjectileID.LostSoulFriendly, projectile.damage, projectile.knockBack, projectile.owner);					
            }


			if (player.channel == false)
            {
				projectile.Kill();
            }

			// This ensures that the Prism never times out while in use.
			projectile.timeLeft = 2;
		}

		private void FireBeams()
		{
			// If for some reason the beam velocity can't be correctly normalized, set it to a default value.
			Vector2 beamVelocity = Vector2.Normalize(projectile.velocity);
			if (beamVelocity.HasNaNs())
			{
				beamVelocity = -Vector2.UnitY;
			}

			// This UUID will be the same between all players in multiplayer, ensuring that the beams are properly anchored on the Prism on everyone's screen.
			int uuid = Projectile.GetByUUID(projectile.owner, projectile.whoAmI);

			int damage = projectile.damage;
			float knockback = projectile.knockBack;
			for (int b = 0; b < NumBeams; ++b)
			{
				Projectile.NewProjectile(projectile.Center, beamVelocity, ProjectileID.LostSoulFriendly, damage, knockback, projectile.owner, b, uuid);
			}

			// After creating the beams, mark the Prism as having an important network event. This will make Terraria sync its data to other players ASAP.
			projectile.netUpdate = true;
		}

		private void UpdatePlayerVisuals(Player player, Vector2 playerHandPos)
		{
			// Place the Prism directly into the player's hand at all times.
			projectile.Center = playerHandPos;
			// The beams emit from the tip of the Prism, not the side. As such, rotate the sprite by pi/2 (90 degrees).
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			projectile.spriteDirection = projectile.direction;

			// The Prism is a holdout projectile, so change the player's variables to reflect that.
			// Constantly resetting player.itemTime and player.itemAnimation prevents the player from switching items or doing anything else.
			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;

			// If you do not multiply by projectile.direction, the player's hand will point the wrong direction while facing left.
			player.itemRotation = (projectile.velocity * projectile.direction).ToRotation();
		}

		private void UpdateAim(Vector2 source, float speed)
		{
			// Get the player's current aiming direction as a normalized vector.
			Vector2 aim = Vector2.Normalize(Main.MouseWorld - source);
			if (aim.HasNaNs())
			{
				aim = -Vector2.UnitY;
			}

			// Change a portion of the Prism's current velocity so that it points to the mouse. This gives smooth movement over time.
			aim = Vector2.Normalize(Vector2.Lerp(Vector2.Normalize(projectile.velocity), aim, AimResponsiveness));
			aim *= speed;

			if (aim != projectile.velocity)
			{
				projectile.netUpdate = true;
			}
			projectile.velocity = aim;
		}

		// Because the Prism is a holdout projectile and stays glued to its user, it needs custom drawcode.
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects effects = projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameHeight = texture.Height / Main.projFrames[projectile.type];
			int spriteSheetOffset = frameHeight * projectile.frame;
			Vector2 sheetInsertPosition = (projectile.Center + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();

			spriteBatch.Draw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), lightColor, projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), projectile.scale, effects, 0f);
			return false;
		}
	}
}