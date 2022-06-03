using Illuminum.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class VoidFin : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Void Fin"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			item.width = 44;
			item.height = 38;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Blue;
			item.maxStack = 999;
		}
	}
}