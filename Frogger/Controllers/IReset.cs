﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Controllers
{
    internal interface IReset
    {
        void Reset(ResetMode mode);
    }
}