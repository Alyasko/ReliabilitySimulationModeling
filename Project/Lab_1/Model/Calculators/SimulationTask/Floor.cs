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
            IsAlive = true;

            for (int i = 0; i < Elements.Length; i++)
            {
                Element element = new Element(elementFailureRate);
                Elements[i] = element;

            }
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
