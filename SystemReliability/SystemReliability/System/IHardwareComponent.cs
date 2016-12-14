using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemReliability
{
    interface IHardwareComponent : IElement
    {
        public double FailureRate { get; set; }
    }
}
