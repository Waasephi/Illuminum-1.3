using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	public class FrigidCloak : ModItem
	{
		public override string Texture => "Terraria/Item_" + ItemID.StarCloak; //Lazy texture placeholder.
		public override void SetStaticDefaults()
		{
			//tooltip and name if any.
		}
		public override void SetDefaults()
		{
			item.rare = 3; //placeholder value
			item.width = 18;
			item.height = 24;
			item.accessory = true;
			//Other values. Too lazy to do this manually to be honest.
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<IlluminumPlayer>().frostDefense = true;
		}
	}
}