using Terraria;
using Illuminum.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Illuminum.Projectiles;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Melee
{
    public class HematiteKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hematite Knives");
            Tooltip.SetDefault("Shoots 2 knives at different speeds.");
        }

        public override void SetDefaults()
        {
            item.damage = 25;
            item.width = 54;
            item.height = 40;
            item.value = Item.sellPrice(silver: 80);
            item.rare = ItemRarityID.Green;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 10;
            item.useTime = 10;
            item.knockBack = 1f;
            item.noUseGraphic = true;
            item.shoot = ProjectileType<HematiteKnife>();
            item.shootSpeed = 15f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "HematiteChunk", 12);
            recipe.AddTile(mod, "CursedForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}