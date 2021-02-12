using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Conjurist
{
	// This class stores necessary player info for our custom damage class, such as damage multipliers, additions to knockback and crit, and our custom resource that governs the usage of the weapons of this damage class.
	public class ConjuristPlayer : ModPlayer
	{
		public static ConjuristPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<ConjuristPlayer>();
		}

		// Vanilla only really has damage multipliers in code
		// And crit and knockback is usually just added to
		// As a modder, you could make separate variables for multipliers and simple addition bonuses
		public float conjuristDamageAdd;
		public float conjuristDamageMult = 1f;
		public float conjuristKnockback;
		public int conjuristCrit;

		// Here we include a custom resource, similar to mana or health.
		// Creating some variables to define the current value of our example resource as well as the current maximum value. We also include a temporary max value, as well as some variables to handle the natural regeneration of this resource.
		public int soulResourceCurrent;
		public const int DefaultSoulResourceMax = 100;
		public int soulResourceMax;
		public int soulResourceMax2;
		public float soulResourceRegenRate;
		internal int soulResourceRegenTimer = 2;
		public static readonly Color HealSoulResource = new Color(17, 125, 103); // We can use this for CombatText, if you create an item that replenishes exampleResourceCurrent.

		/*
		In order to make the Example Resource example straightforward, several things have been left out that would be needed for a fully functional resource similar to mana and health. 
		Here are additional things you might need to implement if you intend to make a custom resource:
		- Multiplayer Syncing: The current example doesn't require MP code, but pretty much any additional functionality will require this. ModPlayer.SendClientChanges and clientClone will be necessary, as well as SyncPlayer if you allow the user to increase exampleResourceMax.
		- Save/Load and increased max resource: You'll need to implement Save/Load to remember increases to your exampleResourceMax cap.
		- Resouce replenishment item: Use GlobalNPC.NPCLoot to drop the item. ModItem.OnPickup and ModItem.ItemSpace will allow it to behave like Mana Star or Heart. Use code similar to Player.HealEffect to spawn (and sync) a colored number suitable to your resource.
		*/

		public override void Initialize()
		{
			soulResourceMax = DefaultSoulResourceMax;
		}

		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		private void ResetVariables()
		{
			conjuristDamageAdd = 0f;
			conjuristDamageMult = 1f;
			conjuristKnockback = 0f;
			conjuristCrit = 5;
			soulResourceRegenRate = 1f;
			soulResourceMax2 = soulResourceMax;
		}

		public override void PostUpdateMiscEffects()
		{
			UpdateResource();
		}

		// Lets do all our logic for the custom resource here, such as limiting it, increasing it and so on.
		private void UpdateResource()
		{
			// For our resource lets make it regen slowly over time to keep it simple, let's use exampleResourceRegenTimer to count up to whatever value we want, then increase currentResource.
			soulResourceRegenTimer++; //Increase it by 60 per second, or 1 per tick.

			// A simple timer that goes up to 3 seconds, increases the exampleResourceCurrent by 1 and then resets back to 0.
			if (soulResourceRegenTimer > 180 * soulResourceRegenRate)
			{
				soulResourceCurrent += 1;
				soulResourceRegenTimer = 0;
			}

			// Limit exampleResourceCurrent from going over the limit imposed by exampleResourceMax.
			soulResourceCurrent = Utils.Clamp(soulResourceCurrent, 0, soulResourceMax2);
		}
	}
}