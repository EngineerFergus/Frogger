using Frogger.General;
using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Frogger.Views
{
    internal class GoalView : BaseView
    {
        private readonly GoalContainerModel Goals;
        private readonly SpriteSheet Blocks;

        public GoalView(ContentManager contentManager, SpriteBatch spriteBatch, GoalContainerModel goals) : base(contentManager, spriteBatch)
        {
            Texture2D blocksTexture = contentManager.Load<Texture2D>("blocks");
            Blocks = new SpriteSheet(blocksTexture, spriteBatch, 16, 16);
            Goals = goals;
        }

        public override void Draw()
        {
            foreach (var goal in Goals.Goals)
            {
                Blocks.Draw(goal.Area.Location.ToVector2(), 10, Color.White);
            }
        }
    }
}
