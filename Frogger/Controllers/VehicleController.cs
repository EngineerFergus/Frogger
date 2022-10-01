using Frogger.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Frogger.Controllers
{
    internal class VehicleController : IController
    {
        private readonly List<VehicleRowModel> Rows = new List<VehicleRowModel>();
        private readonly PlayerModel Player;
        private readonly IReset Reset;

        public VehicleController(PlayerModel player, IReset reset, IEnumerable<VehicleRowModel> rows)
        {
            Player = player;
            Reset = reset;

            Rows.AddRange(rows);
            
            foreach (var row in Rows)
            {
                row.StartingPoint = row.OffsetLeft * (row.Direction == VehicleDirection.LeftToRight ? 1f : -1f);
                row.OffsetLeft = row.StartingPoint;
            }
        }

        public void Update(float deltaTime)
        {
            var playerArea = new Rectangle((int)Player.Position.X, (int)Player.Position.Y, 16, 16);

            foreach (var row in Rows)
            {
                //foreach (var vehicle in row.Vehicles)
                //{
                //    var rRect = new Rectangle((int)vehicle.Position.X, (int)vehicle.Position.Y, 16, 16);
                //
                //    if (rRect.Intersects(playerArea))
                //    {
                //        Reset.Reset(ResetMode.Death);
                //    }
                //}

                if (row.CurrentCooldown > 0)
                {
                    row.CurrentCooldown -= deltaTime;
                    continue;
                }

                row.CurrentCooldown = 0;
                row.IsCoolingDown = false;

                var distance = row.Speed * deltaTime;
                if (row.Direction == VehicleDirection.RightToLeft)
                {
                    distance *= -1f;
                }

                row.OffsetRight += new Vector2(distance, 0);
                row.OffsetLeft += new Vector2(distance, 0);

                if (Math.Abs(row.OffsetRight.X) >= 224)
                {
                    var sign = row.Direction == VehicleDirection.LeftToRight ? 1f : -1f;
                    var diff = new Vector2(row.OffsetRight.X - (224 * sign), 0);
                    diff += (row.OffsetLeft * sign);
                    row.OffsetRight = row.OffsetLeft;
                    row.OffsetLeft = row.StartingPoint + (diff * sign);

                    if (row.CoolDownPeriod > 0)
                    {
                        row.CurrentCooldown = row.CoolDownPeriod;
                        row.IsCoolingDown = true;
                    }
                }
            }
        }
    }
}
