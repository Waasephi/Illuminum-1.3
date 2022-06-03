using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class ChaliceoftheMoon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chalice of the Moon");
			Tooltip.SetDefault("Releases Lunar Flares on taking damage," +
                "\nIncreases all damage by 20%." +
                "\nA Chalice with seemingly unending depth.");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 44;
			item.value = Item.buyPrice(platinum: 5);
			item.rare = ItemRarityID.Cyan;
			item.accessory = true;
			item.expert = false;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.allDamage *= 1.2f;
			player.GetModPlayer<IlluminumPlayer>().lunarWrath = true;
		}
	}
}