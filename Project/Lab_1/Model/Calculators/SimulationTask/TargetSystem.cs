using System;

namespace Lab_1.Model.Calculators.SimulationTask
{
    public class TargetSystem
    {
        public Floor[] Floors { get; set; }
        public int FloorCount { get; set; }

        public TargetSystem(int floorCount, Decimal elementFailureRate, Decimal majorityElementFailureRate)
        {
            FloorCount = floorCount;
            Floors = new Floor[FloorCount];
            for (int i = 0; i < FloorCount; i++)
                Floors[i] = new Floor(elementFailureRate, majorityElementFailureRate);
        }
    }
}
