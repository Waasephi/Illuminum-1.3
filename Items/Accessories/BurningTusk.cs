using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories
{
	public class BurningTusk : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Tusk");
			Tooltip.SetDefault("+50 Armor Penetration." +
                "\nIts still warm.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.armorPenetration += 50;
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 28;
			item.value = Item.buyPrice(gold: 80);
			item.rare = 6;
			item.accessory = true;
			item.expert = false;
		}
	}
}