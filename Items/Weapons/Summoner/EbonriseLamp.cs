using Illuminum.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Summoner
{
    public class EbonriseLamp : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ebonrise Lamp");
            Tooltip.SetDefault("Summons an Ebonrise Spirit to fight for you." +
                "\nMixture of Both Worlds.");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.summon = true;
            item.mana = 10;
            item.width = 36;
            item.height = 36;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 9;
            item.UseSound = SoundID.Item44;
            item.shoot = ProjectileType<EbonriseSpirit>();
            item.buffType = BuffType<Buffs.EbonriseSpiritBuff>(); //The buff added to player after used the item
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
            recipe.AddIngredient(mod, "VialofEvil", 10);
            recipe.AddIngredient(3271, 50); //Sandstone Block
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}