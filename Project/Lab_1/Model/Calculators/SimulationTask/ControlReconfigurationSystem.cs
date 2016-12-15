using System;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask
{
    public class ControlReconfigurationSystem : IHardwareComponent
    {

        public ControlReconfigurationSystem()
        {
            IsAlive = true;
            ReconfigureAlgorithm = null;
        }

        public ControlReconfigurationSystem(TargetSystem targetSystem, int maximumReconfigurationTime): this()
        {
            MaximumReconfigurationTime = maximumReconfigurationTime;
            TargetSystem = targetSystem;
        }

        public bool CheckSystem()
        {
            return true;
        }

        public bool ReconfigureSystem()
        {
            return true;
        }

        public Decimal FailureRate { get; set; }
        public bool IsAlive { get; set; }
        public IReconfigurationAlgorithm ReconfigureAlgorithm { get; set; }

        public TargetSystem TargetSystem { get; set; }
        public int MaximumReconfigurationTime { get; set; }
    }
}
