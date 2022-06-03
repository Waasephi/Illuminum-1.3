﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class AbyssalMaw : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyssal Maw");
			Tooltip.SetDefault("Grants Immunity to knockback and most debuffs" +
                "\n+5% Damage Reduction" +
                "\nAllows the player to dash into the enemy" +
                "\nDouble tap a direction" +
                "\n[c/4f4f4f:Embrace the Void.]");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.noKnockback = true;
			player.endurance += 0.05f;
			player.dash = 2;
			player.lavaImmune = true;
			player.buffImmune[BuffID.Cursed] = true;
			player.buffImmune[BuffID.Weak] = true;
			player.buffImmune[BuffID.Slow] = true;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.BrokenArmor] = true;
			player.buffImmune[BuffID.Silenced] = true;
			player.buffImmune[BuffID.Poisoned] = true;
			player.buffImmune[BuffID.Chilled] = true;
			player.buffImmune[BuffID.Darkness] = true;
			player.buffImmune[BuffID.Bleeding] = true;
			player.buffImmune[BuffID.Frozen] = true;
			player.buffImmune[BuffID.Blackout] = true;
			player.buffImmune[BuffID.Stoned] = true;
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 32;
			item.value = Item.sellPrice(gold: 40);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.expert = true;
			item.defense = 6;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod,"ViciousMaw");
			recipe.AddIngredient(ItemID.AnkhShield);
			recipe.AddIngredient(ItemID.PocketMirror);
			recipe.AddIngredient(mod, "BlackenedCrystal");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}