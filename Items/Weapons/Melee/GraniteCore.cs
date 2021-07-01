using Illuminum.Items.Materials;
using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum.Items.Weapons.Melee
{
	public class GraniteCore : ModItem
	{
		public override void SetStaticDefaults()
		{
			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
			DisplayName.SetDefault("Granite Core");
			Tooltip.SetDefault("Shoots an electric laser at nearby enemies.");
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 34;
			item.height = 32;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 13f;
			item.knockBack = 2.5f;
			item.damage = 13;
			item.rare = ItemRarityID.Blue;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 1);
			item.shoot = ModContent.ProjectileType<GraniteCoreProjectile>();
		}
	}
}