using Frogger.Models;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Frogger.Factories
{
    internal static class TruckFactory
    {
        public static IEnumerable<VehicleModel> CreateFirstStage()
        {
            List<VehicleModel> models = new List<VehicleModel>();

            models.Add(new VehicleModel(17, new Vector2(16, 144)));
            models.Add(new VehicleModel(18, new Vector2(32, 144)));

            models.Add(new VehicleModel(17, new Vector2(16 + 128, 144)));
            models.Add(new VehicleModel(18, new Vector2(32 + 128, 144)));

            return models;
        }
    }
}
