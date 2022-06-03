using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Illuminum.Buffs
{
    public class HematiteReaverBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hematite Reaver");
            Description.SetDefault("A Hematite Reaver will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.HematiteReaver>()] > 0)
            {
                modPlayer.hematiteReaver = true;
            }
            if (!modPlayer.hematiteReaver)
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