using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class RoyalBlanket : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Blanket");
			Tooltip.SetDefault("Its so cozy..." +
                "\n+20 Life, Immunity to cold.");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.statLifeMax2 += 20;
			player.buffImmune[BuffID.Chilled] = true;
			player.buffImmune[BuffID.Frozen] = true;
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 26;
			item.value = Item.buyPrice(gold: 15);
			item.rare = 2;
			item.accessory = true;
			item.expert = false;
		}
	}
}