using Illuminum.Items.Vanity.BossMasks;
using Illuminum.Items.Weapons.Melee;
using Illuminum.Items.Weapons.Magic;
using Illuminum.Items.Weapons.Ranged;
using Illuminum.Items.Weapons.Summoner;
using Illuminum.Items.Accessories;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Consumables
{
	public class FrigidWarlockTreasureBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Cyan;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.QuickSpawnItem(ModContent.ItemType<FrigidCloak>());
			if (Main.rand.NextBool(7))
			{
				player.QuickSpawnItem(ModContent.ItemType<FrigidWarlockMask>());
			}
			int loots = Main.rand.Next(4);
			switch (loots)
			{
				case 0:
					player.QuickSpawnItem(ModContent.ItemType<FrigidFlayer>(), Main.rand.Next(1, 1));
					break;

				case 1:
					player.QuickSpawnItem(ModContent.ItemType<FrigidStaff>(), Main.rand.Next(1, 1));
					break;

				case 2:
					player.QuickSpawnItem(ModContent.ItemType<FrigidWand>(), Main.rand.Next(1, 1));
					break;

				case 3:
					player.QuickSpawnItem(ModContent.ItemType<FrigidSniper>(), Main.rand.Next(1, 1));
					break;
			}
		}

		public override int BossBagNPC => ModContent.NPCType<NPCs.Bosses.FrigidWarlock.FrigidWarlock>();
	}
}