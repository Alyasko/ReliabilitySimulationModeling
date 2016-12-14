using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Model
{
    public enum PlotType
    {
        Undefined = -1,
        NormalConditionsSoftFaults = 0,     // Normal conditions - soft faults (hardware, software, computer)
        NormalConditionsHardFaults = 1,     // Normal conditions - hard faults (hardware, software, computer)
        NormalConditionsErrors = 2,         // Normal conditions - errors (hardware, software, computer)
        CriticalConditionsHardFaults = 3,   // Critical conditions - hard faults (computer)
        CyclingWordHardFaults = 4,          // Cycling work - hard faults (computer)
        ComparisonHardFaults = 5,           // Comparison - hard faults (computer)
        L2PassiveRedundancy = 6,              // L2 Task 1 constant redundancy
        L2MajorRedundancy = 7,              // L2 Task 2 major redundancy
        L2DynamicRedundancy = 8,              // L2 Task 3 dynamic redundancy
        SimulationModeling = 9
    }
}
