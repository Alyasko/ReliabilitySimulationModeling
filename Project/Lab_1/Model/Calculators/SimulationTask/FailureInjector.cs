using System;
using System.Collections.Generic;
using System.Linq;
using Lab_1.Model.Contracts;

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
            //throw new NotImplementedException();
        }

        public void SimulateImpact()
        {
            bool impactHappend = RandomEvent.Instance.Occured(ImpactProbability);

            if (impactHappend == true)
            {
                SpreadFailures();
            }
        }

        private void SpreadFailures()
        {
            IList<IElement> elementsForImpact = GetElementsForImpact();

            for (int i = 0; i < ImpactElementsCount; i++)
            {
                int failedElementIndex = RandomEvent.Instance.RandomInstance.Next(0, elementsForImpact.Count);
                elementsForImpact[failedElementIndex].IsAlive = false;
            }
        }

        private IList<IElement> GetElementsForImpact()
        {
            List<IElement> result = new List<IElement>();

            foreach (Floor floor in TargetSystem.Floors)
            {
                result.AddRange(floor.Elements);
            }

            return result;
        }

        public TargetSystem TargetSystem { get; set; }
        public int ImpactElementsCount { get; set; }
        public double SimulationTime { get; set; }
        public double ImpactProbability { get; set; }
    }
}
