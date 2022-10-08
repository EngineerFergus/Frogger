using Frogger.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Frogger.Controllers
{
    internal abstract class BaseMoveableController : IController
    {
        private readonly List<VehicleRowModel> Rows = new List<VehicleRowModel>();
        protected readonly PlayerModel Player;

        protected IList<VehicleRowModel> VRows { get { return Rows; } }

        public BaseMoveableController(PlayerModel player, IEnumerable<VehicleRowModel> rows)
        {
            Player = player;

            Rows.AddRange(rows);

            foreach (var row in Rows)
            {
                row.StartingPoint = row.OffsetLeft * (row.Direction == MovementDirection.LeftToRight ? 1f : -1f);
                row.OffsetLeft = row.StartingPoint;
            }
        }

        public void Update(float deltaTime)
        {
            var playerArea = new Rectangle((int)Player.Position.X, (int)Player.Position.Y, 16, 16);

            foreach (var row in Rows)
            {
                if (TouchesObject(row, playerArea, out Rectangle rect))
                {
                    OnCollision(rect);
                }

                if (row.CurrentCooldown > 0)
                {
                    row.CurrentCooldown -= deltaTime;
                    continue;
                }

                row.CurrentCooldown = 0;
                row.IsCoolingDown = false;

                var distance = row.Speed * deltaTime;
                if (row.Direction == MovementDirection.RightToLeft)
                {
                    distance *= -1f;
                }

                row.OffsetRight += new Vector2(distance, 0);
                row.OffsetLeft += new Vector2(distance, 0);

                if (Math.Abs(row.OffsetRight.X) >= 224)
                {
                    var sign = row.Direction == MovementDirection.LeftToRight ? 1f : -1f;
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

            OnUpdate(deltaTime);
        }

        protected bool TouchesObject(VehicleRowModel row, Rectangle playerArea, out Rectangle intersectRect)
        {
            foreach (var vehicle in row.Vehicles)
            {
                var rRect = new Rectangle((int)(vehicle.Position.X + row.OffsetRight.X), (int)vehicle.Position.Y, 16, 16);

                if (rRect.Intersects(playerArea))
                {
                    intersectRect = rRect;
                    return true;
                }

                if (row.Ghost == VehicleGhost.Ghost)
                {
                    var lRect = new Rectangle((int)(vehicle.Position.X + row.OffsetLeft.X), (int)vehicle.Position.Y, 16, 16);

                    if (lRect.Intersects(playerArea))
                    {
                        intersectRect = lRect;
                        return true;
                    }
                }
            }

            intersectRect = Rectangle.Empty;
            return false;
        }

        protected virtual void OnUpdate(float deltaTime)
        {

        }

        protected abstract void OnCollision(Rectangle rect);

        protected double CalcIOU(Rectangle A, Rectangle B)
        {
            Rectangle intersect = Rectangle.Intersect(A, B);
            Rectangle union = Rectangle.Union(A, B);
            double IA = intersect.Width * intersect.Height;
            double UA = union.Width * union.Height;
            return IA / UA;
        }

        protected int CalcIntersectWidth(Rectangle A, Rectangle B)
        {
            Rectangle intersect = Rectangle.Intersect(A, B);
            return intersect.Width;
        }
    }
}
