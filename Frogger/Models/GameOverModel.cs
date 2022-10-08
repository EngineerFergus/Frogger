using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Models
{
    internal class GameOverModel
    {
        public bool PlayAgain { get; set; }

        public GameOverModel()
        {
            PlayAgain = false;
        }
    }
}
