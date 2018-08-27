using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionLibrary.GeneticAlgorithm
{
    public enum Crossover
    {
        CutAndSpliceCrossover,
        CycleCrossover,
        OnePointCrossover,
        OrderBasedCrossover,
        OrderedCrossover,
        PartiallyMappedCrossover,
        PositionBasedCrossover,
        ThreeParentCrossover,
        TwoPointCrossover,
        UniformCrossover
    }
}
