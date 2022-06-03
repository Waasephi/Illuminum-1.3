using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class ElectroDrive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Electro Drive");
			Tooltip.SetDefault("Releases Electrosphere Blasts on taking damage." +
                "\nShockingly Advanced!");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 30;
			item.value = Item.buyPrice(gold: 80);
			item.value = Item.sellPrice(gold: 30);
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
			item.expert = false;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<IlluminumPlayer>().electroShield = true;
		}
	}
}