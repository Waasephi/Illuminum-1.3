using Illuminum.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Summoner
{
    public class HematiteWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hematite Wand");
            Tooltip.SetDefault("Summons a Hematite Reaver to fight for you.");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 34;
            item.summon = true;
            item.mana = 10;
            item.width = 48;
            item.height = 46;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item44;
            item.shoot = ProjectileType<HematiteReaver>();
            item.buffType = BuffType<Buffs.HematiteReaverBuff>(); //The buff added to player after used the item
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 300);
            position = Main.MouseWorld;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "HematiteChunk", 8);
            recipe.AddTile(mod, "CursedForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}