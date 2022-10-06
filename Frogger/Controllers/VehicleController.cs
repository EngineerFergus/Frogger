using Frogger.Models;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Frogger.Controllers
{
    internal class VehicleController : BaseMoveableController
    {
        private readonly IReset Reset;

        public VehicleController(PlayerModel player, IReset reset, IEnumerable<VehicleRowModel> rows) : base(player, rows)
        {
            Reset = reset;
        }

        protected override void OnCollision(Rectangle rect)
        {
            //Reset.Reset(ResetMode.Death);
        }
    }
}
