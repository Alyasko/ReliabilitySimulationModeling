using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1.Model.Abstract;
using Lab_1.Model.Calculators.SimulationTask.ReconfigurationAlgorithms;

namespace Lab_1.Model.Calculators.SimulationTask
{
    public class SimulationCalculator : AbstractPlotCalculator
    {
        private Simulator _simulator;

        public SimulationCalculator(InputConfig inputConfig) : base(inputConfig)
        {
            _simulator = new Simulator(inputConfig.SimulationConfig);
            _simulator.IterationsCount = inputConfig.SimulationConfig.ExperimentsCount;
            switch (inputConfig.SimulationConfig.AlgoritmType)
            {
                case ReconfigurationAlgoritmType.MajorityConfigToSingleChannelConfig:
                    _simulator.ReconfigureAlgorithm = new MajorityToSingleReconfigurationAlgorithm();
                    break;
                case ReconfigurationAlgoritmType.SingleChannelConfigToMajorityConfig:
                    _simulator.ReconfigureAlgorithm = new SingleToMajorityReconfigurationAlgorithm();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override IDictionary<string, PointF[]> Calculate()
        {
            IDictionary<string, PointF[]> result = new Dictionary<string, PointF[]>();

            //_simulator.SimulationTime = 0;

            //_simulator.Run();

            int reconfigurationFailsCount = 0;

            PointF[] yfxPointFs = CalculateChartPoints((decimal) InputConfig.SimulationConfig.SimulationTime, 10, (x) =>
            {
                _simulator.SimulationTime = (double) x;

                _simulator.Run();

                if (_simulator.ReconfigurationFailed)
                {
                    reconfigurationFailsCount++;
                }

                Output += _simulator.Status + "\n";

                return _simulator.SuccesOperationProbability;
            }).ToArray();


            Output += $"Reconfiguration failes: {reconfigurationFailsCount}\n";

            //Output += "--- Inherent redundancy reliability growth ---\n";
            result.Add("Y = F(X)", yfxPointFs);

            return result;
        }
    }
}
