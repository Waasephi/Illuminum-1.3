using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class SteelPetal1 : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Steel Petal"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A sharp chunk of steel. It has a slight shock feeling...");
		}

		public override void SetDefaults() 
		{
			item.width = 16;
			item.height = 16;
			item.value = Item.buyPrice(gold: 25);
			item.rare = 4;
			item.maxStack = 1;
		}
	}
}