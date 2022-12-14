using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Controllers
{
    internal interface IReset
    {
        event EventHandler MoveFinished;

        void Reset(ResetMode mode, bool resetForce = false);

        void SetForce(float force);
    }
}
