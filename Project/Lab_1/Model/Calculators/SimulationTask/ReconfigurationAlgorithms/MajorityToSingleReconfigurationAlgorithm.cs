using System;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask.ReconfigurationAlgorithms
{
    class MajorityToSingleReconfigurationAlgorithm : AbstractReconfigurationAlgorithm
    {
        private int _depth;

        public override void Reconfigure(TargetSystem targetSystem)
        {
            TargetSystem = targetSystem;
            _depth = targetSystem.Floors.Length;
            ShouldIncrement(0);
        }

        private bool ShouldIncrement(int currentDepth)
        {
            bool result = false;

            if (currentDepth >= _depth - 1)
            {
                MajorityElementMode oldMode = TargetSystem.Floors[currentDepth].MajorityElement.Mode;
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
                    MajorityElementMode oldMode = TargetSystem.Floors[currentDepth].MajorityElement.Mode;
                    MajorityElementMode newMode = IncrementFloorMajorityElementMode(currentDepth);

                    if (newMode == MajorityElementMode.Majority && oldMode == MajorityElementMode.ThirdChannel)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
