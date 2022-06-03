using Illuminum.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Items.Weapons.Summoner
{
    public class BlobofVoid : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blob of Void");
            Tooltip.SetDefault("Summons a Void Spirit to fight for you.");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 64;
            item.summon = true;
            item.mana = 10;
            item.width = 18;
            item.height = 22;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 8, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item44;
            item.shoot = ProjectileType<VoidSpirit>();
            item.buffType = BuffType<Buffs.VoidSpiritBuff>(); //The buff added to player after used the item
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
            recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
            recipe.AddIngredient(mod, "AbyssalFlesh", 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}