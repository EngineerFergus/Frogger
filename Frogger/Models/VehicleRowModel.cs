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

        public VehicleRowModel(IEnumerable<VehicleModel> models)
        {
            Vehicles.AddRange(models);
        }
    }
}
