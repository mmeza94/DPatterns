using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SerialiationPrototype
{
    public static class ExtensionMethods{
        // Este nos obliga a usar el decorador Serializable
        public static T DeepCopy<T>(this T self){
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream,self);
            stream.Seek(0,SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T) copy;
        }

        //Este me obliga a teneder un constructor sin parametros en las clases que se van a serializar
        public static T DeepCopyXml<T>(this T self){
            using (var ms = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(ms,self);
                ms.Position = 0;
                return (T)serializer.Deserialize(ms)!;
            }
        }

    }

    [Serializable]
    public class Person
    {
        public string[] Names;
        private Adress Adress;

        public Person()
        {
            
        }

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

        public Person deepcopy()
        {
            return new Person(Names,Adress.deepcopy());
        }
    }

    [Serializable]
    public class Adress
    {
        public string StreeName;
        public int HouseNumber;   

        public Adress()
        {
            
        }

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

        public Adress deepcopy()
        {
            return new Adress(StreeName,HouseNumber);
        }
    }



    
}