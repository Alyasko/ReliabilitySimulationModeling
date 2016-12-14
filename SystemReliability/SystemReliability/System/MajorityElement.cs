using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemReliability
{
    class MajorityElement : IHardwareComponent
    {
        public double FailureRate { get; set; }
        public bool IsAlive { get; set; }
        public MajorityElementMode Mode { get; set; }

        public MajorityElement(double majorityElementFailureRate)
        {
            FailureRate = majorityElementFailureRate;
            Mode = MajorityElementMode.Majority;
            IsAlive = true;
        }
    }
}
