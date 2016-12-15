using System;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask
{
    public class MajorityElement : IHardwareComponent
    {
        public Decimal FailureRate { get; set; }
        public bool IsAlive { get; set; }
        public MajorityElementMode Mode { get; set; }

        public MajorityElement(Decimal majorityElementFailureRate)
        {
            FailureRate = majorityElementFailureRate;
            Mode = MajorityElementMode.Majority;
            IsAlive = true;
        }
    }
}
