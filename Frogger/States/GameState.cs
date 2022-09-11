using Frogger.Controllers;
using Frogger.FSM;
using Frogger.General;
using Frogger.Models;
using Frogger.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Frogger.States
{
    internal class GameState : BaseState
    {
        private static int Scale = 2;

        private readonly List<BaseView> Views = new List<BaseView>();
        private readonly List<IController> Controllers = new List<IController>();
        private readonly SpriteBatch Sprites;
        private readonly RenderTarget2D Screen;
        private readonly PlayerModel Player;

        public GameState(StateMachine stateMachine) : base(stateMachine)
        {
            Screen = new RenderTarget2D(stateMachine.CurrentGame.GraphicsDevice, 224, 256);
            Sprites = new SpriteBatch(stateMachine.CurrentGame.GraphicsDevice);

            Player = new PlayerModel();

            Views.Add(new BackgroundView(stateMachine.CurrentGame.Content, Sprites));
            Views.Add(new ScoreView(stateMachine.CurrentGame.Content, Sprites, Player));
            Views.Add(new PlayerView(stateMachine.CurrentGame.Content, Sprites, Player));

            Controllers.Add(new PlayerController(Player));
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
            foreach(var controller in Controllers)
            {
                controller.Update(deltaTime);
            }
        }
    }
}
