﻿namespace Frogger.FSM
{
    internal interface IState
    {
        void Update(float deltaTime);

        void Draw();

        void Enter();

        void Exit();
    }
}
