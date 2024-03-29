﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class FrigidCloak : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frigid Cloak");
			Tooltip.SetDefault("Shoots Ice Balls on taking damage.");
		}
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 28;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Blue;
			item.accessory = true;
			item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<IlluminumPlayer>().frostDefense = true;
		}
	}
}