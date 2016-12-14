using System;
using System.Collections.Generic;
using System.Drawing;
using Lab_1.Model.Abstract;

namespace Lab_1.Model.Calculators
{
    public class NormalConditionsErrorsCalculator : AbstractPlotCalculator
    {
        public NormalConditionsErrorsCalculator(InputConfig inputConfig) : base(inputConfig)
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

            result.Add("Hardware", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frHwErrors * j))
                ).ToArray());

            result.Add("Software", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frSwErrors * j))
                ).ToArray());


            result.Add("Computer", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frCompErrors * j))
                ).ToArray());

            return result;
        }
    }
}