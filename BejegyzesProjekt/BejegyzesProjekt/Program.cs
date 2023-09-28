using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        static List<Bejegyzes> bejegyzesek = new List<Bejegyzes>() { new Bejegyzes("Nagy Pál", "Az őszi kecske kalandjait elmesélő könyv."), new Bejegyzes("Kis Pál", "A kis kecske kalandjait elmesélő regény.") };

        static void F2B()
        {
            int number;
            Console.WriteLine("Darabszám: ");
            if (int.TryParse(Console.ReadLine(), out number))
            {
                for (int i = 0; i < number; i++)
                {
                    Console.Write("Szerző: ");
                    string szerzo = Console.ReadLine();

                    Console.Write("\nTartalom: ");
                    string tartalom = Console.ReadLine();

                    bejegyzesek.Add(new Bejegyzes(szerzo, tartalom));
                }
            }
            else
            {
                Console.WriteLine("Hibás input! Csak egész számot adhat meg!");
                F2B();
            }
        }

        static void F2C()
        {
            string dir = Directory.GetCurrentDirectory();
            dir = Directory.GetParent(dir).FullName;
            dir = Directory.GetParent(dir).FullName;
            dir = Directory.GetParent(dir).FullName + "\bejegyzesek.csv";

            StreamReader file = new StreamReader(dir);

            while (!file.EndOfStream)
            {
                string[] row = file.ReadLine().Split(';');
                bejegyzesek.Add(new Bejegyzes(row[0], row[1]));
            }
            file.Close();
        }

        static void F2D()
        {
            Random random = new Random();
            int hossz = bejegyzesek.Count();
            int likeszamMax = 0;

            do
            {
                for (int i = 0; i <= hossz - 1; i++)
                {
                    int likeszam = random.Next(0, hossz * 20);

                    for (int j = 0; j < likeszam; j++)
                    {
                        bejegyzesek[i].Like();
                    }

                    likeszamMax += likeszam;
                }
            } while (likeszamMax != hossz * 20);
        }
    }
}
