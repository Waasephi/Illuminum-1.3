using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Items.Materials;

namespace Illuminum.Items.Accessories
{
	public class BloodyLens : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloody Lens");
			Tooltip.SetDefault("It reflects light quite well, It is pretty foggy..." +
                "\n+2% Crit Chance.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.meleeCrit += 2;
			player.magicCrit += 2;
			player.rangedCrit += 2;
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 22;
			item.value = Item.buyPrice(gold: 5);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.expert = false;
		}
	}
}