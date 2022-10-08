using Frogger.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Frogger.Controllers
{
    internal class PlayerController : IController, IReset
    {
        private static float MoveCooldownPeriod = 0.2f;
        private static float DeathCooldownPeriod = 0.5f;
        private static float Distance = 16f;

        private readonly PlayerModel Model;
        private FrogAnimation Animation = null;
        private Cooldown Cooler = null;
        private bool InDeathAnimation = false;
        private float Force = 0f;

        public bool Disabled { get; set; }

        public event EventHandler MoveFinished;

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
                Model.Position = Animation.Position + new Vector2(Force * deltaTime, 0);
                Model.Frame = Animation.Frame;
                return;
            }
            else
            {
                Model.Position += new Vector2(Force * deltaTime, 0);
            }

            if (Animation != null && Animation.Done)
            {
                if (InDeathAnimation)
                {
                    Animation = null;
                    Model.Frame = 34;
                    Model.Flip = SpriteEffects.None;
                    Force = 0f;
                    Model.Position = new Vector2((16 * 7), 224);
                    InDeathAnimation = false;
                }
                else
                {
                    Model.Position = Animation.Position;
                    Model.Frame = Animation.Frame;
                    Model.Score += 10;
                    if (Model.Score > Model.HiScore)
                    {
                        Model.HiScore = Model.Score;
                    }
                    MoveFinished?.Invoke(this, EventArgs.Empty);
                }
            }

            if (InDeathAnimation || Disabled) { return; }

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

        public void Reset(ResetMode mode, bool resetForce = false)
        {
            if (mode == ResetMode.Death && !InDeathAnimation)
            {
                // TODO what happens when Player has no lives?
                Model.Lives--;
                InDeathAnimation = true;
                Model.Flip = SpriteEffects.None;

                if (resetForce)
                {
                    Force = 0f;
                }

                Animation = new FrogAnimation(new int[] { 19, 20, 21, 22 },
                        Model.Position,
                        new Vector2(0, 0),
                        DeathCooldownPeriod);
            }
            else if (mode == ResetMode.Goal)
            {
                Animation = null;
                Model.Frame = 34;
                Model.Flip = SpriteEffects.None;
                Model.Position = new Vector2((16 * 7) - 8, 224);
                Model.Score += 50;
                Model.Goals++;

                if (Model.Score > Model.HiScore)
                {
                    Model.HiScore = Model.Score;
                }

                Force = 0f;
                Cooler = new Cooldown(0.5f);
                InDeathAnimation = false;
            }
        }

        public void SetForce(float force)
        {
            Force = force;
        }
    }
}
