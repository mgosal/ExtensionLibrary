using System;
using System.Activities;
using System.Activities.Presentation.View;
using System.Activities.Statements;
using System.Activities.Validation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace ExtensionLibrary.GeneticAlgorithm
{
    public class GeneticAlgorithmScope: NativeActivity
    {
        

        [Browsable(false)]
        public ActivityAction<string> Body { get; set; }

        [Category("GA")]
        [RequiredArgument]
        public InArgument<int> Population { get; set; } 

        [Category("GA")]
        [RequiredArgument]
        public InArgument<int> MaxGenerations { get; set; } 

        [Category("GA")]
        [RequiredArgument]
        public InArgument<List<string>> Choices { get; set; }

        [Category("GA")]
        [RequiredArgument]
        public InArgument<int> PatternLength { get; set; }

        [Category("GA")]
        public InArgument<List<string>> BestPattern { get; set; }

        [Category("GA")]
        public OutArgument<List<string>> Result { get; set; }

        [Category("GA")]
        public InArgument<Selection> Selection { get; set; }

        [Category("GA")]
        public InArgument<Crossover> Crossover { get; set; }


        [Category("GA")]
        public InArgument<Mutation> Mutation { get; set; }

        public GeneticAlgorithmScope()
        {
            Body = new ActivityAction<string>
            {
                Handler = new Sequence { DisplayName = "Do" }
            };
        }
        private void OnFaulted(NativeActivityFaultContext faultContext, Exception propagatedException, ActivityInstance propagatedFrom)
        {
            //TODO
        }

        private void OnCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            //TODO
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            if (Choices==null)
            {
                ValidationError error = new ValidationError("Choices cannot be null");
                metadata.AddValidationError(error);
            }
        }

        protected override void Execute(NativeActivityContext context)
        {
            GA.GetSingleton().Init(PatternLength.Get(context), Choices.Get(context), Population.Get(context), MaxGenerations.Get(context),
                Selection.Get(context),Crossover.Get(context),Mutation.Get(context));
            var r = GA.GetSingleton().GetPatternsKeys();
            Result.Set(context,r);
            if (Body != null)
            {
                context.ScheduleAction<string>(Body, "GA", OnCompleted, OnFaulted);
            }
        }
    }
}


    
