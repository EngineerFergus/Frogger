using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Views
{
    internal abstract class BaseView
    {
        public ContentManager Manager { get; }
        public SpriteBatch Sprites { get; }

        public BaseView(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            Manager = contentManager;
            Sprites = spriteBatch;
        }

        public abstract void Draw();
    }
}
