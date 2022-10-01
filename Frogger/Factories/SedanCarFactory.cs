using Frogger.Models;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Frogger.Factories
{
    internal static class SedanCarFactory
    {
        public static IEnumerable<VehicleModel> CreateFirstStage(float x = 0, float y = 176)
        {
            List<VehicleModel> models = new List<VehicleModel>();

            models.Add(new VehicleModel(8, new Vector2(x + 208, y)));
            models.Add(new VehicleModel(8, new Vector2(x + 208 - 64, y)));
            models.Add(new VehicleModel(8, new Vector2(x + 208 - 128, y)));
            models.Add(new VehicleModel(8, new Vector2(x + 208 - 192, y)));

            return models;
        }
    }
}
