using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemReliability
{
    class FailureInjector
    {
        private System system;
        private int impactElementsCount;
        private double simulationTime;
        private double impactProbability;

        public FailureInjector(System system, int impactElementsCount, double simulationTime, double impactProbability)
        {
            this.system = system;
            this.impactElementsCount = impactElementsCount;
            this.simulationTime = simulationTime;
            this.impactProbability = impactProbability;
        }

        void SimulateWearingOff()
        { }

        void SimulateImpact()
        { }
    }
}
