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
        public abstract void Update(float deltaTime);

        public abstract void Draw();

        public abstract void Enter();

        public abstract void Exit();
    }
}
