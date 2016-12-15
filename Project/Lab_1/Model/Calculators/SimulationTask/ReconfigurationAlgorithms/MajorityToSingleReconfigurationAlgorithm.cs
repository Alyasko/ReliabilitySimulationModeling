using System;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask.ReconfigurationAlgorithms
{
    class MajorityToSingleReconfigurationAlgorithm : IReconfigurationAlgorithm
    {
        private int _depth;
        private TargetSystem _targetSystem;

        public void Reconfigure(TargetSystem targetSystem)
        {
            _targetSystem = targetSystem;
            _depth = targetSystem.Floors.Length;
            ShouldIncrement(0);
        }

        private bool ShouldIncrement(int currentDepth)
        {
            bool result = false;

            if (currentDepth >= _depth - 1)
            {
                MajorityElementMode oldMode = _targetSystem.Floors[currentDepth].MajorityElement.Mode;
                MajorityElementMode newMode = IncrementFloorMajorityElementMode(currentDepth);

                if (newMode == MajorityElementMode.Majority && oldMode == MajorityElementMode.ThirdChannel)
                {
                    result = true;
                }
            }
            else
            {
                bool shouldIncrement = ShouldIncrement(currentDepth + 1);
                if (shouldIncrement == true)
                {
                    MajorityElementMode oldMode = _targetSystem.Floors[currentDepth].MajorityElement.Mode;
                    MajorityElementMode newMode = IncrementFloorMajorityElementMode(currentDepth);

                    if (newMode == MajorityElementMode.Majority && oldMode == MajorityElementMode.ThirdChannel)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        private MajorityElementMode IncrementFloorMajorityElementMode(int floorIndex)
        {
            MajorityElementMode majorityElementMode = _targetSystem.Floors[floorIndex].MajorityElement.Mode;
            _targetSystem.Floors[floorIndex].MajorityElement.Mode = IncrementMajorityMode(majorityElementMode);

            return _targetSystem.Floors[floorIndex].MajorityElement.Mode;
        }

        private MajorityElementMode IncrementMajorityMode(MajorityElementMode currentValue)
        {
            return (MajorityElementMode)
                (((int) currentValue + 1)%Enum.GetNames(typeof(MajorityElementMode)).Length);
        }
    }
}
