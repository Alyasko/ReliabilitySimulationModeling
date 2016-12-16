using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask.ReconfigurationAlgorithms
{
    public class SingleToMajorityReconfigurationAlgorithm : AbstractReconfigurationAlgorithm
    {
        private int _depth;
        private bool _thirdChannelsSet;

        public SingleToMajorityReconfigurationAlgorithm()
        {
            _thirdChannelsSet = false;
        }

        public override void Reconfigure(TargetSystem targetSystem)
        {
            TargetSystem = targetSystem;
            _depth = targetSystem.Floors.Length;

            if (_thirdChannelsSet == false)
            {
                SetAllToThirdChannel();
                _thirdChannelsSet = true;
            }

            ShouldIncrement(0);
        }

        private void SetAllToThirdChannel()
        {
            foreach (Floor floor in TargetSystem.Floors)
            {
                floor.MajorityElement.Mode = MajorityElementMode.ThirdChannel;
            }
        }

        private bool ShouldIncrement(int currentDepth)
        {
            bool result = false;

            if (currentDepth >= _depth - 1)
            {
                MajorityElementMode oldMode = TargetSystem.Floors[currentDepth].MajorityElement.Mode;
                MajorityElementMode newMode = DecrementFloorMajorityElementMode(currentDepth);

                if (newMode == MajorityElementMode.ThirdChannel && oldMode == MajorityElementMode.Majority)
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
                    MajorityElementMode newMode = DecrementFloorMajorityElementMode(currentDepth);

                    if (newMode == MajorityElementMode.ThirdChannel && oldMode == MajorityElementMode.Majority)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
