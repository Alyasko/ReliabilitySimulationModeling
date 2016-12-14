using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemReliability
{
    class ProbabilityBasket
    {
        private int successfulIterations;
        private int failedIterations;

        public void Success()
        {
            successfulIterations++;
        }

        public void Failed()
        {
            failedIterations++;
        }

        public void Reset()
        {
            successfulIterations = 0;
            failedIterations = 0;
        }

        public double getProbability()
        {
            return successfulIterations / (successfulIterations + failedIterations);
        }
    }
}
