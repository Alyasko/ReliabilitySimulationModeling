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
            TargetSystem.Floors[floorIndex].MajorityElement.Mode = ChangeMajorityMode(majorityElementMode, true);

            return TargetSystem.Floors[floorIndex].MajorityElement.Mode;
        }

        protected MajorityElementMode DecrementFloorMajorityElementMode(int floorIndex)
        {
            MajorityElementMode majorityElementMode = TargetSystem.Floors[floorIndex].MajorityElement.Mode;
            TargetSystem.Floors[floorIndex].MajorityElement.Mode = ChangeMajorityMode(majorityElementMode, false);

            return TargetSystem.Floors[floorIndex].MajorityElement.Mode;
        }

        protected MajorityElementMode ChangeMajorityMode(MajorityElementMode currentValue, bool increment)
        {
            int period = Enum.GetNames(typeof(MajorityElementMode)).Length;
            if (increment)
            {
                return (MajorityElementMode)
                    (((int) currentValue + 1)%period);
            }
            else
            {
                return (MajorityElementMode)
                    (((int) currentValue + period - 1)%period);
            }
        }

        public abstract void Reconfigure(TargetSystem targetSystem);
    }
}
