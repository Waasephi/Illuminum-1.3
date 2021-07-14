using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna;
using Terraria.ModLoader;

namespace Illuminum
{
    public abstract class DrawEffect : Entity
    {
        public float scale = 1;
        public float[] ai = new float[3] { 0f, 0f, 0f };
        public virtual void PreDrawAll(SpriteBatch spriteBatch)
        {

        }
        public virtual bool PreDraw(SpriteBatch spriteBatch)
        {
            return true;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        public virtual void PostDraw(SpriteBatch spriteBatch)
        {

        }

        public virtual void Update()
        {
            
        }

        public virtual void Destroy()
        {
            Illuminum.drawEffects.Remove(this);
        }
    }
}
