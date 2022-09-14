using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.General
{
    internal class SpriteSheet
    {
        private readonly Texture2D Texture;
        private readonly SpriteBatch Batch;
        public readonly int CellWidth;
        public readonly int CellHeight;
        private readonly int Columns;
        private readonly int Rows;

        public SpriteSheet(Texture2D texture, SpriteBatch spriteBatch, int cellWidth, int cellHeight)
        {
            Texture = texture;
            CellWidth = cellWidth;
            CellHeight = cellHeight;

            Batch = spriteBatch;
            Columns = texture.Width / CellWidth;
            Rows = texture.Height / CellHeight;
        }

        public void Draw(Vector2 position, int frame, Color color)
        {
            Draw(position, frame, color, SpriteEffects.None);
        }

        public void Draw(Vector2 position, int frame, Color color, SpriteEffects effect)
        {
            if (frame < 0 || frame > Columns * Rows)
            {
                throw new ArgumentOutOfRangeException($"{frame} is out of range!");
            }

            int col = frame % Columns;
            int row = frame / Columns;
            int x = col * CellWidth;
            int y = row * CellHeight;

            Batch.Draw(Texture, 
                position, 
                new Rectangle(x, y, CellWidth, CellHeight), 
                color, 
                0.0f, 
                Vector2.Zero, 
                1, 
                effect, 
                0);
        }
    }
}
