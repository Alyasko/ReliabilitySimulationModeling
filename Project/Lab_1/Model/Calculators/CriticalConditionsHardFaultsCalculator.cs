using System;
using System.Collections.Generic;
using System.Drawing;
using Lab_1.Model.Abstract;

namespace Lab_1.Model.Calculators
{
    public class CriticalConditionsHardFaultsCalculator : AbstractPlotCalculator
    {
        public CriticalConditionsHardFaultsCalculator(InputConfig inputConfig) : base(inputConfig)
        {
        }

        public override IDictionary<string, PointF[]> Calculate()
        {
            IDictionary<string, PointF[]> result = new Dictionary<string, PointF[]>();

            Decimal frHwHardFaults = (InputConfig.FailureRate1 + InputConfig.FailureRate2 + InputConfig.FailureRate3 +
                                      InputConfig.FailureRate4);

            Decimal frHwHardFaultsEnv = frHwHardFaults * InputConfig.EnvironmentCoeffOverload
                                        * InputConfig.EnvironmentCoeffTemperature
                                        * InputConfig.EnvironmentCoeffVibration;

            Decimal frSwHardFaults = frHwHardFaults * InputConfig.AdditionalAlpha;
            Decimal frCompHardFaultsEnv = frHwHardFaultsEnv + frSwHardFaults;

            Output += "--- Hardware ---\n";
            result.Add("Hardware", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frHwHardFaultsEnv * j))
                ).ToArray());

            Output += "--- Software ---\n";
            result.Add("Software", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frSwHardFaults * j))
                ).ToArray());

            Output += "--- Computer ---\n";
            result.Add("Computer", CalculateChartPoints(
                (j) => (float)Math.Exp((double)(-frCompHardFaultsEnv * j))
                ).ToArray());

            return result;
        }
    }
}