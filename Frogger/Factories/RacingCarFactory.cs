using Frogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Factories
{
    internal static class RacingCarFactory
    {
        public static IEnumerable<VehicleModel> CreateFirstStage()
        {
            List<VehicleModel> models = new List<VehicleModel>();

            models.Add(new VehicleModel(6, new Microsoft.Xna.Framework.Vector2(16, 160)));
            //models.Add(new VehicleModel(7, new Microsoft.Xna.Framework.Vector2(16 + 64, 192)));
            //models.Add(new VehicleModel(7, new Microsoft.Xna.Framework.Vector2(16 + (64 * 2), 192)));
            //models.Add(new VehicleModel(7, new Microsoft.Xna.Framework.Vector2(16 + (64 * 3), 192)));

            return models;
        }
    }
}
