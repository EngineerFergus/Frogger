using Frogger.FSM;
using Frogger.General;
using Frogger.Models;
using Frogger.Views;
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
        private static int Scale = 2;

        private readonly List<BaseView> Views = new List<BaseView>();
        private readonly SpriteBatch Sprites;
        private readonly RenderTarget2D Screen;
        private readonly BitmapFont Font;
        private PlayerModel Player;

        public GameState(StateMachine stateMachine) : base(stateMachine)
        {
            Screen = new RenderTarget2D(stateMachine.CurrentGame.GraphicsDevice, 224, 256);
            Sprites = new SpriteBatch(stateMachine.CurrentGame.GraphicsDevice);

            var fontTexture = Machine.CurrentGame.Content.Load<Texture2D>("font");
            var fontSprite = new SpriteSheet(fontTexture, Sprites, 8, 8);
            Font = new BitmapFont(fontSprite);

            Player = new PlayerModel();

            Views.Add(new BackgroundView(stateMachine.CurrentGame.Content, Sprites));
            Views.Add(new ScoreView(stateMachine.CurrentGame.Content, Sprites, Player));
        }

        public override void Draw()
        {
            Machine.CurrentGame.GraphicsDevice.SetRenderTarget(Screen);
            Machine.CurrentGame.GraphicsDevice.Clear(Color.Black);

            Sprites.Begin();

            foreach (var view in Views)
            {
                view.Draw();
            }

            DrawPlayerModel();

            Sprites.End();

            Machine.CurrentGame.GraphicsDevice.SetRenderTarget(null);

            Sprites.Begin();
            Sprites.Draw(Screen, new Rectangle(0, 0, 224 * Scale, 256 * Scale), Color.White);
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
