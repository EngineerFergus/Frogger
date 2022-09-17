using Frogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private readonly float CoolDownPeriod = 1f;
        private readonly float FlashPeriod = 0.1f;

        private float Timer = 0.0f;
        private EyeState State = EyeState.Open;


        public HomeAnimationController(GoalContainerModel goals)
        {
            Goals = goals;
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
