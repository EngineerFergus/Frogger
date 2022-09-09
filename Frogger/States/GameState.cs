using Frogger.FSM;
using Frogger.General;
using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.States
{
    internal class GameState : BaseState
    {
        private readonly SpriteBatch Sprites;
        private readonly SpriteSheet Blocks;
        private readonly Texture2D Home;
        private readonly BitmapFont Font;
        private PlayerModel Player;

        public GameState(StateMachine stateMachine)
        {
            var blockTexture = stateMachine.CurrentGame.Content.Load<Texture2D>("blocks");
            Home = stateMachine.CurrentGame.Content.Load<Texture2D>("home");
            Sprites = new SpriteBatch(stateMachine.CurrentGame.GraphicsDevice);
            Blocks = new SpriteSheet(blockTexture, Sprites, 16, 16);
            var fontTexture = stateMachine.CurrentGame.Content.Load<Texture2D>("font");
            var fontSprite = new SpriteSheet(fontTexture, Sprites, 8, 8);
            Font = new BitmapFont(fontSprite);

            Player = new PlayerModel(); // TODO use MVC
        }

        public override void Draw()
        {
            Sprites.Begin();

            DrawBackground();
            DrawScore();
            DrawPlayerModel();

            Sprites.End();
        }

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Update(float deltaTime)
        {

        }

        private void DrawBackground()
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

        private void DrawScore()
        {
            Font.Draw("1-UP", new Vector2(40, 0), Color.White);
            Font.Draw("1337", new Vector2(40, 8), Color.Red);

            Font.Draw("HI-SCORE", new Vector2(88, 0), Color.White);
            Font.Draw("10101", new Vector2(96, 8), Color.Red);
        }

        private void DrawPlayerModel()
        {
            for (int i = 0; i < Player.Lives; i++)
            {
                Font.Draw("/", new Vector2(i * 8, 30 * 8), Color.White);
            }

            Font.Draw("TIME", new Vector2(24 * 8, 31 * 8), Color.Yellow);
        }
    }
}
