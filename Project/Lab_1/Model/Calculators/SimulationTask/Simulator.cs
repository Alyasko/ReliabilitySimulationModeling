using System;
using System.Diagnostics;
using System.Linq;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask
{
    class Simulator
    {
        private ProbabilityBasket _probabilityBasket;
        private int _recoverCounter;
        private int _successfullRecoverCounter;
        private bool _recoveringIssued;
        private bool _recoveryFailed;

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
            _successfullRecoverCounter = 0;
            _recoverCounter = 0;
            ReconfigurationFailed = false;
            _recoveringIssued = false;
            _recoveryFailed = false;

            for (int i = 0; i < IterationsCount; i++)
            {
                RecoverSystem();
                SimulateIteration();
            }

            if (_recoveringIssued == true)
            {
                if (_successfullRecoverCounter != 0)
                {
                    Status =
                        $"Time: {SimulationTime} h, Average recover attempts: {_recoverCounter/_successfullRecoverCounter}";
                }
                else
                {
                    ReconfigurationFailed = true;
                    Status =
                        $"Time: {SimulationTime} h, All recoveries failed";
                }
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
                _recoveringIssued = true;

                bool successfullReconfig = ControlReconfigurationSystem.ReconfigureSystem();
                //Debug.WriteLine(TargetSystem.Floors.Aggregate("", (s, floor) => s += (int)floor.MajorityElement.Mode + " "));

                if (successfullReconfig == true)
                {
                    _probabilityBasket.Success();
                    _recoverCounter += ControlReconfigurationSystem.RecoverAttemptsCount;
                    _successfullRecoverCounter++;
                }
                else
                {
                    _recoveryFailed = true;
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

        public string Status { get; set; }
        public bool ReconfigurationFailed { get; set; }
    }
}
