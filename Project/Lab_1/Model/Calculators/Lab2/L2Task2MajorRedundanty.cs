using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1.Model.Abstract;
using Lab_1.Model.Utils;

namespace Lab_1.Model.Calculators.Lab2
{
    public class L2Task2MajorRedundanty : AbstractPlotCalculator
    {
        public L2Task2MajorRedundanty(InputConfig inputConfig) : base(inputConfig)
        {
        }

        public override IDictionary<string, PointF[]> Calculate()
        {
            IDictionary<string, PointF[]> result = new Dictionary<string, PointF[]>();

            PointF[] mainNotReservedSystemPoints = CalculateChartPoints(InputConfig.L2T, 10,
                (j) => (float)Math.Exp((double)(-InputConfig.L2N * InputConfig.L2LamdaI * j))
                ).ToArray();



            PointF[] massiveMajorRedundancyPoints =
                CalculateChartPoints(InputConfig.L2T, 10,
                    (j) =>
                    {
                        double channelReliability = (double)(Math.Exp((double)(-InputConfig.L2LamdaI * InputConfig.L2N * j)));

                        double innerSum = 0;
                        int m = (int)(InputConfig.L2M);
                        for (int i = (m + 1) / 2; i <= m; i++)
                        {
                            innerSum += MathUtils.GetCFromNbyK(m, i)
                                        * Math.Pow(channelReliability, i) * Math.Pow((1.0 - channelReliability), m - i);
                        }

                        double meReliability = Math.Exp(-(double)(InputConfig.L2LamdaME * j));

                        double resultReliability = meReliability * innerSum;

                        return (float)resultReliability;
                    }
                    ).ToArray();

            PointF[] massiveMajorRedundancyGrowth = CalculateDifferences(massiveMajorRedundancyPoints,
                mainNotReservedSystemPoints);

            PointF[] inherentMajorRedundancyPoints =
                CalculateChartPoints(InputConfig.L2T, 10,
                    (t) =>
                    {
                        double elementReliability = (double)(Math.Exp((double)(-InputConfig.L2LamdaI * t)));

                        double resultReliability = 1.0;
                        double innerSum = 0;
                        int m = (int) (InputConfig.L2M);

                        double meReliability = Math.Exp(-(double)(InputConfig.L2LamdaME* t));

                        for (int i = 1; i <= InputConfig.L2N; i++)
                        {
                            innerSum = 0;
                            for (int j = (m + 1) / 2; j <= m; j++)
                            {
                                innerSum += MathUtils.GetCFromNbyK(m, j)
                                            * Math.Pow(elementReliability, j) * Math.Pow((1.0 - elementReliability), m - j);
                            }
                            resultReliability *= (meReliability * innerSum);
                        }
                        return (float) resultReliability;
                    }
                    ).ToArray();

            PointF[] inherentMajorRedundancyGrowth = CalculateDifferences(inherentMajorRedundancyPoints,
                mainNotReservedSystemPoints);


            Output += "--- Main system, not reserved ---\n";
            result.Add("Main system, not reserved", mainNotReservedSystemPoints);

            Output += "--- Massive major redundancy, reserved ---\n";
            result.Add("Massive major redundancy, reserved", massiveMajorRedundancyPoints);

            Output += "--- Inherent major redundancy, reserved ---\n";
            result.Add("Inherent major redundancy, reserved", inherentMajorRedundancyPoints);


            Output += "--- Massive major redundancy growth ---\n";
            result.Add("Massive major redundancy growth", massiveMajorRedundancyGrowth);

            Output += "--- Inherent major redundancy growth ---\n";
            result.Add("Inherent major redundancy growth", inherentMajorRedundancyGrowth);

            if (InputConfig.L2M == 3)
            {
                PointF[] adaptiveMajorRedundancyPoints =
                    CalculateChartPoints(InputConfig.L2T, 10,
                        (t) =>
                        {
                            double meReliability = Math.Exp(-(double)(InputConfig.L2LamdaME * t));
                            double channelReliability = (double)(Math.Exp((double)(-InputConfig.L2LamdaI * InputConfig.L2N * t)));

                            double resultReliability = (3 * channelReliability * channelReliability - 2 * channelReliability * channelReliability * channelReliability
                                + 3 * channelReliability * (1 - channelReliability) * (1 - channelReliability)) * meReliability;
   
                            return (float) resultReliability;
                        }
                        ).ToArray();

                PointF[] adaptiveMajorRedundancyGrowth = CalculateDifferences(adaptiveMajorRedundancyPoints,
                mainNotReservedSystemPoints);

                Output += "--- Adaptive major redundancy reliability ---\n";
                result.Add("Adaptive major redundancy reliability", adaptiveMajorRedundancyPoints);

                Output += "--- Adaptive major redundancy reliability growth ---\n";
                result.Add("Adaptive major redundancy reliability growth", adaptiveMajorRedundancyGrowth);
            }

            return result;
        }
    }
}
