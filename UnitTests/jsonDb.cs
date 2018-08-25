using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using ExtensionLibrary;
using ExtensionLibrary.GeneticAlgorithm.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiteDB;
namespace UnitTests
{
    [TestClass]
    public class jsonDbTests
    {

        [TestMethod]
        public void find()
        {
            string collection = null;
            string dbPath = null;
            if (dbPath == null)
            {
                dbPath = Assembly.GetExecutingAssembly().GetName().Name + ".db";
            }
            
            var p = new Patterns()
                {
                    Pattern = "udlr"
                };
            var item = jsonDb.Instance.Find(p.Pattern);
            if (string.IsNullOrEmpty(item))
            {
                jsonDb.Insert<JsonDataItem>(p.ToJson());
            }
        }

        [TestMethod]
        public void AddPaternToQueueDb()
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(@"MyData.jsonDb"))
            {
                string table = "patterns";
                // Get customer collection
                var col = db.GetCollection<Patterns>(table);

                // Create your new customer instance
                var p = new Patterns()
                {
                    Pattern = "udlr"
                };


                var result = col.Find(x => x.Pattern == p.Pattern);
                if (result.Count() == 1)
                {
                    Console.WriteLine(result.Single().Fitness);
                }


                // Create unique index in Name field
                col.EnsureIndex(x => x.Pattern, true);

                // Insert new customer document (Id will be auto-incremented)
                col.Insert(p);

                // Update a document inside a collection
                p.Fitness = -9393;

                col.Update(p);

                // Use LINQ to query documents (with no index)
                //var results = col.Find(x => x.Age > 20);
                
            }
        }

        public class Patterns
        {
            public int Id { get; set; }
            public string Pattern { get; set; }
            public double Fitness { get; set; }
            public int HighestScore { get; set; }
        }

        [TestMethod]
        public void CreateMyDataDb()
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(@"MyData.jsonDb"))
            {
                // Get customer collection
                var col = db.GetCollection<Customer>("customers");

                // Create your new customer instance
                var customer = new Customer
                {
                    Name = "John Doe",
                    Phones = new string[] { "8000-0000", "9000-0000" },
                    Age = 39,
                    IsActive = true
                };

                // Create unique index in Name field
                col.EnsureIndex(x => x.Name, true);

                // Insert new customer document (Id will be auto-incremented)
                col.Insert(customer);

                // Update a document inside a collection
                customer.Name = "Joana Doe";

                col.Update(customer);

                // Use LINQ to query documents (with no index)
                var results = col.Find(x => x.Age > 20);
            }
        }



        public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string[] Phones { get; set; }
    public bool IsActive { get; set; }
}


    }
}
