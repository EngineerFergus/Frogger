using Frogger.General;
using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Frogger.Views
{
    internal class ScoreView : BaseView
    {
        private readonly BitmapFont Font;
        private readonly PlayerModel Player;

        public ScoreView(ContentManager contentManager, SpriteBatch spriteBatch, PlayerModel player) : base(contentManager, spriteBatch)
        {
            var fontTexture = Manager.Load<Texture2D>("font");
            var fontSprite = new SpriteSheet(fontTexture, Sprites, 8, 8);
            Player = player;
            Font = new BitmapFont(fontSprite);
        }

        public override void Draw()
        {
            Font.Draw("1-UP", new Vector2(40, 0), Color.White);
            Font.Draw(Player.Score.ToString(), new Vector2(40, 8), Color.Red);

            Font.Draw("HI-SCORE", new Vector2(88, 0), Color.White);
            Font.Draw(Player.HiScore.ToString(), new Vector2(96, 8), Color.Red);

            for (int i = 0; i < Player.Lives; i++)
            {
                Font.Draw("/", new Vector2(i * 8, 30 * 8), Color.White);
            }

            Font.Draw("TIME", new Vector2(24 * 8, 31 * 8), Color.Yellow);
        }
    }
}
