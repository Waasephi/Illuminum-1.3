using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Memes
{
	public class GoldenFryingPan : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Golden Frying Pan"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Ahh, piss.");
		}

		public override void SetDefaults() 
		{
			item.damage = 65;
			item.melee = true;
			item.width = 250;
			item.height = 145;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.crit = 100;
			item.value = Item.sellPrice(silver: 78);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.expert = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			Main.PlaySound(SoundID.Item, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/GoldenFryingPanHit"));
		}
	}
}