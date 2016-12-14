using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Abstract
{
    public abstract class AbstractPlotCalculator : IPlotCalculator
    {
        protected AbstractPlotCalculator(InputConfig inputConfig)
        {
            InputConfig = inputConfig;
            Output = "";
        }

        protected List<PointF> CalculateChartPoints(Func<Decimal, float> yFormula)
        {
            return CalculateChartPoints(InputConfig.AdditionalTime, InputConfig.AdditionalDeltaTime, yFormula);
        }

        protected PointF[] CalculateDifferences(PointF[] points1, PointF[] points2)
        {
            List<PointF> resultPoints = new List<PointF>();

            for (int i = 0; i < points1.Length && i < points2.Length; i++)
            {
                float newYValue = points1[i].Y - points2[i].Y;
                resultPoints.Add(new PointF(points1[i].X, newYValue > 0 ? newYValue : 0.0f));
            }

            return resultPoints.ToArray();
        }

        protected List<PointF> CalculateChartPoints(Decimal maxInclusiveValue, Decimal incrementValue, Func<Decimal, float> yFormula)
        {
            List<PointF> points = new List<PointF>();

            for (Decimal j = 0; j <= maxInclusiveValue; j += incrementValue)
            {
                float value = yFormula(j);
                points.Add(new PointF((float)j, value));
                Output += $"Time: {j} h, Reliability: {value}\n";
            }

            return points;
        }

        public abstract IDictionary<string, PointF[]> Calculate();
        public InputConfig InputConfig { get; set; }
        public string Output { get; set; }
    }
}
