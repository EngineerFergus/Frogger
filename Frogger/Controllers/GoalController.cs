using Frogger.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Controllers
{
    internal class GoalController : IController
    {
        private readonly PlayerModel Player;
        private readonly GoalContainerModel GoalContainer;
        private readonly IReset Reset;

        public GoalController(PlayerModel model, GoalContainerModel goals, IReset reset)
        {
            Player = model;
            GoalContainer = goals;
            Reset = reset;
        }

        public void Update(float deltaTime)
        {
            var playerArea = new Rectangle((int)Player.Position.X, (int)Player.Position.Y, 16, 16);

            foreach (var goal in GoalContainer.Goals)
            {
                // TODO what if this slot is occupied?

                if (goal.Area.Intersects(playerArea))
                {
                    goal.Occupied = true;
                    Reset.Reset();
                    return;
                }
            }
        }
    }
}
