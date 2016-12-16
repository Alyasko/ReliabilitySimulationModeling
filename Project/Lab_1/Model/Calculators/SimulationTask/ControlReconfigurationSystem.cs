using System;
using System.Diagnostics;
using System.Linq;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask
{
    public class ControlReconfigurationSystem : IHardwareComponent
    {

        public ControlReconfigurationSystem()
        {
            IsAlive = true;
            ReconfigurationAlgorithm = null;
        }

        public ControlReconfigurationSystem(TargetSystem targetSystem, int maximumReconfigurationTime): this()
        {
            MaximumReconfigurationTime = maximumReconfigurationTime;
            TargetSystem = targetSystem;
        }

        public bool CheckSystem()
        {
            if (this.IsAlive == false)
                return false;
            if (CheckMajorityElements() == false)
                return false;
            if (CheckFloorsConfig() == false)
                return false;
            return true;
        }

        private bool CheckMajorityElements()
        {
            foreach (Floor floor in TargetSystem.Floors)
            {
                if (floor.MajorityElement.IsAlive == false)
                    return false;
            }
            return true;
        }

        private bool CheckFloorsConfig()
        {
            foreach (Floor floor in TargetSystem.Floors)
            {
                MajorityElementMode floorMode = floor.MajorityElement.Mode;
                switch (floorMode)
                {
                    case MajorityElementMode.Majority:
                        {
                            int aliveElements = floor.Elements.Count(cc => cc.IsAlive);
                            if (aliveElements < 2)
                                return false;
                            break;
                        }
                    case MajorityElementMode.FirstChannel:
                        {
                            if (floor.Elements[0].IsAlive == false)
                                return false;
                            break;
                        }
                    case MajorityElementMode.SecondChannel:
                        {
                            if (floor.Elements[1].IsAlive == false)
                                return false;
                            break;
                        }
                    case MajorityElementMode.ThirdChannel:
                        {
                            if (floor.Elements[2].IsAlive == false)
                                return false;
                            break;
                        }
                }
            }
            return true;
        }

        public bool ReconfigureSystem()
        {
            bool systemWorks = false;

            int totalConfigurationsForTest = (int) Math.Pow(4, TargetSystem.Floors.Length) - 1;

            int bounds = MaximumReconfigurationTime < totalConfigurationsForTest
                ? MaximumReconfigurationTime
                : totalConfigurationsForTest;

            for (int i = 0; i < bounds; i++)
            {
                ReconfigurationAlgorithm.Reconfigure(TargetSystem);
                //Debug.WriteLine(TargetSystem.Floors.Aggregate("", (s, floor) => s += $"{(int)floor.MajorityElement.Mode}"));
                systemWorks = CheckSystem();
                if (systemWorks == true)
                {
                    break;
                }
            }

            return systemWorks;
        }

        public Decimal FailureRate { get; set; }
        public bool IsAlive { get; set; }
        public IReconfigurationAlgorithm ReconfigurationAlgorithm { get; set; }

        public TargetSystem TargetSystem { get; set; }
        public int MaximumReconfigurationTime { get; set; }
    }
}
