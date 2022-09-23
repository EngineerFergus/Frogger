using Frogger.General;
using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Frogger.Views
{
    internal class VehicleView : BaseView
    {
        private readonly VehicleRowModel Row;
        private readonly SpriteSheet Blocks;

        public VehicleView(ContentManager contentManager, SpriteBatch spriteBatch, VehicleRowModel row) : base(contentManager, spriteBatch)
        {
            Row = row;
            Texture2D blocksTexture = contentManager.Load<Texture2D>("blocks");
            Blocks = new SpriteSheet(blocksTexture, spriteBatch, 16, 16);
        }

        public override void Draw()
        {
            foreach (var vehicle in Row.Vehicles)
            {
                Blocks.Draw(vehicle.Position, vehicle.Frame, Color.White);
            }
        }
    }
}
