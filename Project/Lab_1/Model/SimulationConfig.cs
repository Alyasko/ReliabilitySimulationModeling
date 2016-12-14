using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Model
{
    public class SimulationConfig
    {
        public AlgoritmType AlgoritmType { get; set; }
        public Decimal NTiersCount { get; set; }
        public Decimal LambdaElement { get; set; }
        public Decimal LambdaMajorityElement { get; set; }
        public Decimal LambdaControlReconfigurationSystem { get; set; }
        public Decimal TAcceptableReconfigurationTime { get; set; }
        public Decimal RImpactElementsAffected { get; set; }
        public Decimal TImpactStep { get; set; }
        public Decimal SimulationTime { get; set; }
    }
}
