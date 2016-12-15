using Lab_1.Model.Calculators.SimulationTask;

namespace Lab_1.Model.Contracts
{
    public interface IReconfigurationAlgorithm
    {
        void Reconfigure(TargetSystem targetSystem);
    }
}
