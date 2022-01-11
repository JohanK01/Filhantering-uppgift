using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Filhantering_List
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Person> persons;
            persons = new List<Person>();


            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Mata in Förnamn");
                string FirstName = Console.ReadLine();
                Console.WriteLine("Mata in ditt efternamn");
                string LastName = Console.ReadLine();
                persons.Add(new Person() { Fname = FirstName, Lname = LastName }); 
            }

            Console.WriteLine("tryck ENTER för att spara datan");
            Console.ReadLine();

            FileStream fs = new FileStream("data.bin", FileMode.Create);

            BinaryFormatter fm = new BinaryFormatter();
            try
            {
                fm.Serialize(fs, persons);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            
            List<Person> anka = null;

            
            FileStream fs2 = new FileStream("data.bin", FileMode.Open);
            try
            {
                BinaryFormatter fm2 = new BinaryFormatter();
                anka = (List<Person>) fm2.Deserialize(fs2);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs2.Close();
            }
            Console.WriteLine("Datan du har sparat är: ");
            foreach (var p in anka)
            {
                Console.WriteLine(p.Fname +" " + p.Lname);
            }

        }
    }
    [Serializable]
    public class Person
    {
        public string Fname { get; set; }
        public string Lname { get; set; }

        
    }
}
