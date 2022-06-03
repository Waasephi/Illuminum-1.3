using Terraria;
using Illuminum.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Illuminum.Projectiles;

namespace Illuminum.Items.Weapons.Melee
{
    public class EbonduneLeash : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ebondune Leash");
        }

        public override void SetDefaults()
        {
            item.damage = 22;
            item.width = 58;
            item.height = 40;
            item.value = Item.sellPrice(silver: 50);
            item.rare = ItemRarityID.Blue;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 13;
            item.useTime = 13;
            item.knockBack = 4f;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<EbonduneLeashProjectile>();
            item.shootSpeed = 25f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "VialofEvil", 8);
            recipe.AddIngredient(ItemID.Sandstone, 75); //Sandstone Block
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}