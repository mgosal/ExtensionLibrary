using System;
using System.Linq;
using System.Reflection;
using ExtensionLibrary;
using ExtensionLibrary.GeneticAlgorithm.Model;
using LiteDB;

public sealed class jsonDb
{
    private static readonly Lazy<jsonDb> lazy =
        new Lazy<jsonDb>(() => new jsonDb());

    public static jsonDb Instance { get { return lazy.Value; } }
    public string Find(string key, string collection=null, string dbPath = null, string ns = null)
    {
        if (dbPath == null)
        {
            dbPath = Assembly.GetExecutingAssembly().GetName().Name + ".jsonDb";
        }
        using (var db = new LiteDatabase(dbPath))
        {
            var r = db.GetCollection<JsonDataItem>(collection).Find(x => x.Key == key);
            if (r.Count() == 1)
            {
                return ExtensionLibrary.JsonExtensions.ToJson(r);
            }
        }
        return string.Empty;
    }
    private jsonDb()
    {
    }

    public static void Insert<T>(string json, string collection = null, string dbPath = null, string ns = null)
    {

        if (dbPath == null)
        {
            dbPath = Assembly.GetExecutingAssembly().GetName().Name + ".db";
        }
        if (collection==null)
        {
            collection = typeof(T).ToString().Split('+').Last();
        }
        using (var db = new LiteDatabase(dbPath))
        {
            var col = db.GetCollection<JsonDataItem>(collection);
            JsonDataItem d = new JsonDataItem();
            d.Json = json;
            col.Update(d);
        } 
    }
}