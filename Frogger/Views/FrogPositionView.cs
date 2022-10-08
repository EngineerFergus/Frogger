using Frogger.General;
using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Frogger.Views
{
    internal class FrogPositionView : BaseView
    {
        private readonly BitmapFont Font;
        private readonly PlayerModel Model;

        public FrogPositionView(ContentManager contentManager, SpriteBatch spriteBatch, PlayerModel playerModel)
            : base(contentManager, spriteBatch)
        {
            Model = playerModel;
            var fontTexture = Manager.Load<Texture2D>("font");
            var fontSprite = new SpriteSheet(fontTexture, Sprites, 8, 8);
            Font = new BitmapFont(fontSprite);
        }

        public override void Draw()
        {
            //string msg = Model.Position.ToString().Replace("{", "(").Replace("}", ")");

            //Font.Draw(msg, new Vector2(4, 64), Color.Orange);
        }
    }
}
