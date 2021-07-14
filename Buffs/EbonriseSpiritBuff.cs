using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Illuminum.Buffs
{
    public class EbonriseSpiritBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ebonrise Spirit");
            Description.SetDefault("An Ebonrise Spirit will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.EbonriseSpirit>()] > 0)
            {
                modPlayer.ebonriseSpirit = true;
            }
            if (!modPlayer.ebonriseSpirit)
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