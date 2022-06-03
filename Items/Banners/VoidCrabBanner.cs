using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Banners
{
    public class VoidCrabBanner : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 48;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("Banners");
            item.placeStyle = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Crab Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Void Crab");
        }
    }
}