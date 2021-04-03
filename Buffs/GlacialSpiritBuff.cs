using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Illuminum.Projectiles.Minions;

namespace Illuminum.Buffs
{
    public class GlacialSpiritBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Glacial Spirit");
            Description.SetDefault("A Glacial Spirit will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ProjectileType<GlacialSpirit>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}