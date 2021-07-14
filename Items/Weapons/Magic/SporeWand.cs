using Illuminum.Projectiles;
using Illuminum.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Magic
{
	public class SporeWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore Wand");
			Tooltip.SetDefault("Spawns spores at the cursor that go towards the player");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 23;
			item.magic = true;
			item.mana = 25;
			item.width = 44;
			item.height = 44;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.shoot = ProjectileID.SporeGas2;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item43;
			item.shootSpeed = -20f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position = Main.MouseWorld;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "VialofEvil", 8);
			recipe.AddIngredient(ItemID.JungleSpores, 7);
			recipe.AddIngredient(ItemID.MudBlock, 75);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}