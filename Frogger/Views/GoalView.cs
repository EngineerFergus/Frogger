using Frogger.General;
using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Frogger.Views
{
    internal class GoalView : BaseView
    {
        public int Frame { get; set; }

        private readonly float CooldownPeriod = 1f;
        private readonly float FlashPeriod = 0.1f;

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
                if (goal.Occupied)
                {
                    Blocks.Draw(goal.Area.Location.ToVector2(), 10 + Frame, Color.White);
                }
            }
        }
    }
}
