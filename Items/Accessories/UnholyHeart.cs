using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Illuminum.Items.Materials;

namespace Illuminum.Items.Accessories
{
	public class UnholyHeart : ModItem //replace ItemName with the name of your accessory
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unholy Heart");
			Tooltip.SetDefault("Although it looks like a crystal, it beats like a heart... gross..." +
                "\n+5% Damage.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 8));
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			player.allDamage *= 1.05f;
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 22;
			item.value = Item.buyPrice(gold: 10);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.expert = false;
		}
	}
}