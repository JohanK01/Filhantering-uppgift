using System;
using System.IO;

namespace Filhantering
{
    class Program
    {
        static void Main(string[] args)
        {
            //Showing the path
            string path = @"C:\TE42122\c#\D220111 Filhantering\Filhantering\Filhantering\hello.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                Console.WriteLine("Vad heter du?");
                sw.WriteLine(Console.ReadLine());
            }
            Console.WriteLine("Tryck ENTER för att läsa upp filen");
            Console.ReadLine();
            //StreamReader reading the txt file
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

        }
    }
}
