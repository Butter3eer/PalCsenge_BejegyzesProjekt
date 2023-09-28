using System;
using System.Collections.Generic;
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

        static void F2A()
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
                F2A();
            }
        }
    }
}
