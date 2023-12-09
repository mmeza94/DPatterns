using Autofac.Core.Activators;
using MoreLinq;
using NUnit.Framework;

namespace SingletonImplementation
{
    public interface IDatabase{
        int GetPopulation(string name);
    }


    // public class SingletonDatabase : IDatabase
    // {
    //     private static SingletonDatabase _instance = new SingletonDatabase();
    //     public static SingletonDatabase Instance => _instance;
    //     private Dictionary<string,int> capitals;

    //     private SingletonDatabase()
    //     {
    //         System.Console.WriteLine("Initializing database");
    //         capitals = File.ReadAllLines("capitals.txt")
    //             .Batch(2)
    //             .ToDictionary(
    //                 List => List.ElementAt(0).Trim(),
    //                 List => int.Parse(List.ElementAt(1))
    //              );
    //     }
    //     public int GetPopulation(string name)
    //     {
    //         throw new NotImplementedException();
    //     }
    // }

    // // Lazy instanciation ex1
    // public class SingletonDatabase : IDatabase
    // {
    //     private static SingletonDatabase _instance;
    //     public static SingletonDatabase Instance {
    //         get {
    //             if (_instance is null)
    //             {
    //                 _instance = new SingletonDatabase();
    //             }
    //             return _instance;
    //         }
    //     }
    //     private Dictionary<string,int> capitals;

    //     private SingletonDatabase()
    //     {
    //         System.Console.WriteLine("Initializing database");
    //         capitals = File.ReadAllLines("capitals.txt")
    //             .Batch(2)
    //             .ToDictionary(
    //                 List => List.ElementAt(0).Trim(),
    //                 List => int.Parse(List.ElementAt(1))
    //              );
    //     }
    //     public int GetPopulation(string name)
    //     {
    //         throw new NotImplementedException();
    //     }
    // }


// Lazy instance ex 2
    public class SingletonDatabase : IDatabase
    {
        private static Lazy<SingletonDatabase> _instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => _instance.Value;
        private Dictionary<string,int> capitals;
        private static int instanceCount;
        public static int Count => instanceCount;

        private SingletonDatabase()
        {
            instanceCount++;
            System.Console.WriteLine("Initializing database");
            var path = Path.Combine(
                new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName!,"capitals.txt"
            );
            capitals = File.ReadAllLines(path)
                .Batch(2)
                .ToDictionary(
                    List => List.ElementAt(0).Trim(),
                    List => int.Parse(List.ElementAt(1))
                 );
        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }


    public class SingletonRecordFinder
    {
        public int TotalPopulation(IEnumerable<string> names)
        {
        int result = 0;
        foreach (var name in names)
            result += SingletonDatabase.Instance.GetPopulation(name);
        return result;
        }
    }


    public class ConfigurableRecordFinder
    {
        private IDatabase database;
        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException(paramName:nameof(database));
        }
        public int TotalPopulation(IEnumerable<string> names)
        {
        int result = 0;
        foreach (var name in names)
            result += SingletonDatabase.Instance.GetPopulation(name);
        return result;
        }
    }

    public class DummyDatabase:IDatabase{
        public int GetPopulation(string name)
        {
            return new Dictionary<string,int>{
                ["alpha"]=1,
                ["beta"]=2,
                ["gamma"]=3 
            }[name];
        }
    }


    [TestFixture]
    public class SingletonTests{
        [Test]
        public void IsSingletonTest(){
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.Count,Is.EqualTo(1));
        }

        [Test]
        public void SingletonPopulationTest(){
            var rf = new SingletonRecordFinder();
            var names = new[]{"Seoul","Mexico City"};
            int tp = rf.TotalPopulation(names);
            Assert.That(tp,Is.EqualTo(17500000+17400000));
        }

        [Test]
        public void ConfigurablePopulationTest(){
            var rf = new ConfigurableRecordFinder(new DummyDatabase());
            var names = new[]{"alpha","gamma"};
            int tp = rf.TotalPopulation(names);
            Assert.That(tp,Is.EqualTo(4));
        }
    }








}

