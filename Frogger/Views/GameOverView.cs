using Frogger.General;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Frogger.Views
{
    internal class GameOverView : BaseView
    {
        private BitmapFont Font;

        public GameOverView(ContentManager contentManager, SpriteBatch spriteBatch) : base(contentManager, spriteBatch)
        {
            var fontTexture = contentManager.Load<Texture2D>("font");
            var fontSprite = new SpriteSheet(fontTexture, spriteBatch, 8, 8);
            Font = new BitmapFont(fontSprite);
        }

        public override void Draw()
        {
            Font.Draw("GAME OVER!", new Vector2(100, 50), Color.Red);
            Font.Draw("PRESS SPACE TO PLAY AGAIN", new Vector2(100, 100), Color.White);
        }
    }
}
