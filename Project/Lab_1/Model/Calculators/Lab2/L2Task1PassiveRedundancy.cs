using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1.Model.Abstract;

namespace Lab_1.Model.Calculators.Lab2
{
    public class L2Task1PassiveRedundancy : AbstractPlotCalculator
    {
        public L2Task1PassiveRedundancy(InputConfig inputConfig) : base(inputConfig)
        {
        }

        public override IDictionary<string, PointF[]> Calculate()
        {
            IDictionary<string, PointF[]> result = new Dictionary<string, PointF[]>();

            PointF[] mainNotReservedSystemPoints = CalculateChartPoints(InputConfig.L2T, 10,
                (j) => (float)Math.Exp((double)(-InputConfig.L2N * InputConfig.L2LamdaI * j))
                ).ToArray();



            PointF[] massiveRedundancyPoints =
                CalculateChartPoints(InputConfig.L2T, 10,
                    (j) =>
                    {
                        return
                            (float)
                                (1 -
                                 Math.Pow(
                                     1 -
                                     Math.Exp(
                                         (double)(-InputConfig.L2N * InputConfig.L2LamdaI * j)),
                                     (double)(InputConfig.L2M + 1)));
                    }
                    ).ToArray();

            PointF[] reliabilityGrowthUsingMassiveRedundancy = CalculateDifferences(massiveRedundancyPoints,
                mainNotReservedSystemPoints);

            PointF[] inherentRedundancyPoints =
                CalculateChartPoints(InputConfig.L2T, 10,
                    (j) =>
                    {
                        return
                            (float)
                                Math.Pow(
                                    1 -
                                    Math.Pow(1 - Math.Exp((double)(-InputConfig.L2LamdaI * j)),
                                        (double)(InputConfig.L2M + 1)), (double)InputConfig.L2N);
                    }
                    ).ToArray();

            PointF[] reliabilityGrowthUsingInherentRedundancy = CalculateDifferences(inherentRedundancyPoints,
                mainNotReservedSystemPoints);

            Output += "--- Main system, not reserved ---\n";
            result.Add("Main system, not reserved", mainNotReservedSystemPoints);

            Output += "--- Massive redundancy, reserved ---\n";
            result.Add("Massive redundancy, reserved", massiveRedundancyPoints);

            Output += "--- Inherent redundancy, reserved ---\n";
            result.Add("Inherent redundancy, reserved", inherentRedundancyPoints);

            Output += "--- Massive redundancy reliability growth ---\n";
            result.Add("Massive redundancy reliability growth", reliabilityGrowthUsingMassiveRedundancy);

            Output += "--- Inherent redundancy reliability growth ---\n";
            result.Add("Inherent redundancy reliability growth", reliabilityGrowthUsingInherentRedundancy);

            return result;
        }
    }
}
