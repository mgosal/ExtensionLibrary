using System;
using System.Activities.Presentation.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionLibrary.Design
{
    public sealed class GALibraryMetadata : IRegisterMetadata
    {
        public void Register()
        {
            RegisterAll();
        }

        public static void RegisterAll()
        {
            var builder = new AttributeTableBuilder();
            GeneticAlgorithmScopeDesigner.RegisterMetadata(builder);
            // TODO: Other activities can be added here
            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
