using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemReliability
{
    class Element : IHardwareComponent
    {
        public double FailureRate { get; set; }
        public bool IsAlive { get; set; }

        public Element(double failureRate)
        {
            FailureRate = failureRate;
            IsAlive = true;
        }
    }
}
