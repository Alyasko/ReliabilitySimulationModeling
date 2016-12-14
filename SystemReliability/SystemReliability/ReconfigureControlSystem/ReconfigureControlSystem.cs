using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemReliability
{
    class ReconfigureControlSystem : IHardwareComponent
    {
        public double FailureRate { get; set; }
        public bool IsAlive { get; set; }
        private IReconfigureAlgorithm reconfAlgorithm;
        private System system;
        private int reconfigurationTime;

        public ReconfigureControlSystem(double failureRate, IReconfigureAlgorithm reconfAlgorithm, System system, int reconfigurationTime)
        {
            this.FailureRate = failureRate;
            this.reconfAlgorithm = reconfAlgorithm;
            this.system = system;
            this.reconfigurationTime = reconfigurationTime;
            IsAlive = true;
        }

        public bool CheckSystem()
        {        
        }

        public bool ReconfigureSystem()
        {
            reconfAlgorithm.Reconfigure(system);
        }
    }
}
