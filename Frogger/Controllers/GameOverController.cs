using Frogger.Models;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Controllers
{
    internal class GameOverController : IController
    {
        private GameOverModel Model;

        public GameOverController(GameOverModel model)
        {
            Model = model;
        }

        public void Update(float deltaTime)
        {
            var state = Keyboard.GetState();
            var pressedKeys = state.GetPressedKeys();

            if (pressedKeys.Contains(Keys.Space))
            {
                Model.PlayAgain = true;
            }
        }
    }
}
