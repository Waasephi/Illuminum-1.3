using Illuminum.Items.Materials;
using Illuminum.Items.Accessories;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Illuminum
{
	public class MyGlobalNPC : GlobalNPC
	{
		//TODO convert to NextBool
		public override void NPCLoot(NPC npc)
		{
			//The if (Main.rand.Next(x) == 0) determines how rare the drop is. To find the percent of a drop, divide 100 by your desired percent, minus the percent sign. Ex: A 2% chance would be 100% / 2%, or 50. This is what you put in place of x.

			switch (npc.type)
			{
				case NPCID.DD2Betsy:
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DragonScale>(), Main.rand.Next(20, 25));
					break;
			}
		}
	}
}