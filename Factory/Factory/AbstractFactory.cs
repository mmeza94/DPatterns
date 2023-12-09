
using static System.Console;


namespace AbstractFactory
{
    
    public interface IHotDrink{
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine($"This tea is nice but i'd prefer it with tea");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine($"This coffee is sensational");
        }
    }

    public interface IHotDrinkFactory{
        IHotDrink prepare(int amount);
    }


    public class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink prepare(int amount)
        {
            WriteLine("Making tea...");
            return new Tea();
        }
    }


    public class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink prepare(int amount)
        {
            WriteLine("Making coffee");
            return new Coffee();
        }
    }


    public class HotDrinkMachine{

        public enum AvailableDrink{
            Coffee,Tea
        }

        private Dictionary<AvailableDrink,IHotDrinkFactory> factories = new();

        public HotDrinkMachine()
        {
         foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
         {
            var type = Type.GetType("AbstractFactory." + Enum.GetName(typeof(AvailableDrink),drink) + "Factory")!;
            var factory = (IHotDrinkFactory)Activator.CreateInstance(type)!;
            factories.Add(drink,factory);
         }   
        }

        public IHotDrink MakeDrink(AvailableDrink drink,int amount){
            return factories[drink].prepare(amount);
        }


    }








}