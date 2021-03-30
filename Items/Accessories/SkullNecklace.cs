using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class SkullNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skull Necklace");
			Tooltip.SetDefault("Shoots Bones on taking damage." +
                "\nEnter the Bone Zone!");
		}
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 28;
			item.value = Item.buyPrice(gold: 20);
			item.rare = 3;
			item.accessory = true;
			item.expert = false;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<IlluminumPlayer>().boneZone = true;
		}
	}
}