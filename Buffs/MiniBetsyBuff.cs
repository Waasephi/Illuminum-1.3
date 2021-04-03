using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Illuminum.Buffs
{
    public class MiniBetsyBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mini Betsy");
            Description.SetDefault("A Mini Betsy will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.MiniBetsy>()] > 0)
            {
                modPlayer.miniBetsy = true;
            }
            if (!modPlayer.miniBetsy)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}