using Terraria;
using Illuminum.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Illuminum.Projectiles;

namespace Illuminum.Items.Weapons.Melee
{
    public class VineWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vine Whip");
        }

        public override void SetDefaults()
        {
            item.damage = 25;
            item.width = 28;
            item.height = 34;
            item.value = Item.sellPrice(0, 1);
            item.rare = ItemRarityID.Blue;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 13;
            item.useTime = 13;
            item.knockBack = 4f;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<VineWhipProjectile>();
            item.shootSpeed = 20f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 3;
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