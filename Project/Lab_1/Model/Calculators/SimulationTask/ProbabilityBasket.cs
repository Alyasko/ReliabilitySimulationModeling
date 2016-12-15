namespace Lab_1.Model.Calculators.SimulationTask
{
    public class ProbabilityBasket
    {
        private int _successfulIterations;
        private int _failedIterations;

        public ProbabilityBasket()
        {
            Reset();
        }

        public void Success()
        {
            _successfulIterations++;
        }

        public void Failed()
        {
            _failedIterations++;
        }

        public void Reset()
        {
            _successfulIterations = 0;
            _failedIterations = 0;
        }

        public float GetProbability()
        {
            float result = 1;
            int totalCount = _successfulIterations + _failedIterations;
            if (totalCount != 0)
            {
                result = _successfulIterations/(float)totalCount;
            }
            return result;
        }
    }
}
