using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Illuminum.Items.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class FrozenQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Quiver");
			Tooltip.SetDefault("Cold to the touch. " +
                "\nGives Frostburn To Ranged Weapons" +
                "\n+20% Ranged Damage" +
                "\n20% Chance to not consume ammo,");
		}

		public override void UpdateAccessory(Player player, bool hideVisual) //Where it says "p" is the variable used to represent "player". In this case, every p stands for player. This is called when the accessory is on.
		{
			IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
			modPlayer.frozenQuiver = true;
			player.rangedDamage *= 1.2f;
			player.ammoCost80 = true;
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MagicQuiver);
			recipe.AddIngredient(ItemID.RangerEmblem);
			recipe.AddIngredient(mod, "FrostStone");
			recipe.AddIngredient(mod, "MysticArrow");
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}