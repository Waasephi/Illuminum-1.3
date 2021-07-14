using Terraria;
using Terraria.ModLoader;

namespace Illuminum.Buffs
{
	public class AbyssalBerserk : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Abyssal Rage");
			Description.SetDefault("Damage increased by 20%, but Defense reduced by 20.");
			Main.buffNoTimeDisplay[Type] = false;
			Main.buffNoSave[Type] = true;
			canBeCleared = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.allDamage *= 1.2f;
			player.statDefense -= 20;
		}
	}
}