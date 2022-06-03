using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Illuminum.Tiles.Voidlands;
using Illuminum.Items.Weapons.Ranged;
using Illuminum.Items.Materials;


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
		public bool hematiteReaver;
		public bool ebonriseSpirit;
		public bool miniDragon;
		public bool glacialSpirit;
		public bool overgrowthBiter;
		public bool boneZone;
		public bool electroShield;
		public bool lunarWrath;
		public bool createVoidlands;
		public bool venomGauntlet;
		public bool poisonGlove;
		public bool frozenQuiver;
		public bool frostStone;
		public bool darkSteelSet;
		public bool dragonSet;

		public override void ResetEffects()
		{
			Drained = false;
			frigidWarlite = false;
			frostDefense = false;
			megaDragon = false;
			voidSpirit = false;
			darkCorruptor = false;
			hematiteReaver = false;
			ebonriseSpirit = false;
			miniDragon = false;
			glacialSpirit = false;
			overgrowthBiter = false;
			boneZone = false;
			electroShield = false;
			lunarWrath = false;
			venomGauntlet = false;
			poisonGlove = false;
			frozenQuiver = false;
			frostStone = false;
			darkSteelSet = false;
			dragonSet = false;
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
				if (cursorWorldPosition.X / 16 > Main.maxTilesX) cursorWorldPosition.X = Main.maxTilesX;
				if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
				if (cursorWorldPosition.Y / 16 > Main.maxTilesY) cursorWorldPosition.Y = Main.maxTilesY;
				createVoidlands = false;
				//Worldgen code.
				if (cursorWorldPosition.Y > Main.rockLayer)
				{

					Main.mapFullscreen = false;
					createVoidlands = false;
					IlluminumWorld.VoidlandsSpawned = true;
					Main.NewText("The caverns have been absorbed into void.", 75, 75, 75);
					WorldGen.TileRunner((int)cursorWorldPosition.X / 16, (int)cursorWorldPosition.Y / 16, 350, 125, ModContent.TileType<VoidStoneTile>());
					int x = (int)cursorWorldPosition.X; //unused, but whatever
					int y = (int)cursorWorldPosition.Y; //unused, but whatever
														//Main.NewText(cursorWorldPosition); //Debug teleport
														//player.Teleport(cursorWorldPosition); //Debug teleport
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
			if (dragonSet)
			{
				{
					Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 69);
					int p = Projectile.NewProjectile(player.position, new Vector2(0, 0), ProjectileID.DD2ExplosiveTrapT3Explosion, 150, 0.5f, player.whoAmI);
				}
			}
			if (boneZone)
			{
				float xVel = Main.rand.NextFloat(-5f, 5f);
				float yVel = Main.rand.NextFloat(-2f, 2f);
				for (int i = 0; i < 5; i++)
				{
					int p = Projectile.NewProjectile(player.position, new Vector2(xVel, yVel), ProjectileID.BoneGloveProj, 35, 0.5f, player.whoAmI);
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
					int p = Projectile.NewProjectile(player.position, new Vector2(xVel, yVel), ProjectileID.Electrosphere, 60, 0.5f, player.whoAmI);
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
					int p = Projectile.NewProjectile(player.position, new Vector2(xVel, yVel), ProjectileID.LunarFlare, 80, 0.5f, player.whoAmI);
					//Tweak values as you'd like.
					Main.projectile[p].timeLeft = 200;
				}
			}
		}

		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
		{
			if (junk)
			{
				return;
			}
			if (player.ZoneBeach && liquidType == 0 && Main.rand.NextBool(20))
			{
				caughtType = ModContent.ItemType<GunFish>();
			}
			if (player.GetModPlayer<IlluminumPlayer>().ZoneVoidlands && liquidType == 0 && Main.rand.NextBool(5))
			{
				caughtType = ModContent.ItemType<VoidFin>();
			}

		}

		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) //am lazy, vs will autofill.
		{
			if (item.melee && venomGauntlet)
			{
				target.AddBuff(BuffID.Venom, 3 * 60);
			}
			if (item.melee && poisonGlove)
			{
				target.AddBuff(BuffID.Poisoned, 3 * 60);
			}
			if (item.melee && dragonSet)
			{
				target.AddBuff(BuffID.BetsysCurse, 3 * 60);
			}
			if (frostStone)
			{
				target.AddBuff(BuffID.Frostburn, 1 * 60);
			}
			if (darkSteelSet)
			{
				target.AddBuff(BuffID.CursedInferno, 1 * 60);
			}
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (proj.melee && venomGauntlet)
			{
				target.AddBuff(BuffID.Venom, 3 * 60);
			}
			if (proj.melee && poisonGlove)
			{
				target.AddBuff(BuffID.Poisoned, 3 * 60);
			}
			if (proj.melee && dragonSet)
			{
				target.AddBuff(BuffID.BetsysCurse, 3 * 60);
			}
			if (proj.ranged && frozenQuiver)
			{
				target.AddBuff(BuffID.Frostburn, 3 * 60);
			}
			if (frostStone)
			{
				target.AddBuff(BuffID.Frostburn, 1 * 60);
			}
			if (darkSteelSet)
			{
				target.AddBuff(BuffID.CursedInferno, 1 * 60);
			}
		}
	}
}