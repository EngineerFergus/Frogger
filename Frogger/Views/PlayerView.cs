using Frogger.General;
using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Views
{
    internal class PlayerView : BaseView
    {
        private readonly SpriteSheet Blocks;
        private readonly PlayerModel Model;

        public PlayerView(ContentManager contentManager, SpriteBatch spriteBatch, PlayerModel playerModel) : base(contentManager, spriteBatch)
        {
            Texture2D blocksTexture = contentManager.Load<Texture2D>("blocks");
            Blocks = new SpriteSheet(blocksTexture, spriteBatch, 16, 16);
            Model = playerModel;
        }

        public override void Draw()
        {
            Blocks.Draw(Model.Position, Model.Frame, Color.White);
        }
    }
}
