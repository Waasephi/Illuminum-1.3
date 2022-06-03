using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Illuminum.Buffs
{
    public class MiniDragonBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mini Dragon?");
            Description.SetDefault("This... is a dragon?");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.MiniDragon>()] > 0)
            {
                modPlayer.miniDragon = true;
            }
            if (!modPlayer.miniDragon)
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