using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	[AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
	public class EnvenomedGauntlet : ModItem
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
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			player.meleeSpeed += 0.2f;
			player.kbGlove = true;
			player.meleeDamage += 0.1f;
			player.AddBuff(BuffID.Thorns, 2);
			modPlayer.venomGauntlet = true; //Allows the player to disable extra dust spawns. May improve preformance, and allows more dust spam
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(gold: 20);
			item.rare = ItemRarityID.Purple;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitanGlove);
			recipe.AddIngredient(ModContent.ItemType<BrambleGlove>(), 1); //ModContent.ItemType<>();
			recipe.AddIngredient(ItemID.VialofVenom, 10);
			recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}