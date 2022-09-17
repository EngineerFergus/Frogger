using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace Frogger.Controllers
{
    internal class PlayerController : IController, IReset
    {
        private static float MoveCooldownPeriod = 0.2f;
        private static float Distance = 16f;

        private readonly PlayerModel Model;
        private FrogAnimation Animation = null;
        private Cooldown Cooler = null;

        public PlayerController(PlayerModel model)
        {
            Model = model;
        }

        public void Update(float deltaTime)
        {
            if (Cooler != null)
            {
                Cooler.Update(deltaTime);
                if (!Cooler.Complete)
                {
                    return;
                }

                Cooler = null;
            }

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

            if (pressedKeys.Contains(Keys.Up) && Model.Position.Y > 16)
            {
                Model.Flip = SpriteEffects.None;
                Animation = new FrogAnimation(new int[] { 34, 33, 32, 34 }, 
                    Model.Position, 
                    new Vector2(0, -Distance), 
                    MoveCooldownPeriod);
            }
            else if (pressedKeys.Contains(Keys.Down) && Model.Position.Y < 240)
            {
                Model.Flip = SpriteEffects.FlipVertically;
                Animation = new FrogAnimation(new int[] { 34, 33, 32, 34 },
                    Model.Position,
                    new Vector2(0, Distance),
                    MoveCooldownPeriod);
            }
            else if (pressedKeys.Contains(Keys.Left) && Model.Position.X > 0)
            {
                Model.Flip = SpriteEffects.None;
                Animation = new FrogAnimation(new int[] { 37, 36, 35, 37 },
                    Model.Position,
                    new Vector2(-Distance, 0),
                    MoveCooldownPeriod);
            }
            else if (pressedKeys.Contains(Keys.Right) && Model.Position.X < 208)
            {
                Model.Flip = SpriteEffects.FlipHorizontally;
                Animation = new FrogAnimation(new int[] { 37, 36, 35, 37 },
                    Model.Position,
                    new Vector2(Distance, 0),
                    MoveCooldownPeriod);
            }
        }

        public void Reset(ResetMode mode)
        {
            if (mode == ResetMode.Death)
            {
                // TODO what happens when Player has no lives?
                Model.Lives--;
            }

            Model.Frame = 34;
            Model.Flip = SpriteEffects.None;
            Animation = null;
            Model.Position = new Vector2((16 * 7) - 8, 224);
            Cooler = new Cooldown(0.5f);
        }
    }
}
