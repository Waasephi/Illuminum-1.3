using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Illuminum.Tiles.Voidlands;


namespace Illuminum
{
	public class IlluminumPlayer : ModPlayer
	{
		public bool Drained;
		public bool frigidWarlite;
		public bool voidSpirit;
		public bool frostDefense;
		public bool megaDragon;
		public bool ZoneVoidlands;
		public bool darkCorruptor;
		public bool hematiteSticker;
		public bool ebonriseSpirit;
		public bool miniBetsy;
		public bool glacialSpirit;
		public bool boneZone;
		public bool electroShield;
		public bool lunarWrath;
		public bool createVoidlands;

		public override void ResetEffects()
		{
			Drained = false;
			frigidWarlite = false;
			frostDefense = false;
			megaDragon = false;
			voidSpirit = false;
			darkCorruptor = false;
			hematiteSticker = false;
			ebonriseSpirit = false;
			miniBetsy = false;
			glacialSpirit = false;
			boneZone = false;
			electroShield = false;
			lunarWrath = false;
		}

		public override void UpdateBiomes()
		{
			ZoneVoidlands = IlluminumWorld.Voidlands > 100;
		}

		public override void SendCustomBiomes(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = ZoneVoidlands;
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			ZoneVoidlands = flags[0];
		}

		public override void CopyCustomBiomesTo(Player other)
		{
			IlluminumPlayer modOther = other.GetModPlayer<IlluminumPlayer>();
			modOther.ZoneVoidlands = ZoneVoidlands;
		}

		public override void PreUpdate()
		{
			if (createVoidlands && Main.mapFullscreen && Main.mouseRight)
			{
				int mapWidth = Main.maxTilesX * 16;
				int mapHeight = Main.maxTilesY * 16;
				Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

				cursorPosition.X -= Main.screenWidth / 2;
				cursorPosition.Y -= Main.screenHeight / 2;

				Vector2 mapPosition = Main.mapFullscreenPos;
				Vector2 cursorWorldPosition = mapPosition;

				cursorPosition /= 16;
				cursorPosition *= 16 / Main.mapFullscreenScale;
				cursorWorldPosition += cursorPosition;
				cursorWorldPosition *= 16;

				if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
				if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
				createVoidlands = false;
				//Worldgen code.
				if (cursorWorldPosition.Y > Main.rockLayer)
				{
					IlluminumWorld.VoidlandsSpawned = true;
					Main.NewText("The caverns have been absorbed into void.", 75, 75, 75);
					WorldGen.TileRunner((int)cursorWorldPosition.X, (int)cursorWorldPosition.Y, 275, 100, ModContent.TileType<VoidStoneTile>());
					Main.mapFullscreen = false;
					createVoidlands = false;
				}
			}
		}
	

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (frostDefense)
			{
				float xVel = Main.rand.NextFloat(-5f, 5f);
				float yVel = Main.rand.NextFloat(-2f, 2f);
				for (int i = 0; i < 3; i++)
				{
					int p = Projectile.NewProjectile(player.position, new Vector2(xVel, yVel), ProjectileID.BallofFrost, 13, 0.5f, player.whoAmI);
					//Tweak values as you'd like.
					Main.projectile[p].timeLeft = 60;
				}
			}
			if (boneZone)
			{
				float xVel = Main.rand.NextFloat(-5f, 5f);
				float yVel = Main.rand.NextFloat(-2f, 2f);
				for (int i = 0; i < 5; i++)
				{
					int p = Projectile.NewProjectile(player.position, new Vector2(xVel, yVel), 532, 35, 0.5f, player.whoAmI);
					//Tweak values as you'd like.
					Main.projectile[p].timeLeft = 300;
				}
			}
			if (electroShield)
			{
				float xVel = Main.rand.NextFloat(-5f, 5f);
				float yVel = Main.rand.NextFloat(-2f, 2f);
				for (int i = 0; i < 5; i++)
				{
					int p = Projectile.NewProjectile(player.position, new Vector2(xVel, yVel), 443, 60, 0.5f, player.whoAmI);
					//Tweak values as you'd like.
					Main.projectile[p].timeLeft = 30;
				}
			}
			if (lunarWrath)
			{
				float xVel = Main.rand.NextFloat(-10f, 10f);
				float yVel = Main.rand.NextFloat(-5f, 5f);
				for (int i = 0; i < 3; i++)
				{
					int p = Projectile.NewProjectile(player.position, new Vector2(xVel, yVel), 645, 80, 0.5f, player.whoAmI);
					//Tweak values as you'd like.
					Main.projectile[p].timeLeft = 200;
				}
			}
		}
	}
}