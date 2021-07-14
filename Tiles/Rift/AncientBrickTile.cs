using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Illuminum.Items.Placeables;

namespace Illuminum.Tiles.Rift
{
	public class AncientBrickTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileBlockLight[Type] = true;
			AddMapEntry(new Color(138, 74, 39));
			mineResist = 4f;
			minPick = 150;
			drop = ModContent.ItemType<AncientBrick>();
			soundType = SoundID.Tink;
			dustType = DustID.Stone;
			//soundStyle = 1;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
	}
}