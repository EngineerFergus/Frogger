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
        private readonly IReset PlayerReset;

        public GoalController(PlayerModel model, GoalContainerModel goals, IReset playerReset)
        {
            Player = model;
            GoalContainer = goals;
            PlayerReset = playerReset;
        }

        public void Update(float deltaTime)
        {
            var playerArea = new Rectangle((int)Player.Position.X, (int)Player.Position.Y, 16, 16);

            foreach (var goal in GoalContainer.Goals)
            {
                if (!goal.Area.Intersects(playerArea))
                {
                    continue;
                }

                if (goal.Occupied)
                {
                    PlayerReset.Reset(ResetMode.Death);
                }
                else if (!goal.Occupied)
                {
                    goal.Occupied = true;
                    PlayerReset.Reset(ResetMode.Goal);
                }

                return;
            }
        }
    }
}
