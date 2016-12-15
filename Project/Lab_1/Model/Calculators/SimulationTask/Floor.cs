using System;
using Lab_1.Model.Contracts;

namespace Lab_1.Model.Calculators.SimulationTask
{
    public class Floor : IElement
    {
        public Floor(Decimal elementFailureRate, Decimal majorityElementFailureRate)
        {
            MajorityElement = new MajorityElement(majorityElementFailureRate);
            Elements = new Element[3];

            for (int i = 0; i < Elements.Length; i++)
                Elements[i] = new Element(elementFailureRate);
        }

        public bool IsAlive { get; set; }
        public Element[] Elements { get; set; }
        public MajorityElement MajorityElement { get; set; }

        public override string ToString()
        {
            return $"Mode: {MajorityElement.Mode}";
        }
    }
}
