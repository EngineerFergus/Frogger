using Frogger.General;
using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

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
            var x = Math.Round(Model.Position.X, 0, MidpointRounding.AwayFromZero);
            var y = Math.Round(Model.Position.Y, 0, MidpointRounding.AwayFromZero);

            Blocks.Draw(new Vector2((int)x, (int)y), Model.Frame, Color.White, Model.Flip);
        }
    }
}
