using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Model
{
    public class SimulationConfig
    {
        public ReconfigurationAlgoritmType AlgoritmType { get; set; }
        public int NTiersCount { get; set; }
        public Decimal LambdaElement { get; set; }
        public Decimal LambdaMajorityElement { get; set; }
        public Decimal LambdaControlReconfigurationSystem { get; set; }
        public int TAcceptableReconfigurationTime { get; set; }
        public int RImpactElementsAffected { get; set; }
        public double ImpactProbability { get; set; }
        public double SimulationTime { get; set; }
        public int ExperimentsCount { get; set; }
    }
}
