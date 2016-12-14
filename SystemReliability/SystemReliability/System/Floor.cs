using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemReliability
{
    class Floor : IElement
    {
        public bool IsAlive { get; set; }
        public Element[] elements { get; set; }
        public MajorityElement majorityElement { get; set; }

        public Floor(double ElementFailureRate, double majorityElementFailureRate)
        {
            majorityElement = new MajorityElement(majorityElementFailureRate);
            elements = new Element[3];
            for (int i = 0; i < elements.Length; i++)
                elements[i] = new Element(ElementFailureRate);
        }
    }
}
