using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemReliability
{
    class SimulatorConfig
    {
        public int FloorCount { get; set; }
        public int ReconfigureTime { get; set; }
        public int ImpactElementsCount { get; set; }
        public double ImpactProbability { get; set; }
        public double SimulationTime { get; set; }
        public double ElementFailureRate { get; set; }
        public double MajorityElementFailureRate { get; set; }
        public double RCSFailureRate { get; set; }
        public ReconfigureMode ReconfMode { get; set; }

        public SimulatorConfig(int floorCount,
                               int reconfigureTime,
                               int impactElementsCount,
                               double simulationTime,
                               double elementFailureRate,
                               double majorityElementFailureRate,
                               double rcsFailureRate,
                               double impactProbability,
                               ReconfigureMode reconfMode)
        {
            this.FloorCount = floorCount;
            this.ReconfigureTime = reconfigureTime;
            this.ImpactElementsCount = impactElementsCount;
            this.SimulationTime = simulationTime;
            this.ElementFailureRate = elementFailureRate;
            this.MajorityElementFailureRate = majorityElementFailureRate;
            this.RCSFailureRate = rcsFailureRate;
            this.ImpactProbability = impactProbability;
            this.ReconfMode = reconfMode;
        }
    }
}
