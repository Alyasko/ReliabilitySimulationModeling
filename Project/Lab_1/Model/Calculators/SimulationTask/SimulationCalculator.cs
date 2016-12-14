using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1.Model.Abstract;

namespace Lab_1.Model.Calculators.SimulationTask
{
    public class SimulationCalculator : AbstractPlotCalculator
    {
        public SimulationCalculator(InputConfig inputConfig) : base(inputConfig)
        {
        }

        public override IDictionary<string, PointF[]> Calculate()
        {
            IDictionary<string, PointF[]> result = new Dictionary<string, PointF[]>();

            PointF[] yfxPointFs = CalculateChartPoints(InputConfig.L2T, 10,
                (x) => (float)(x*x)
                ).ToArray();

            
            //Output += "--- Inherent redundancy reliability growth ---\n";
            result.Add("Y = F(X)", yfxPointFs);

            return result;
        }
    }
}
