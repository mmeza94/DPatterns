using SingletonImplementation;
using static System.Console;



#region Singleton Implementation




var city = "Tokyo";
WriteLine($"{city} has population {SingletonDatabase.Instance.GetPopulation(city)}");



#endregion




























