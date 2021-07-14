using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Illuminum.Buffs
{
    public class HematiteStickerBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hematite Sticker");
            Description.SetDefault("A Hematite Sticker will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            IlluminumPlayer modPlayer = player.GetModPlayer<IlluminumPlayer>();
            if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.HematiteSticker>()] > 0)
            {
                modPlayer.hematiteSticker = true;
            }
            if (!modPlayer.hematiteSticker)
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