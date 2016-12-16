using System;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask
{
    class Simulator
    {
        private ProbabilityBasket _probabilityBasket;

        public Simulator(SimulationConfig config)
        {
            _probabilityBasket = new ProbabilityBasket();

            TargetSystem = new TargetSystem(config.NTiersCount, config.LambdaElement, config.LambdaMajorityElement);

            ControlReconfigurationSystem = new ControlReconfigurationSystem(TargetSystem, config.TAcceptableReconfigurationTime);
            ControlReconfigurationSystem.FailureRate = config.LambdaControlReconfigurationSystem;
            ControlReconfigurationSystem.ReconfigurationAlgorithm = ReconfigureAlgorithm;

            FailureInjector = new FailureInjector(TargetSystem, ControlReconfigurationSystem, config.RImpactElementsAffected, SimulationTime, config.ImpactProbability);
        }

        public void Run()
        {
            _probabilityBasket.Reset();

            for (int i = 0; i < IterationsCount; i++)
            {
                RecoverSystem();
                SimulateIteration();
            }

            SuccesOperationProbability = _probabilityBasket.GetProbability();
        }

        public void RecoverSystem()
        {
            ControlReconfigurationSystem.IsAlive = true;
            foreach (Floor floor in TargetSystem.Floors)
            {
                floor.MajorityElement.IsAlive = true;
                floor.MajorityElement.Mode = MajorityElementMode.Majority;
                foreach (Element element in floor.Elements)
                {
                    element.IsAlive = true;
                }
            }
        }

        private void SimulateIteration()
        {
            FailureInjector.SimulationTime = SimulationTime;
            FailureInjector.SimulateWearingOff();
            FailureInjector.SimulateImpact();

            bool systemIsWorking = ControlReconfigurationSystem.CheckSystem();

            if (systemIsWorking == true)
            {
                _probabilityBasket.Success();
            }
            else
            {
                bool successfullReconfig = ControlReconfigurationSystem.ReconfigureSystem();

                if (successfullReconfig == true)
                {
                    _probabilityBasket.Success();
                }
                else
                {
                    _probabilityBasket.Failed();
                }
            }
        }

        public float SuccesOperationProbability { get; set; }
        public double SimulationTime { get; set; }
        public int IterationsCount { get; set; }


        public TargetSystem TargetSystem { get; set; }

        public ControlReconfigurationSystem ControlReconfigurationSystem { get; set; }
        public FailureInjector FailureInjector { get; set; }

        public IReconfigurationAlgorithm ReconfigureAlgorithm
        {
            get { return ControlReconfigurationSystem.ReconfigurationAlgorithm; }
            set { ControlReconfigurationSystem.ReconfigurationAlgorithm = value; }
        }

    }
}
