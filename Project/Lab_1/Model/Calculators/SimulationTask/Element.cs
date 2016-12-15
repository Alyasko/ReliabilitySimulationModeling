using System;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask
{
    public class Element : IHardwareComponent
    {
        public Decimal FailureRate { get; set; }
        public bool IsAlive { get; set; }

        public Element(Decimal failureRate)
        {
            FailureRate = failureRate;
            IsAlive = true;
        }
    }
}
