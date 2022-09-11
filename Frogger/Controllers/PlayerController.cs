using Frogger.Models;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Controllers
{
    internal class PlayerController : IController
    {
        private static float MoveCooldownPeriod = 0.1f;
        private static float Distance = 8f;

        private readonly PlayerModel Model;
        private float MoveCooldown = 0f;

        public PlayerController(PlayerModel model)
        {
            Model = model;
        }

        public void Update(float deltaTime)
        {
            if (MoveCooldown > 0f)
            {
                MoveCooldown -= deltaTime;
                return;
            }

            MoveCooldown = 0f;

            var state = Keyboard.GetState();
            var pressedKeys = state.GetPressedKeys();

            if (pressedKeys.Contains(Keys.Up))
            {
                Model.Position += new Vector2(0, -Distance);
                MoveCooldown = MoveCooldownPeriod;
            }
            else if (pressedKeys.Contains(Keys.Down))
            {
                Model.Position += new Vector2(0, Distance);
                MoveCooldown = MoveCooldownPeriod;
            }
            else if (pressedKeys.Contains(Keys.Left))
            {
                Model.Position += new Vector2(-Distance, 0);
                MoveCooldown = MoveCooldownPeriod;
            }
            else if (pressedKeys.Contains(Keys.Right))
            {
                Model.Position += new Vector2(Distance, 0);
                MoveCooldown = MoveCooldownPeriod;
            }
        }
    }
}
