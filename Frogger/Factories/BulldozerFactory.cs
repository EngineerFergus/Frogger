using Frogger.Models;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Factories
{
    internal static class BulldozerFactory
    {
        public static IEnumerable<VehicleModel> CreateFirstStage()
        {
            List<VehicleModel> models = new List<VehicleModel>();

            models.Add(new VehicleModel(7, new Microsoft.Xna.Framework.Vector2(16, 192)));
            models.Add(new VehicleModel(7, new Microsoft.Xna.Framework.Vector2(16 + 64, 192)));
            models.Add(new VehicleModel(7, new Microsoft.Xna.Framework.Vector2(16 + (64 * 2), 192)));
            models.Add(new VehicleModel(7, new Microsoft.Xna.Framework.Vector2(16 + (64 * 3), 192)));

            return models;
        }
    }
}
