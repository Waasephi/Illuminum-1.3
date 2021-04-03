﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories
{
	public class CrackedBeak : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cracked Beak");
			Tooltip.SetDefault("+2 Minion Slots." +
                "\nHas a faint magic energy.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.moveSpeed *= 1.5f;
			player.maxRunSpeed += 2.5f;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 16;
			item.value = Item.buyPrice(gold: 75);
			item.rare = 7;
			item.accessory = true;
			item.expert = false;
		}
	}
}