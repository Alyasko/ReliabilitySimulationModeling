using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemReliability
{
    class System
    {
        public Floor[] Floors { get; set; }
        public int FloorCount { get; set; }

        public System(int floorCount, double elementFailureRate, double majorityElementFailureRate)
        {
            FloorCount = floorCount;
            Floors = new Floor[FloorCount];
            for (int i = 0; i < FloorCount; i++)
                Floors[i] = new Floor(elementFailureRate, majorityElementFailureRate);
        }
    }
}
