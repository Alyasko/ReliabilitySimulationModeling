using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1.Model.Calculators;
using Lab_1.Model.Calculators.Lab2;
using Lab_1.Model.Calculators.SimulationTask;
using Lab_1.Model.Contracts;

namespace Lab_1.Model
{
    public class ReliabilityAssessor
    {
        public ReliabilityAssessor()
        {

        }

        public IDictionary<string, PointF[]> CalculatePlot(PlotType plotType, InputConfig inputConfig)
        {
            switch (plotType)
            {
                case PlotType.NormalConditionsSoftFaults:
                    PlotCalculator = new NormalConditionsSoftFaultsCalculator(inputConfig);
                    break;
                case PlotType.NormalConditionsHardFaults:
                    PlotCalculator = new NormalConditionsHardFaultsCalculator(inputConfig);
                    break;
                case PlotType.NormalConditionsErrors:
                    PlotCalculator = new NormalConditionsErrorsCalculator(inputConfig);
                    break;
                case PlotType.CriticalConditionsHardFaults:
                    PlotCalculator = new CriticalConditionsHardFaultsCalculator(inputConfig);
                    break;
                case PlotType.CyclingWordHardFaults:
                    PlotCalculator = new CyclingWordHardFaultsCalculator(inputConfig);
                    break;
                case PlotType.ComparisonHardFaults:
                    PlotCalculator = new ComparisonHardFaultsCalculator(inputConfig);
                    break;
                case PlotType.Undefined:
                    PlotCalculator = new L2Task1PassiveRedundancy(inputConfig);
                    break;
                case PlotType.L2PassiveRedundancy:
                    PlotCalculator = new L2Task1PassiveRedundancy(inputConfig);
                    break;
                case PlotType.L2MajorRedundancy:
                    PlotCalculator = new L2Task2MajorRedundanty(inputConfig);
                    break;
                case PlotType.L2DynamicRedundancy:
                    PlotCalculator = new L2Task3DynamicRedundancy(inputConfig);
                    break;
                case PlotType.SimulationModeling:
                    PlotCalculator = new SimulationCalculator(inputConfig);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(plotType), plotType, null);
            }

            var result = PlotCalculator.Calculate();

            Output = PlotCalculator.Output;

            return result;
        }

        public String Output { get; set; }

        public IPlotCalculator PlotCalculator { get; set; }
    }
}
