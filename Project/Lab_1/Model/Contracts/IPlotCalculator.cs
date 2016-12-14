using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Model.Contracts
{
    public interface IPlotCalculator
    {
        IDictionary<string, PointF[]> Calculate();
        InputConfig InputConfig { get; set; }
        string Output { get; set; }
    }
}
