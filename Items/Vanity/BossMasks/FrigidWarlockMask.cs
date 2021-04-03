using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Vanity.BossMasks
{
	[AutoloadEquip(EquipType.Head)]
	public class FrigidWarlockMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Frigid Warlock Mask");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 28;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}
	}
}