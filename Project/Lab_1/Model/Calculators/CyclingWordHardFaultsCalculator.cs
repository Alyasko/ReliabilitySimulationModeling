using System;
using System.Collections.Generic;
using System.Drawing;
using Lab_1.Model.Abstract;

namespace Lab_1.Model.Calculators
{
    public class CyclingWordHardFaultsCalculator : AbstractPlotCalculator
    {
        public CyclingWordHardFaultsCalculator(InputConfig inputConfig) : base(inputConfig)
        {
        }

        public override IDictionary<string, PointF[]> Calculate()
        {
            IDictionary<string, PointF[]> result = new Dictionary<string, PointF[]>();

            Decimal frHwHardFaults = InputConfig.FailureRate1 + InputConfig.FailureRate2 + InputConfig.FailureRate3 +
                                    InputConfig.FailureRate4;
            Decimal frSwHardFaults = frHwHardFaults * InputConfig.AdditionalAlpha;
            Decimal frCompHardFaults = frHwHardFaults + frSwHardFaults;

            Decimal frCompHardFaultsCycle = (1 + (InputConfig.StorageG - 1) * InputConfig.CyclingR) / InputConfig.StorageG * frCompHardFaults;

            Output += "--- Computer ---\n";
            result.Add("Computer", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frCompHardFaultsCycle * j))
                ).ToArray());

            return result;
        }
    }
}