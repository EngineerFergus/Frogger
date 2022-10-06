using Frogger.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Frogger.Controllers
{
    internal class RiverObjectController : BaseMoveableController
    {
        private readonly IReset Reset;

        public RiverObjectController(PlayerModel player, IReset reset, IEnumerable<VehicleRowModel> rows) : base(player, rows)
        {
            Reset = reset;
            Reset.MoveFinished += Player_MoveFinished;
        }

        private void Player_MoveFinished(object sender, EventArgs e)
        {
            var playerArea = new Rectangle((int)Player.Position.X, (int)Player.Position.Y, 16, 16);

            foreach (var row in VRows)
            {
                if (row is RiverRowModel riverRow)
                {
                    if (riverRow.Bounds.Contains(playerArea))
                    {
                        if (TouchesObject(riverRow, playerArea, out _))
                        {
                            Reset.SetForce(riverRow.Speed * (riverRow.Direction == MovementDirection.LeftToRight ? 1f : -1f));
                        }
                        else
                        {
                            Reset.Reset(ResetMode.Death);
                            // TODO why is this bug happening?
                        }

                        return;
                    }
                }
            }

            Reset.SetForce(0);
        }

        protected override void OnUpdate(float deltaTime)
        {
            // what happens when froggy hits the bounds?

        }

        protected override void OnCollision(Rectangle rect)
        {

        }
    }
}
