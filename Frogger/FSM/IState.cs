using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.FSM
{
    internal interface IState
    {
        void Update(float deltaTime);

        void Draw();

        void Enter();

        void Exit();
    }
}
