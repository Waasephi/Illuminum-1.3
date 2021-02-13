using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace Illuminum.NPCs {
    public abstract class BaseNPC : ModNPC {
        public void BasicMover(Vector2 position, float speed, float res) {
            Vector2 pos = position;
            float vel = speed; // speed at which they move
            Vector2 mover = pos - npc.Center;

            float mag = (float)Math.Sqrt(mover.X * mover.X + mover.Y * mover.Y);
            if (mag > vel)
                mover *= vel / mag;
            mover = (npc.velocity * res + mover) / (res + 1f);

            npc.velocity = mover;
        }
    }
}
