using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Model
{
    public class InputConfig
    {
        public decimal L2LamdaPU { get; set; }
        public decimal L2LamdaOP { get; set; }
        public Decimal L2LamdaNP { get; set; }
        public Decimal FailureRate1 { get; set; }
        public Decimal FailureRate2 { get; set; }
        public Decimal FailureRate3 { get; set; }
        public Decimal FailureRate4 { get; set; }

        public Decimal AdditionalAlpha { get; set; }
        public Decimal AdditionalBeta { get; set; }
        public Decimal AdditionalTime { get; set; }
        public Decimal AdditionalGama { get; set; }
        public Decimal AdditionalDeltaTime { get; set; }

        public Decimal EnvironmentCoeffTemperature { get; set; }
        public Decimal EnvironmentCoeffVibration { get; set; }
        public Decimal EnvironmentCoeffOverload { get; set; }

        public Decimal StorageTime { get; set; }
        public Decimal StorageG { get; set; }

        public Decimal CyclingTime { get; set; }
        public Decimal CyclingR { get; set; }

        public Decimal L2CyclingR { get; set; }
        public decimal L2LamdaI { get; set; }
        public decimal L2LamdaME { get; set; }
        public decimal L2T { get; set; }
        public decimal L2M { get; set; }
        public decimal L2N { get; set; }

        public SimulationConfig SimulationConfig { get; set; }
    }
}
