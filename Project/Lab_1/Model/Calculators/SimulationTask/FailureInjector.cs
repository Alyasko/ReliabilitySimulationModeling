using System;

namespace Lab_1.Model.Calculators.SimulationTask
{
    class FailureInjector
    {
        public FailureInjector(TargetSystem system, int impactElementsCount, double simulationTime, double impactProbability)
        {
            TargetSystem = system;
            ImpactElementsCount = impactElementsCount;
            SimulationTime = simulationTime;
            ImpactProbability = impactProbability;
        }

        public void SimulateWearingOff()
        {
            throw new NotImplementedException();
        }

        public void SimulateImpact()
        {
            throw new NotImplementedException();
        }

        public TargetSystem TargetSystem { get; set; }
        public int ImpactElementsCount { get; set; }
        public double SimulationTime { get; set; }
        public double ImpactProbability { get; set; }
    }
}
