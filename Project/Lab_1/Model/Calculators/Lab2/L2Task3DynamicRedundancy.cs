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
    public class L2Task3DynamicRedundancy : AbstractPlotCalculator
    {
        public L2Task3DynamicRedundancy(InputConfig inputConfig) : base(inputConfig)
        {

        }

        public override IDictionary<string, PointF[]> Calculate()
        {
            IDictionary<string, PointF[]> result = new Dictionary<string, PointF[]>();

            PointF[] mainNotReservedSystemPoints = CalculateChartPoints(InputConfig.L2T, 10,
                (j) => (float)Math.Exp((double)(-InputConfig.L2N * InputConfig.L2LamdaI * j))
                ).ToArray();

            PointF[] coldRedundancy =
                CalculateChartPoints(InputConfig.L2T, 10,
                    (t) =>
                    {
                        double selectorReliability = Math.Exp(-(double)(InputConfig.L2LamdaPU * t));
                        double elementReliability = (double)(Math.Exp((double)(-InputConfig.L2LamdaI * t)));

                        double innerSum = 0;
                        int m = (int)(InputConfig.L2M);
                        for (int i = 0; i <= m; i++)
                        {
                            innerSum += Math.Pow((double) (InputConfig.L2LamdaI * t), i) / MathUtils.Fact(i);
                        }

                        double resultReliability = elementReliability * (innerSum) * selectorReliability;

                        return (float)resultReliability;
                    }
                    ).ToArray();

            PointF[] warmRedundancy =
                CalculateChartPoints(InputConfig.L2T, 10,
                    (t) =>
                    {
                        double selectorReliability = Math.Exp(-(double)(InputConfig.L2LamdaPU * t));
                        double elementReliability = (double)(Math.Exp((double)(-InputConfig.L2LamdaI * t)));
                        double warmElemenetReliability = (double)(Math.Exp((double)(-InputConfig.L2LamdaOP * t)));

                        double innerSum = 0;
                        int m = (int) (InputConfig.L2M);
                        for (int i = 1; i <= m; i++)
                        {
                            double multiplication = 1;
                            for (int j = 0; j <= i - 1; j++)
                            {
                                multiplication *= (double) (InputConfig.L2LamdaI/InputConfig.L2LamdaOP);
                            }

                            
                            innerSum += multiplication / MathUtils.Fact(i) * (Math.Pow(1 - warmElemenetReliability, i));
                        }

                        double resultReliability = elementReliability * (1 + innerSum )* selectorReliability;

                        return (float)resultReliability;
                    }
                    ).ToArray();

            PointF[] hotRedundancy =
                CalculateChartPoints(InputConfig.L2T, 10,
                    (t) =>
                    {
                        double selectorReliability = Math.Exp(-(double)(InputConfig.L2LamdaPU * t));

                        return (float) ((float)
                            (1 -
                             Math.Pow(
                                 1 -
                                 Math.Exp(
                                     (double)(-InputConfig.L2N * InputConfig.L2LamdaI * t)),
                                 (double)(InputConfig.L2M + 1))) * selectorReliability);
                    }
                    ).ToArray();

            PointF[] movingRedundancy =
                CalculateChartPoints(InputConfig.L2T, 10,
                    (t) =>
                    {
                        double selectorReliability = Math.Exp(-(double)(InputConfig.L2LamdaPU * t));
                        double elementReliability = (double)(Math.Exp((double)(-InputConfig.L2LamdaI * t)));

                        double innerSum = 0;
                        int m = (int)(InputConfig.L2M);
                        int n = (int)(InputConfig.L2LamdaNP);
                        //for (int i = 0; i <= m; i++)
                        //{
                        //    innerSum += MathUtils.GetCFromNbyK(n + m, i) * Math.Pow(elementReliability,n + m - i) * Math.Pow(1 - elementReliability, i);
                        //}
                        for (int i = n; i <= m + n; i++)
                        {

                            innerSum += MathUtils.GetCFromNbyK(n + m, i) * Math.Pow(elementReliability, i) * Math.Pow(1 - elementReliability, n + m - i);
                        }

                        double resultReliability = innerSum * selectorReliability;

                        return (float)resultReliability;
                    }
                    ).ToArray();

            Output += "--- Main system, not reserved ---\n";
            result.Add("Main system, not reserved", mainNotReservedSystemPoints);

            Output += "--- Cold redundancy, reserved ---\n";
            result.Add("Cold redundancy, reserved", coldRedundancy);

            Output += "--- Warm redundancy, reserved ---\n";
            result.Add("Warm redundancy, reserved", warmRedundancy);

            Output += "--- Hot redundancy, reserved ---\n";
            result.Add("Hot redundancy, reserved", hotRedundancy);

            Output += "--- Moving redundancy, reserved ---\n";
            result.Add("Moving redundancy, reserved", movingRedundancy);

            return result;
        }
    }
}
