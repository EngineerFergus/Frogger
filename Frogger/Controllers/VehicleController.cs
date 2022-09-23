using Frogger.Models;

namespace Frogger.Controllers
{
    internal class VehicleController : IController
    {
        private readonly VehicleRowModel Row;

        public VehicleController(VehicleRowModel row)
        {
            Row = row;
        }

        public void Update(float deltaTime)
        {

        }
    }
}
