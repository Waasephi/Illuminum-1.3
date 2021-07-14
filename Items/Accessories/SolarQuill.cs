using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Accessories
{
	public class SolarQuill : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Quill");
			Tooltip.SetDefault("Gives +15% Damage during the day." +
                "\nA quill from ancient times... Who would write with a rock?");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			if (Main.dayTime)
			{
				player.allDamage *= 1.15f;
			}
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = Item.buyPrice(gold: 50);
			item.rare = ItemRarityID.LightPurple;
			item.accessory = true;
			item.expert = false;
		}
	}
}