using System;
using System.Collections.Generic;
using System.Drawing;
using Lab_1.Model.Abstract;

namespace Lab_1.Model.Calculators
{
    public class NormalConditionsSoftFaultsCalculator : AbstractPlotCalculator
    {
        public NormalConditionsSoftFaultsCalculator(InputConfig inputConfig) : base(inputConfig)
        {
        }

        public override IDictionary<string, PointF[]> Calculate()
        {
            IDictionary<string, PointF[]> result = new Dictionary<string, PointF[]>();

            Decimal frHwHardFaults = InputConfig.FailureRate1 + InputConfig.FailureRate2 + InputConfig.FailureRate3 +
                                    InputConfig.FailureRate4;
            Decimal frHwSoftFaults = frHwHardFaults * InputConfig.AdditionalBeta;
            Decimal frSwSoftFaults = frHwSoftFaults * InputConfig.AdditionalAlpha;
            Decimal frHwErrors = frHwHardFaults + frHwSoftFaults;
            Decimal frSwErrors = frHwErrors * InputConfig.AdditionalAlpha;
            Decimal frCompHardFaults = frHwHardFaults + frHwHardFaults * InputConfig.AdditionalAlpha;
            Decimal frCompSoftFaults = frHwSoftFaults + frHwSoftFaults * InputConfig.AdditionalAlpha;
            Decimal frCompErrors = frHwErrors + frSwErrors;

            Output += "--- Hardware ---\n";
            result.Add("Hardware", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frHwSoftFaults * j))
                ).ToArray());

            Output += "--- Software ---\n";
            result.Add("Software", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frSwSoftFaults * j))
                ).ToArray());

            Output += "--- Computer ---\n";
            result.Add("Computer", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frCompSoftFaults * j))
                ).ToArray());

            return result;
        }
    }
}