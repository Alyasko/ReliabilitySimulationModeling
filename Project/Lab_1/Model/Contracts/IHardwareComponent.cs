using System;

namespace Lab_1.Model.Contracts
{
    public interface IHardwareComponent : IElement
    {
        Decimal FailureRate { get; set; }
    }
}
