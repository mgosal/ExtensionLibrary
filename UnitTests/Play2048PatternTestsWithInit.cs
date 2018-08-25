using ExtensionLibrary;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ExtensionLibrary.GeneticAlgorithm;
using GeneticAlgorithm = GeneticSharp.Domain.GeneticAlgorithm;

namespace UnitTests
{
    [TestClass]
    public class Play2048PatternTestsWithInit
    {
        int bestGen = 0;
        IChromosome bestChromosome;
        [TestMethod]
        public void Play2048PatternTest()
        {
            GA.GetSingleton().Init(4,new List<string>() { "up", "down", "left", "right" },3,4);
            var p0 = GA.GetSingleton().GetPatternsKeys();
            Console.WriteLine("GA running...");
            GA.GetSingleton().EvolveNextGeneration();
            var p1 = GA.GetSingleton().GetPatternsKeys();
        }
    }
}
