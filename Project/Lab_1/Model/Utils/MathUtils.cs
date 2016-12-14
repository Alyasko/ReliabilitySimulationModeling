using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Model.Utils
{
    public static class MathUtils
    {
        public static double Fact(int value)
        {
            int result = 1;

            for (int i = 1; i <= value; i++)
            {
                result = result * i;
            }

            return result;
        }

        public static double GetCFromNbyK(int n, int k)
        {
            return MathUtils.Fact(n)/(MathUtils.Fact(k)*MathUtils.Fact(n - k));
        }
    }
}
