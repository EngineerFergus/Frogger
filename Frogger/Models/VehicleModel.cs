using Microsoft.Xna.Framework;

namespace Frogger.Models
{
    internal class VehicleModel
    {
        public Vector2 Position { get; set; }
        public int Frame { get; }

        public VehicleModel(int frame, Vector2 pos)
        {
            Frame = frame;
            Position = pos;
        }
    }
}
