using Frogger.General;
using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Frogger.Views
{
    internal class VehicleView : BaseView
    {
        private readonly List<VehicleRowModel> Rows = new();
        private readonly SpriteSheet Blocks;

        public VehicleView(ContentManager contentManager, SpriteBatch spriteBatch, IEnumerable<VehicleRowModel> rows) : base(contentManager, spriteBatch)
        {
            Rows.AddRange(rows);
            Texture2D blocksTexture = contentManager.Load<Texture2D>("blocks");
            Blocks = new SpriteSheet(blocksTexture, spriteBatch, 16, 16);
        }

        public override void Draw()
        {
            foreach (var row in Rows)
            {
                if (row.IsCoolingDown) { continue; }

                foreach (var vehicle in row.Vehicles)
                {
                    var xr = vehicle.Position + row.OffsetRight;
                    var posRight = new Vector2((int)xr.X, (int)xr.Y);
                    Blocks.Draw(posRight, vehicle.Frame, Color.White);

                    if (row.Ghost == VehicleGhost.Ghost)
                    {
                        var xl = vehicle.Position + row.OffsetLeft;
                        var posLeft = new Vector2((int)xl.X, (int)xl.Y);
                        Blocks.Draw(posLeft, vehicle.Frame, Color.White);
                    }
                }
            }
            
        }
    }
}
