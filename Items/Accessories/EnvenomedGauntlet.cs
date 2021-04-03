using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	[AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
	public class EnvenomedGauntlet : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Envenomed Gauntlet");
			Tooltip.SetDefault("Don't touch it. " +
                "\n+20% Melee Speed" +
                "\n+10% Melee Damage" +
                "\nIncreased Knockback" +
                "\nThorns and Flask of Venom effects.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeSpeed += 0.2f;
			player.kbGlove = true;
			player.meleeDamage += 0.1f;
			player.AddBuff(BuffID.Thorns, 2);
			player.AddBuff(71, 2); //Flask of Venom
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = ItemRarityID.Purple;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitanGlove);
			recipe.AddIngredient(mod, "BrambleGlove");
			recipe.AddIngredient(ItemID.VialofVenom, 10);
			recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}