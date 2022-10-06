using Frogger.Controllers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    internal class VehicleRowModel
    {
        public List<VehicleModel> Vehicles { get; } = new List<VehicleModel>();

        public Vector2 OffsetRight { get; set; }
        public Vector2 OffsetLeft { get; set; }
        public float OffsetDistance { get; }
        public bool IsCoolingDown { get; set; }
        public VehicleGhost Ghost { get; }
        public MovementDirection Direction { get; set; }
        public float CoolDownPeriod { get; set; }
        public float CurrentCooldown { get; set; }
        public float Speed { get; set; }
        public Vector2 StartingPoint { get; set; }

        public VehicleRowModel(IEnumerable<VehicleModel> models, 
            float offSetDistance = 0f,
            float pixelsPerSecond = 32f,
            float coolDownPeriod = -1,
            VehicleGhost ghost = VehicleGhost.Ghost,
            MovementDirection direction = MovementDirection.LeftToRight
            )
        {
            Vehicles.AddRange(models);
            OffsetRight = Vector2.Zero;
            Speed = pixelsPerSecond;
            OffsetLeft = new Vector2(-(224 + offSetDistance), 0);
            Ghost = ghost;
            OffsetDistance = offSetDistance;
            CoolDownPeriod = coolDownPeriod;
            Direction = direction;
        }
    }
}
