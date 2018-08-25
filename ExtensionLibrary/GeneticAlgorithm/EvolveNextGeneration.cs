using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ExtensionLibrary.GeneticAlgorithm
{
    public class EvolveNextGeneration : CodeActivity
    {
        [RequiredArgument]
        [Category("Output")]
        [DisplayName("Result")]
        [Description("Pattern")]
        public OutArgument<List<string>> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            GeneticAlgorithm.GA.GetSingleton().EvolveNextGeneration();
            var r = GeneticAlgorithm.GA.GetSingleton().GetPatternsKeys();
            Result.Set(context, r);

        }
    }
}
