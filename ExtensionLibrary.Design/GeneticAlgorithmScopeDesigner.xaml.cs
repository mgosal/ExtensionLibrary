using ExtensionLibrary.GeneticAlgorithm;
using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.Drawing;

namespace ExtensionLibrary.Design
{
    // Interaction logic for GeneticAlgorithmScopeDesigner.xaml
    public partial class GeneticAlgorithmScopeDesigner
    {
        public GeneticAlgorithmScopeDesigner()
        {
            InitializeComponent();
        }

        public static void RegisterMetadata(AttributeTableBuilder builder)
        {
            builder.AddCustomAttributes(
                typeof(GeneticAlgorithmScope),
                new DesignerAttribute(typeof(GeneticAlgorithmScopeDesigner)),
                new DescriptionAttribute("Genetic Algorithm Scope"),
                new ToolboxBitmapAttribute(typeof(GeneticAlgorithmScope), "dna.png"));
        }
    }
}
