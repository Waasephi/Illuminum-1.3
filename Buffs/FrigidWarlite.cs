using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Illuminum.Buffs
{
    public class FrigidWarlite : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frigid Warlite");
            Description.SetDefault("A mini Frigid Warlock will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.FrigidWarlite>()] > 0)
            {
                modPlayer.frigidWarlite = true;
            }
            if (!modPlayer.frigidWarlite)
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