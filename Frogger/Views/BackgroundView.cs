using Frogger.FSM;
using Frogger.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Frogger.Views
{
    internal class BackgroundView : BaseView
    {
        private readonly Texture2D Home;
        private readonly SpriteSheet Blocks;

        public BackgroundView(ContentManager contentManager, SpriteBatch Sprites) : base(contentManager, Sprites)
        {
            var blockTexture = Manager.Load<Texture2D>("blocks");
            Blocks = new SpriteSheet(blockTexture, Sprites, 16, 16);
            Home = Manager.Load<Texture2D>("home");
        }

        public override void Draw()
        {
            // River
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 14; x++)
                {
                    Blocks.Draw(new Vector2(x * 16, y * 16), 43, Color.White);
                }
            }

            // Home
            Sprites.Draw(Home, new Vector2(0, 24), Color.White);

            // Sidewalk
            for (int x = 0; x < 14; x++)
            {
                Blocks.Draw(new Vector2(x * 16, 8 * 16), 0, Color.White);
                Blocks.Draw(new Vector2(x * 16, 14 * 16), 0, Color.White);
            }
        }
    }
}
