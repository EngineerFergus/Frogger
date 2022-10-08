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

        public abstract void Enter(params object[] args);

        public abstract void Exit();
    }
}
