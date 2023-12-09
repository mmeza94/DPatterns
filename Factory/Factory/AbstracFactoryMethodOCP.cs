
using static System.Console;


namespace AbstractFactoryOCP
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

       private List<Tuple<string,IHotDrinkFactory>> factories = new();
       public HotDrinkMachine()
       {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if(typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface){
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory",string.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t)!
                    ));
                }   
            }
       }

       public IHotDrink MakeHotDrink(){
        WriteLine("Available Drinks:");
        for (int index = 0; index < factories.Count; index++)
        {
            var tuple = factories[index];
            WriteLine($"{index}: {tuple.Item1}");
        }
        while(true){
            string s;
            if(
                (s = ReadLine()) != null
                && int.TryParse(s,out int i)
                && i >= 0
                && i < factories.Count
            ){
                Write("Specify amount:");
                s = ReadLine();
                if(
                    s != null 
                    && int.TryParse(s,out int amount)
                    && amount > 0
                ){
                    return factories[i].Item2.prepare(amount);
            }
        }
        WriteLine("Incorrect input, try again!");
       }


    }



    }




}