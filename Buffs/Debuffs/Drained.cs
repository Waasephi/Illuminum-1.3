using Terraria;
using Terraria.ModLoader;
using Illuminum.Items.Weapons.Conjurist;
using Terraria.ID;

namespace Illuminum.Buffs.Debuffs
{
    public class Drained : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Drained");
            Description.SetDefault("Your damage is shattered.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            IlluminumPlayer p = player.GetModPlayer<IlluminumPlayer>();
            ConjuristPlayer modPlayer = ConjuristPlayer.ModPlayer(player);
            player.allDamageMult *= 0.2f;
        }
    }
}