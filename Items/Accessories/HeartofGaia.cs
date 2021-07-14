using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class HeartofGaia : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of Gaia");
			Tooltip.SetDefault("The Heart of the god of the Earth." +
                "\nGreatly boosts your Health and Regeneration.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.statLifeMax2 += 80;
			player.lifeRegen += 3;
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 32;
			item.value = Item.buyPrice(gold: 35);
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
			item.expert = false;
		}
	}
}