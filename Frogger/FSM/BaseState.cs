using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.FSM
{
    internal abstract class BaseState : IState
    {
        public StateMachine Machine { get; }

        public BaseState(StateMachine stateMachine)
        {
            Machine = stateMachine;
        }

        public abstract void Update(float deltaTime);

        public abstract void Draw();

        public abstract void Enter();

        public abstract void Exit();
    }
}
