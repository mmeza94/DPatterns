namespace Factory.FactoryMethodAsync
{
    public class Foo{
        public string MyProperty { get; set; } = "My Property from Foo";
        private Foo()
        {
            
        }
        private async Task<Foo> InitAsync(){
            await Task.Delay(1000);
            return this;
        }
        public static Task<Foo> CreateAsync(){
            var result = new Foo();
            return result.InitAsync();
        }
    }
}