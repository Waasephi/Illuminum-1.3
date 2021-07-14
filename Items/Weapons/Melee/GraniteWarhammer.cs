using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Illuminum.Items.Weapons.Melee
{
	public class GraniteWarhammer : ModItem
	{
		public override void SetStaticDefaults() 
		{
			 DisplayName.SetDefault("Granite Warhammer"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Electrifies enemies on hit.");
		}

		public override void SetDefaults() 
		{
			item.damage = 25;
			item.melee = true;
			item.width = 58;
			item.height = 60;
			item.useTime = 56;
			item.useAnimation = 56;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 10;
			item.value = Item.sellPrice(silver: 54);
			item.rare = ItemRarityID.Green;
			item.scale = 1.4f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(7))
			{
				//Emit dusts when the sword is swung
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			// Add the Onfire buff to the NPC for 1 second when the weapon hits an NPC
			// 60 frames = 1 second
			target.AddBuff(BuffID.Electrified, 180);
		}
	}
}