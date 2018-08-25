using System.Activities;
using System.ComponentModel;

namespace ExtensionLibrary.GeneticAlgorithm
{
    [DisplayName("Set Pattern Score")]
    public class SetScoreActivity : CodeActivity
    {
        [RequiredArgument]
        [Category("Input")]
        [DisplayName("Score")]
        public InArgument<int> Score { get; set; }


        [RequiredArgument]
        [Category("Input")]
        [DisplayName("Pattern")]
        public InArgument<string> Pattern { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            GeneticAlgorithm.GA.GetSingleton().SetScore(Pattern.Get(context),Score.Get(context));
        }
    }
}
