using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Runtime.InteropServices.ObjectiveC;

namespace Frogger.FSM
{
    internal class StateMachine
    {
        private readonly Dictionary<string, IState> States = new();
        private IState CurrentState;

        public Game CurrentGame { get; }

        public StateMachine(Game game)
        {
            CurrentGame = game;
        }

        public void Add(string stateName, IState state)
        {
            States.Add(stateName, state);
        }

        public void Change(string stateName, params object[] args)
        {
            if (!States.ContainsKey(stateName))
            {
                throw new KeyNotFoundException($"{stateName} is not a valid state!");
            }

            if (CurrentState != null)
            {
                CurrentState.Exit();
            }

            CurrentState = States[stateName];
            CurrentState.Enter(args);
        }

        public void Draw()
        {
            if (CurrentState != null)
            {
                CurrentState.Draw();
            }
        }

        public void Update(float deltaTime)
        {
            if (CurrentState != null)
            {
                CurrentState.Update(deltaTime);
            }
        }
    }
}
