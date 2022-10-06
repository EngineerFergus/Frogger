using Frogger.Controllers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Frogger.Models
{
    internal class RiverRowModel : VehicleRowModel
    {
        public Rectangle Bounds { get; }

        public RiverRowModel(IEnumerable<VehicleModel> models, Rectangle bounds, float offSetDistance = 0, 
            float pixelsPerSecond = 32, MovementDirection direction = MovementDirection.LeftToRight) : 
            base(models, offSetDistance, pixelsPerSecond, -1, VehicleGhost.Ghost, direction)
        {
            Bounds = bounds;
        }
    }
}
