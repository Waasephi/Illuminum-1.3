using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Illuminum.Buffs
{
    public class DarkCorruptorBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Dark Corruptor");
            Description.SetDefault("A Dark Steel Corruptor will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.DarkCorruptor>()] > 0)
            {
                modPlayer.darkCorruptor = true;
            }
            if (!modPlayer.darkCorruptor)
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