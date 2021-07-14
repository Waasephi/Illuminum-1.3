using Illuminum;
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

namespace Illuminum.DrawEffects
{
    class CrimriseSwordSparkle : DrawEffect
    {
        float timer = 0f;
        float rotation = 0f;
        float scaleTarget = Main.rand.NextFloat(1f, 2f);
        float rotInc = Main.rand.NextFloat(-3f, 3f);

        public CrimriseSwordSparkle(Vector2 pos, Vector2 vel)
        {
            position = pos;
            velocity = vel;
        }

        public override void Update()
        {
            velocity.X *= 0.9f;
            velocity.Y *= 0.9f;

            timer++;
            if (timer < 10) scale = MathHelper.Lerp(scale, scaleTarget, 0.3f);
            else
            {
                Player player = Main.LocalPlayer;
                position = Vector2.Lerp(player.Center, Center, scale / scaleTarget);

                rotInc *= 0.93f;
                scale = MathHelper.Lerp(scale, scaleTarget, -0.23f);
                if (scale <= 0) base.Destroy();
            }

            rotation += rotInc;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);

            spriteBatch.Draw(ModContent.GetTexture("Illuminum/DrawEffects/CrimriseSwordSparkle"), position - Main.screenPosition,
                   new Rectangle(0, 0, 54, 54), Color.Red, MathHelper.ToRadians(rotation),
                   new Vector2(54 / 2, 54 / 2), scale, SpriteEffects.None, 0f);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Main.GameViewMatrix.ZoomMatrix);
        }
    }
}
