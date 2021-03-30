using Illuminum.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Materials
{
	public class AbyssalFlesh : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Abyssal Flesh"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		}

		public override void SetDefaults() 
		{
			item.width = 16;
			item.height = 16;
			item.value = 100;
			item.rare = 5;
			item.maxStack = 999;
		}
	}
}