namespace ICloneableMethod
{
    public class Person:ICloneable
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

        public object Clone()
        {
            return new Person(Names,Adress);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ",Names)}, {nameof(Adress)}: {Adress}";
        }
    }

    public class Adress:ICloneable
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

        public object Clone()
        {
            return new Adress(StreeName,HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreeName)}: {StreeName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }











}