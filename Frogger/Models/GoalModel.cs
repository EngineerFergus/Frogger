using Microsoft.Xna.Framework;

namespace Frogger.Models
{
    internal class GoalModel
    {
        public bool Occupied { get; set; }

        public Rectangle Area { get; }

        public int Frame { get; set; }

        public GoalModel(Rectangle rect)
        {
            Area = rect;
            Occupied = false;
            Frame = 0;
        }
    }
}
