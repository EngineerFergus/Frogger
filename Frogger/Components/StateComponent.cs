using Frogger.FSM;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Components
{
    internal class StateComponent : DrawableGameComponent
    {
        public StateMachine Machine { get; }

        public StateComponent(Game game) : base(game)
        {
            Machine = new StateMachine(game);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float deltaTime = gameTime.ElapsedGameTime.Milliseconds / 1000f;
            Machine.Update(deltaTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Machine.Draw();
        }
    }
}
