using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask
{
    class FailureInjector
    {
        public FailureInjector(TargetSystem system, ControlReconfigurationSystem controlReconfigurationSystem, int impactElementsCount, double simulationTime, double impactProbability)
        {
            ControlReconfigurationSystem = controlReconfigurationSystem;
            TargetSystem = system;
            ImpactElementsCount = impactElementsCount;
            SimulationTime = simulationTime;
            ImpactProbability = impactProbability;
        }

        public void SimulateWearingOff()
        {
            List<Element> systemElements = new List<Element>();
            SystemComponentWearingOff(ControlReconfigurationSystem);
            foreach (Floor floor in TargetSystem.Floors)
            {
                systemElements.AddRange(floor.Elements);
                SystemComponentWearingOff(floor.MajorityElement);
            }
            foreach (Element element in systemElements)
            {
                SystemComponentWearingOff(element);
            }
        }

        private void SystemComponentWearingOff(IHardwareComponent component)
        {
            if (component.IsAlive)
            {
                bool componentDown = RandomEvent.Instance.Occured(1 - GetProbability(component.FailureRate));
                if (componentDown)
                    component.IsAlive = false;
            }
        }

        private double GetProbability(Decimal failureRate)
        {
            return Math.Exp(-(double)failureRate * SimulationTime);
        }

        public void SimulateImpact()
        {
            bool impactHappend = RandomEvent.Instance.Occured(ImpactProbability);

            if (impactHappend == true)
            {
                //Debug.WriteLine("Impact happend");
                SpreadFailures();
            }
        }

        private void SpreadFailures()
        {
            IList<IElement> elementsForImpact = GetElementsForImpact();

            //Debug.Write("Impact elements: ");

            for (int i = 0; i < ImpactElementsCount; i++)
            {
                int failedElementIndex = RandomEvent.Instance.RandomInstance.Next(0, elementsForImpact.Count);
                //Debug.Write($"{failedElementIndex} ");
                elementsForImpact[failedElementIndex].IsAlive = false;
            }
            //Debug.Write("\n");
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

        public ControlReconfigurationSystem ControlReconfigurationSystem { get; set; }
        public TargetSystem TargetSystem { get; set; }
        public int ImpactElementsCount { get; set; }
        public double SimulationTime { get; set; }
        public double ImpactProbability { get; set; }
    }
}
