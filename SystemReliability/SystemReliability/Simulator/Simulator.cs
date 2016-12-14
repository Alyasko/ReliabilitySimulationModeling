using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemReliability
{
    class Simulator
    {
        private float succesOperationProbability; //Зачем, если мы возвращаем значение из ProbabilityBasket
        private System system;
        private ReconfigureControlSystem RCS;
        private FailureInjector failureInjector;
        private IReconfigureAlgorithm reconfigureAlgorithm;

        public Simulator(SimulatorConfig config)
        {
            switch (config.ReconfMode)
            {
                case ReconfigureMode.MK_OK: { reconfigureAlgorithm = new MK_OK_Algorithm(); break; }
                case ReconfigureMode.OK_MK: { reconfigureAlgorithm = new OK_MK_Algorithm(); break; }
                default: break;
            }
            system = new System(config.FloorCount, config.ElementFailureRate, config.MajorityElementFailureRate);
            RCS = new ReconfigureControlSystem(config.RCSFailureRate, reconfigureAlgorithm, system, config.ReconfigureTime);
            failureInjector = new FailureInjector(system, config.ImpactElementsCount, config.SimulationTime, config.ImpactProbability);

        }

        public float Run()
        { }
    }
}
