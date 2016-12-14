using System;
using System.Collections.Generic;
using System.Drawing;
using Lab_1.Model.Abstract;

namespace Lab_1.Model.Calculators
{
    public class ComparisonHardFaultsCalculator : AbstractPlotCalculator
    {
        public ComparisonHardFaultsCalculator(InputConfig inputConfig) : base(inputConfig)
        {
        }

        public override IDictionary<string, PointF[]> Calculate()
        {
            IDictionary<string, PointF[]> result = new Dictionary<string, PointF[]>();

            Decimal frHwHardFaults = InputConfig.FailureRate1 + InputConfig.FailureRate2 + InputConfig.FailureRate3 +
                                    InputConfig.FailureRate4;
            Decimal frSwHardFaults = frHwHardFaults * InputConfig.AdditionalAlpha;
            Decimal frCompHardFaults = frHwHardFaults + frSwHardFaults;

            Decimal frHwHardFaultsEnv = frHwHardFaults * InputConfig.EnvironmentCoeffOverload
                            * InputConfig.EnvironmentCoeffTemperature
                            * InputConfig.EnvironmentCoeffVibration;

            Decimal frCompHardFaultsEnv = frHwHardFaultsEnv + frSwHardFaults;
            Decimal frCompHardFaultsCycle = (1 + (InputConfig.StorageG - 1) * InputConfig.CyclingR) / InputConfig.StorageG * frCompHardFaults;

            Output += "--- Computer critical cond. ---\n";
            result.Add("Computer critical cond.", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frCompHardFaultsEnv * j))
                ).ToArray());

            Output += "--- Computer cyclic work ---\n";
            result.Add("Computer cyclic work", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frCompHardFaultsCycle * j))
                ).ToArray());

            Output += "--- Computer normal cond. ---\n";
            result.Add("Computer normal cond.", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frCompHardFaults * j))
                ).ToArray());

            return result;
        }
    }
}