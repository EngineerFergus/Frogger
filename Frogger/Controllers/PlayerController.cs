using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace Frogger.Controllers
{
    internal class PlayerController : IController
    {
        private static float MoveCooldownPeriod = 0.2f;
        private static float Distance = 8f;

        private readonly PlayerModel Model;
        private FrogAnimation Animation;

        public PlayerController(PlayerModel model)
        {
            Model = model;
        }

        public void Update(float deltaTime)
        {
            if (Animation != null && !Animation.Done)
            {
                Animation.Update(deltaTime);
                Model.Position = Animation.Position;
                Model.Frame = Animation.Frame;
                return;
            }

            Animation = null;

            var state = Keyboard.GetState();
            var pressedKeys = state.GetPressedKeys();

            if (pressedKeys.Contains(Keys.Up))
            {
                Model.Flip = SpriteEffects.None;
                Animation = new FrogAnimation(new int[] { 34, 33, 32, 34 }, 
                    Model.Position, 
                    new Vector2(0, -Distance), 
                    MoveCooldownPeriod);
            }
            else if (pressedKeys.Contains(Keys.Down))
            {
                Model.Flip = SpriteEffects.FlipVertically;
                Animation = new FrogAnimation(new int[] { 34, 33, 32, 34 },
                    Model.Position,
                    new Vector2(0, Distance),
                    MoveCooldownPeriod);
            }
            else if (pressedKeys.Contains(Keys.Left))
            {
                Model.Flip = SpriteEffects.None;
                Animation = new FrogAnimation(new int[] { 37, 36, 35, 37 },
                    Model.Position,
                    new Vector2(-Distance, 0),
                    MoveCooldownPeriod);
            }
            else if (pressedKeys.Contains(Keys.Right))
            {
                Model.Flip = SpriteEffects.FlipHorizontally;
                Animation = new FrogAnimation(new int[] { 37, 36, 35, 37 },
                    Model.Position,
                    new Vector2(Distance, 0),
                    MoveCooldownPeriod);
            }
        }
    }
}
