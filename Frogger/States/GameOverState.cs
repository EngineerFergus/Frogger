using Frogger.Controllers;
using Frogger.FSM;
using Frogger.General;
using Frogger.Models;
using Frogger.Views;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.States
{
    internal class GameOverState : BaseState
    {
        private SpriteBatch Sprites;
        private GameOverView View;
        private GameOverController Controller;
        private GameOverModel Model;

        public GameOverState(StateMachine stateMachine) : base(stateMachine)
        {
            Sprites = new SpriteBatch(stateMachine.CurrentGame.GraphicsDevice);
            Model = new();
            Controller = new GameOverController(Model);
            View = new GameOverView(stateMachine.CurrentGame.Content, Sprites);
        }

        public override void Draw()
        {
            Sprites.Begin();
            View.Draw();
            Sprites.End();
        }

        public override void Enter(params object[] args)
        {
            Model.PlayAgain = false;
        }

        public override void Exit()
        {

        }

        public override void Update(float deltaTime)
        {
            Controller.Update(deltaTime);

            if (Model.PlayAgain)
            {
                Machine.Change("game");
            }
        }
    }
}
