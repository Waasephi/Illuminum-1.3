using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class AdventurersLocket : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adventurer's Locket");
			Tooltip.SetDefault("Filled with hopes and dreams." +
                "\n+5% Movement Speed.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.moveSpeed *= 1.05f;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 22;
			item.value = Item.buyPrice(gold: 1, silver: 50);
			item.rare = 1;
			item.accessory = true;
			item.expert = false;
		}
	}
}