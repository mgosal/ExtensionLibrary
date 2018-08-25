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
using System.Threading.Tasks;
using GeneticAlgorithm = GeneticSharp.Domain.GeneticAlgorithm;

namespace UnitTests
{
    [TestClass]
    public class Play2048PatternTestTask
    {
        int bestGen = 0;
        IChromosome bestChromosome;
        [TestMethod]
        public void Play2048PatternTest()
        {

            var selection = new EliteSelection();
            var crossover = new TwoPointCrossover();
            var mutation = new PartialShuffleMutation();
            var fitness = new ClosestToMillion();
            var chromosome = new Play2048Chromosome(20, new List<string>() { "up", "down", "left", "right" });
            var population = new Population(22, 42, chromosome);

            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = new GenerationNumberTermination(10);

            Console.WriteLine("GA running...");
            ga.GenerationRan += Ga_GenerationRan;
            ga.Population.BestChromosomeChanged += Population_BestChromosomeChanged;

            Task.Run(async () => { await Start(ga); }).Wait();

           
            GA.GetSingleton().NextPattern = string.Empty;
            
            Console.WriteLine((bestChromosome as Play2048Chromosome).Pattern);
            Console.WriteLine("Best solution found has {0} fitness was born in generation {1}", ga.BestChromosome.Fitness, bestGen);
        }

        private string Start(GeneticAlgorithm ga)
        {
            ga.Start();
            return string.Empty;
        }

        void Population_BestChromosomeChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(" new best pattern {0}",((sender as Population).BestChromosome as Play2048Chromosome).Pattern);
        }

        private void Ga_GenerationRan(object sender, EventArgs e)
        {
            var ga = sender as GeneticAlgorithm;
            if (bestChromosome == null)
            {
                bestChromosome = ga.BestChromosome;
                bestGen = ga.GenerationsNumber;
            }
            if (ga.BestChromosome.Fitness > bestChromosome.Fitness)
            {
                bestChromosome = ga.BestChromosome;
                bestGen = ga.GenerationsNumber;
            }
            Console.WriteLine("{0}, {1} Generation {2}", (ga.BestChromosome as Play2048Chromosome).Pattern, (ga.BestChromosome as Play2048Chromosome).Score, ga.GenerationsNumber);
        }

        public class ClosestToMillion : IFitness
        {
            public double Evaluate(IChromosome chromosome)
            {
                // Evaluate the fitness of chromosome.
                var play2048Chromosome = chromosome as Play2048Chromosome;
                if (play2048Chromosome != null)
                    return play2048Chromosome.Score - 1000000f;
                else
                {
                    return 0.0f;
                }
            }
        }


        public class Play2048Chromosome : ChromosomeBase
        {
            public int PatternLength { get; set; }
            // Change the argument value passed to base construtor to change the length 
            // of your chromosome.
            public double Score { get; set; }
            public List<string> Choices { get; set; }
            private Random rand = new Random();
            public string Pattern
            {
                get {
                    StringBuilder s = new StringBuilder(PatternLength*(int)Choices.Average(x=>x.Length));
                    for (int i = 0; i < GetGenes().Length; i++)
                    {
                        s.Append(ExtensionLibrary.LeftExtension.Left(GetGene(i).ToString(), 1));
                    }
                    return s.ToString();
                }
            }

            public Play2048Chromosome(int patternLength, List<string> choices)
                : base(patternLength)
            {
                PatternLength = patternLength;
                Choices = choices;
                //Score = new Random(0).NextDouble();
                CreateGenes();
                Console.WriteLine(Pattern);
                Score = rand.Next();
            }

            public override Gene GenerateGene(int geneIndex)
            {
                return new Gene(Choices.PickRandom());
            }

            public override IChromosome CreateNew()
            {
                return new Play2048Chromosome(PatternLength, Choices);
            }

        }
    }
}
