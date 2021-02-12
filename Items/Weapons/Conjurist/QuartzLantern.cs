/*using Illuminum.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using Illuminum.Items.Materials;

namespace Illuminum.Items.Weapons.Conjurist
{
	public class QuartzLantern : ConjuristItem
	{
		// This is a staff that uses the example damage class stuff you've set up before, but uses exampleResource instead of mana.
		// This is a very simple way of doing it, and if you plan on multiple items using exampleResource then I'd suggest making a new abstract ModItem class that inherits ExampleDamageItem,
		// and doing the CanUseItem and UseItem in a more generalized way there, so you can just define the resource usage in SetDefaults and it'll do it automatically for you.
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Lantern");
			Tooltip.SetDefault("Spawns a Flame Spirit at the cursor, Maximum of 1 Spirit can be out at a time." +
                "\nDrains you for 8 seconds");
		}

		public override void SafeSetDefaults()
		{
			item.useTime = 25;
			item.useAnimation = 25;
			item.Size = new Vector2(28, 36);
			item.damage = 8;
			item.width = 16;
			item.height = 30;
			item.knockBack = 3;
			item.noMelee = true;
			item.value = Item.sellPrice(silver: 15);
			item.rare = ItemRarityID.Blue;
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.shoot = ProjectileType<QuartzSpirit>();
			item.UseSound = SoundID.Item30;
			item.buffType = BuffType<Buffs.Debuffs.Drained>();
		}
		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 480, true);
			}
		}
		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position = Main.MouseWorld;
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ItemID.Gel, 15);
			recipe.AddIngredient(ModContent.ItemType<QuartzIngot>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}*/