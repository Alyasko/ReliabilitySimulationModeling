using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Model.Calculators.SimulationTask
{
    /// <summary>
    /// Usage: RandomEvent.Instance.Occured(0.01)
    /// </summary>
    public class RandomEvent
    {
        private Random _random;

        public RandomEvent()
        {
            _random = new Random();
        }

        public bool Occured(double probability)
        {
            return _random.NextDouble() <= probability;
        }

        public Random RandomInstance
        {
            get { return _random; }
        }

        private static Lazy<RandomEvent> _randomEvent = new Lazy<RandomEvent>();

        public static RandomEvent Instance
        {
            get { return _randomEvent.Value; }
        }
    }
}
