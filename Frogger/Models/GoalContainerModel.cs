using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    internal class GoalContainerModel
    {
        public IList<GoalModel> Goals { get; }

        public GoalContainerModel()
        {
            Goals = new List<GoalModel>();

            int x = 8;
            int y = 32;

            for (int i = 0; i < 5; i++)
            {
                Rectangle rect = new Rectangle(x, y, 16, 16);
                Goals.Add(new GoalModel(rect));
                x += 48;
            }
        }
    }
}
