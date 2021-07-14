using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Illuminum.Items.Materials;
using Illuminum.Items.Accessories;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.NPCs.Passive
{
	[AutoloadHead]
	public class Explorer : ModNPC
	{
		public override bool Autoload(ref string name)
		{
			name = "Explorer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Merchant;
		}

		/*public override bool CanTownNPCSpawn(int numTownNPCs, int money) //Whether or not the conditions have been met for this town NPC to be able to move into town.
		{
			if (NPC.downedBoss1)  //so after the EoC is killed
			{
				return true;
			}
			return false;
		} */

		public override bool CheckConditions(int left, int right, int top, int bottom)    //Allows you to define special conditions required for this town NPC's house
		{
			return true;  //so when a house is available the npc will  spawn
		}

		public override string TownNPCName()     //Allows you to give this town NPC any name when it spawns
		{
			switch (WorldGen.genRand.Next(6))
			{
				case 0:
					return "Christopher";

				case 1:
					return "Marco";

				case 2:
					return "Leif";

				case 3:
					return "Clark";

				case 4:
					return "Lewis";

				case 5:
					return "Alexander";

				default:
					return "Erik";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)  //Allows you to set the text for the buttons that appear on this town NPC's chat window.
		{
			button = "Shop";   //this defines the buy button name
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool openShop) //Allows you to make something happen whenever a button is clicked on this town NPC's chat window. The firstButton parameter tells whether the first button or second button (button and button2 from SetChatButtons) was clicked. Set the shop parameter to true to open this NPC's shop.
		{
			if (firstButton)
			{
				openShop = true;   //so when you click on buy button opens the shop
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)       //Allows you to add items to this town NPC's shop. Add an item by setting the defaults of shop.item[nextSlot] then incrementing nextSlot.
		{
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<AdventurersLocket>());  //this is an example of how to add a modded item
			nextSlot++;
			if (NPC.downedSlimeKing)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<CrystalTear>());
				nextSlot++;
			}
			if (NPC.downedBoss1)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<BloodyLens>());
				nextSlot++;
			}
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<UnholyHeart>());
				nextSlot++;
			}
			if (IlluminumWorld.downedFrigidConstruct)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<RoyalBlanket>());
				nextSlot++;
			}
			if (NPC.downedQueenBee)
			{
				shop.item[nextSlot].SetDefaults(1132); //Honeycomb
				nextSlot++;
			}
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<SkullNecklace>());
				nextSlot++;
			}
			if (Main.hardMode)   //this make so when Moon Lord is killed the town npc will sell this
			{
				shop.item[nextSlot].SetDefaults(490);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(491);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(489);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(2998);
				nextSlot++;
			}
			if (NPC.downedMechBoss1)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<SteelPetal1>());
				nextSlot++;
			}
			if (NPC.downedMechBoss2)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<SteelPetal2>());
				nextSlot++;
			}
			if (NPC.downedMechBoss3)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<SteelPetal3>());
				nextSlot++;
			}
			if (NPC.downedPlantBoss)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<HeartofGaia>());
				nextSlot++;
			}
			if (NPC.downedGolemBoss)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<SolarQuill>());
				nextSlot++;
			}
			if (NPC.downedFishron)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ClippedFin>());
				nextSlot++;
			}
			if (NPC.downedMartians)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ElectroDrive>());
				nextSlot++;
			}
			if (NPC.downedAncientCultist)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<CrackedBeak>());
				nextSlot++;
			}
			if (NPC.downedTowerSolar)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<SolarCore>());
				nextSlot++;
			}
			if (NPC.downedTowerStardust)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<StardustCore>());
				nextSlot++;
			}
			if (NPC.downedTowerVortex)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<VortexCore>());
				nextSlot++;
			}
			if (NPC.downedTowerNebula)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<NebulaCore>());
				nextSlot++;
			}
			if (NPC.downedMoonlord)   //this make so when Moon Lord is killed the town npc will sell this
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ChaliceoftheMoon>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(3456);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(3457);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(3458);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(3459);
				nextSlot++;
			}
		}

		public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
		{
			int guideNPC = NPC.FindFirstNPC(NPCID.Guide); //this make so when this npc is close to the Guide
			if (guideNPC >= 0 && Main.rand.Next(4) == 0) //has 1 in 3 chance to show this message
			{
				return "That " + Main.npc[guideNPC].GivenName + " over there... He knows a bit too much about this world. Something is up with him. Keep an eye out okay?";
			}
			switch (Main.rand.Next(6))    //this are the messages when you talk to the npc
			{
				case 0:
					return "You wanna buy something? These days I usually just stay around here so I dont have much use for any of it... Yes you still have to pay!";

				case 1:
					return "You want to know how I got this stuff? That's for me to know, and for you to never find out!";

				case 2:
					return "Come around every so often. You never know when I'll find something new.";

				case 3:
					return "I've travelled all around this land and obtained many an item... Want to take a look?";

				case 4:
					return "Hey, thanks for the home and stuff... What? No I'm not going to give you a discount...";

				case 5:
					return "Y'know I used to live in a far away land. Filled with glowing rock and destroyed cities. I wonder how its doing...";

				default:
					return "I don't know why i have all this random stuff... but its fun to collect them none the less!";
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.PoisonedKnife;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}