using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Program
{
    [Serializable]
    public class Aliens
    {
        public Aliens() { }

        public string Name { get; private set; }
        public int ID { get; private set; }
        public int Age { get; private set; }
        public int Weight { get; private set; }
        public int Height { get; private set; }
        public string Planet { get; private set; }

        public void InputData()
        {
            Console.WriteLine("Create Aliens Data");
            Console.Write("Name : ");
            Name = Console.ReadLine();
            Console.Write("ID : ");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Age : ");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Weight : ");
            Weight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Height : ");
            Height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Planet : ");
            Planet = Console.ReadLine();
        }
    }

    class SerializerData
    {
        public void BinarySerialize(Aliens data, string filepath)
        {
            FileStream FS;
            BinaryFormatter BF = new BinaryFormatter();
            FS = File.Create(filepath);
            BF.Serialize(FS, data);
            FS.Close();
            Console.WriteLine("Succes");
        }
        public void BinaryDeserialize(string filepath)
        {
            Aliens AliensFile = null;
            FileStream FS;
            BinaryFormatter BF = new BinaryFormatter();
            if (File.Exists(filepath))
            {
                FS = File.OpenRead(filepath);
                AliensFile = (Aliens)BF.Deserialize(FS);

            }
            Console.WriteLine("Name :" + AliensFile.Name + " || ID : " + AliensFile.ID + "|| Age : " + AliensFile.Age + "|| Weight : " + AliensFile.Weight + "|| Height : " + AliensFile.Height + "|| Planet : " + AliensFile.Planet);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Aliens aliens = new Aliens();

            aliens.InputData();
            Console.Write("Input name of file : ");
            string filepath = Console.ReadLine();
            
            SerializerData SD = new SerializerData();
            Aliens a = null;

            SD.BinarySerialize(aliens, filepath);

            SD.BinaryDeserialize(filepath);
        }
    }
}
