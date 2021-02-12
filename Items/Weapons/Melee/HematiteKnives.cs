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
            item.value = Item.sellPrice(0, 1);
            item.rare = 2;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.knockBack = 1f;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<HematiteKnifeProjectile>();
            item.shootSpeed = 30f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.autoReuse = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
            Projectile.NewProjectile(position.X, position.Y, speedX / 2, speedY / 2, ProjectileType<HematiteKnifeProjectile>(), damage, knockBack, player.whoAmI);
            // By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
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