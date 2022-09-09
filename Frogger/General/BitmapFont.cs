using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.General
{
    internal class BitmapFont
    {
        private readonly SpriteSheet Sprite;

        public BitmapFont(SpriteSheet sprite)
        {
            Sprite = sprite;
        }

        public void Draw(string msg, Vector2 position, Color color)
        {
            Vector2 pos = position;

            foreach (char ch in msg)
            {
                var frame = ch - '!';

                if (frame >= 0)
                {
                    Sprite.Draw(pos, frame, color);
                }

                pos += new Vector2(Sprite.CellWidth, 0);
            }
        }
    }
}
