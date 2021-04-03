using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Illuminum.Items.Banners
{
    public class VoidWraithBanner : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 28;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("Banners");
            item.placeStyle = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Wraith Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Void Wraith");
        }
    }
}