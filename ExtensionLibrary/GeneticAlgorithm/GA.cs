using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;

namespace ExtensionLibrary.GeneticAlgorithm
{
    public class GA
    {
        private GA()
        {
            // Prevent outside instantiation
        }

        private static readonly GA _singleton = new GA();
        private ISelection _selection;
        private ICrossover _crossover;
        private IMutation _mutation;
        private ClosestToMillion _fittness;
        private PlayPatternChromosome _playPatternChromosome;
        private Population _population;
        private GeneticSharp.Domain.GeneticAlgorithm _geneticAlgorithm;


        public static GA GetSingleton()
        {
            return _singleton;
        }

        public enum Selections
        {
            EliteSelection,
            RouletteWheelSelection,
            StochasticUniversalSamplingSelection,
            TournamentSelection
        }
        public object GetInstance(string strFullyQualifiedName)
        {
            Type t = Type.GetType(strFullyQualifiedName);
            return Activator.CreateInstance(t);
        }
        public void Init(int patternLength, List<string> choices, int populationSize, int maxGenerations)
        {
            _selection = new EliteSelection();
            _crossover = new TwoPointCrossover();
            _mutation = new PartialShuffleMutation();
            
            _fittness = new ClosestToMillion();

            _playPatternChromosome = new PlayPatternChromosome(patternLength, choices);
            //var bestPattern = BestPattern.Get(context);
            _population = new Population(populationSize, populationSize, _playPatternChromosome);

            _geneticAlgorithm = new GeneticSharp.Domain.GeneticAlgorithm(_population, _fittness, _selection,
                _crossover, _mutation);
            _geneticAlgorithm.Termination = new GenerationNumberTermination(maxGenerations);
            _geneticAlgorithm.Init();
        }

        public void SetScore(string p, int s)
        {
            var c = (PlayPatternChromosome)_geneticAlgorithm.Population.Generations[_geneticAlgorithm.GenerationsNumber-1].Chromosomes.Where(x=>(x as PlayPatternChromosome).PatternKeys==p).First();
            c.Score = s;
        }

        public List<string> GetPatternsKeys()
        {
            var r = new List<string>();
            foreach (var item in _geneticAlgorithm.Population.Generations[_geneticAlgorithm.GenerationsNumber-1].Chromosomes)
            {
                r.Add((item as PlayPatternChromosome).PatternKeys);
            }
            return r;
        }

        public void EvolveNextGeneration()
        {
            _geneticAlgorithm.EvolveNextGeneration();
        }
    }

    public class PlayPatternChromosome : ChromosomeBase
    {
        public int PatternLength { get; set; }
        // Change the argument value passed to base construtor to change the length 
        // of your chromosome.
        public double Score { get; set; }
        public List<string> Choices { get; set; }
        public string Pattern
        {
            get
            {
                StringBuilder s = new StringBuilder(PatternLength);
                for (int i = 0; i < GetGenes().Length; i++)
                {
                    s.Append(ExtensionLibrary.LeftExtension.Left(GetGene(i).ToString(), 1));
                }
                return s.ToString();
            }
        }

        public string PatternKeys
        {
            get
            {
                StringBuilder keys = new StringBuilder();
                for (int i = 0; i < GetGenes().Length; i++)
                {
                    keys.Append("[k(" + GetGene(i) + ")]");
                }
                return keys.ToString();
            }
        }

        public PlayPatternChromosome(int patternLength, List<string> choices)
            : base(patternLength)
        {
            PatternLength = patternLength;
            Choices = choices;
            //Score = new Random(0).NextDouble();
            CreateGenes();
        }

        public override Gene GenerateGene(int geneIndex)
        {
            return new Gene(PickRandomExtension.PickRandom(Choices));
        }

        public override IChromosome CreateNew()
        {
            return new PlayPatternChromosome(PatternLength, Choices);
        }
    }

    public class ClosestToMillion : IFitness
    {
        public double Evaluate(IChromosome chromosome)
        {

            var timeoutTime = DateTime.Now.AddMinutes(10);
            // Evaluate the fitness of chromosome.
            var c = chromosome as PlayPatternChromosome;
            if (c != null)
                return c.Score - 1000000f;
            else
            {
                return 0.0f;
            }
        }
    }
}

