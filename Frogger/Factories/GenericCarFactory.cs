using Frogger.Models;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Frogger.Factories
{
    internal static class GenericCarFactory
    {
        public static IEnumerable<VehicleModel> CreateFirstStage(float x = 0, float y = 176, int frame = 8)
        {
            List<VehicleModel> models = new List<VehicleModel>();

            models.Add(new VehicleModel(frame, new Vector2(x + 208, y)));
            models.Add(new VehicleModel(frame, new Vector2(x + 208 - 64, y)));
            models.Add(new VehicleModel(frame, new Vector2(x + 208 - 64 - 64, y)));
            models.Add(new VehicleModel(frame, new Vector2(x + 208 - 64 - 64 - 64, y)));

            return models;
        }
    }
}
