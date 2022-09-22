using Frogger.Models;

namespace Frogger.Controllers
{
    internal class HomeAnimationController : IController
    {
        enum EyeState
        {
            Open,
            Closed
        }

        private readonly GoalContainerModel Goals;
        private readonly float OpenPeriod = 1f;
        private readonly float ClosedPeriod = 0.1f;

        private float Timer = 0.0f;
        private float CurrentPeriod;
        private int CurrentFrame;
        private EyeState CurrentState = EyeState.Open;

        public HomeAnimationController(GoalContainerModel goals)
        {
            Goals = goals;
            CurrentPeriod = OpenPeriod;
            CurrentFrame = 0;
        }

        public void Update(float deltaTime)
        {
            Timer += deltaTime;

            if (Timer > CurrentPeriod)
            {
                Timer = 0.0f;

                CurrentPeriod = OpenPeriod;
                CurrentFrame = 0;
                CurrentState = CurrentState == EyeState.Open ? EyeState.Closed : EyeState.Open;

                if (CurrentState == EyeState.Closed)
                {
                    CurrentPeriod = ClosedPeriod;
                    CurrentFrame = 1;
                }
            }


            foreach (var goal in Goals.Goals)
            {
                goal.Frame = CurrentFrame;
            }
        }
    }
}
