﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemReliability
{
    interface IReconfigureAlgorithm
    {
        public bool Reconfigure(System system);
    }
}
