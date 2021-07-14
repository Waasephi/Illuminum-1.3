using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Illuminum.Buffs
{
    public class OvergrowthBiterBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Overgrowth Biter");
            Description.SetDefault("An Overgrowth Biter will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.OvergrowthBiter>()] > 0)
            {
                modPlayer.overgrowthBiter = true;
            }
            if (!modPlayer.overgrowthBiter)
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