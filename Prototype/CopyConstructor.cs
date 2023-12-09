


namespace CopyConstructor
{
    public class Person
    {
        public string[] Names;
        private Adress Adress;

        public Person(string[] names, Adress adress)
        {
            if(names == null){
                throw new ArgumentNullException(paramName:nameof(names));
            }
            if(adress == null){
                throw new ArgumentNullException(paramName:nameof(adress));
            }
            Names = names;
            Adress = adress;
        }
        public Person(Person person)
        {
            Names = person.Names;
            Adress = new Adress(person.Adress);
            
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ",Names)}, {nameof(Adress)}: {Adress}";
        }
    }

    public class Adress
    {
        public string StreeName;
        public int HouseNumber;   

        public Adress(string StreeName,int HouseNumber)
        {
            if(StreeName == null){
                throw new ArgumentNullException(paramName:nameof(StreeName));
            }
            this.StreeName = StreeName;
            this.HouseNumber = HouseNumber;
        }
        public Adress(Adress adress)
        {
            StreeName = adress.StreeName;
            HouseNumber = adress.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreeName)}: {StreeName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }
}














