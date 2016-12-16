using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask.ReconfigurationAlgorithms
{
    public abstract class AbstractReconfigurationAlgorithm : IReconfigurationAlgorithm
    {
        protected TargetSystem TargetSystem;

        protected MajorityElementMode IncrementFloorMajorityElementMode(int floorIndex)
        {
            MajorityElementMode majorityElementMode = TargetSystem.Floors[floorIndex].MajorityElement.Mode;
            TargetSystem.Floors[floorIndex].MajorityElement.Mode = IncrementMajorityMode(majorityElementMode);

            return TargetSystem.Floors[floorIndex].MajorityElement.Mode;
        }

        protected MajorityElementMode IncrementMajorityMode(MajorityElementMode currentValue)
        {
            return (MajorityElementMode)
                (((int)currentValue + 1) % Enum.GetNames(typeof(MajorityElementMode)).Length);
        }

        public abstract void Reconfigure(TargetSystem targetSystem);
    }
}
