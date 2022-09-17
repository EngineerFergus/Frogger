using Microsoft.Xna.Framework;

namespace Frogger.Models
{
    internal class GoalModel
    {
        public bool Occupied { get; set; }

        public Rectangle Area { get; }

        public GoalModel(Rectangle rect)
        {
            Area = rect;
            Occupied = false;
        }
    }
}
