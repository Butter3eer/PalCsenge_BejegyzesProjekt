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
            F2B();
            F2C();
            F2D();
            F2E();
            F2F();
            F3A();
            F3B();
            F3C();
            F3D();
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
            dir = Directory.GetParent(dir).FullName + "\\bejegyzesek.csv";

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
            int hossz = 0;
            int likeszamMax = 0;

            do
            {   
                int likeszam = random.Next(0, hossz * 20);

                for (int j = 0; j < likeszam; j++)
                {
                    bejegyzesek[hossz].Like();
                }

                likeszamMax += likeszam;
                hossz++;

            } while (likeszamMax != hossz * 20 && hossz != bejegyzesek.Count);
        }

        static void F2E()
        {
            Console.Write("Szöveg: ");
            string szoveg = Console.ReadLine();

            bejegyzesek[1].Tartalom = szoveg;
        }

        static void F2F()
        {
            for (int i = 0; i < bejegyzesek.Count; i++)
            {
                Console.WriteLine(bejegyzesek[i].ToString()); 
            }
        }

        static void F3A()
        {
            Console.WriteLine("-----------------------------------------------");
            Bejegyzes legnepszerubb = bejegyzesek.Find(x => x.Likeok == bejegyzesek.Max(y => y.Likeok));

            Console.WriteLine(legnepszerubb.ToString());
        }

        static void F3B()
        {
            List<Bejegyzes> nepszeruBejegyzesek = new List<Bejegyzes>();

            for (int i = 0; i < bejegyzesek.Count; i++)
            {
                if (bejegyzesek[i].Likeok > 35)
                {
                    nepszeruBejegyzesek.Add(bejegyzesek[i]);
                }
            }

            if (nepszeruBejegyzesek.Count == 0)
            {
                Console.WriteLine("Nincs 35 like-nál többel rendelkező bejegyzés!");
            }
            else
            {
                for (int i = 0; i < nepszeruBejegyzesek.Count; i++)
                {
                    Console.WriteLine(nepszeruBejegyzesek[i].ToString());
                }    
            }
        }

        static void F3C()
        {
            List<Bejegyzes> nemAnnyiraNepszeruek = new List<Bejegyzes>();

            for (int i = 0; i < bejegyzesek.Count; i++)
            {
                if (bejegyzesek[i].Likeok < 15)
                {
                    nemAnnyiraNepszeruek.Add(bejegyzesek[i]);
                }
            }

            if (nemAnnyiraNepszeruek.Count == 0)
            {
                Console.WriteLine("Nincs 15 like-nál kevesebbel rendelkező bejegyzés!");
            }
            else
            {
                for (int i = 0; i < nemAnnyiraNepszeruek.Count; i++)
                {
                    Console.WriteLine(nemAnnyiraNepszeruek[i].ToString());
                }
            }
        }

        static void F3D()
        {
            StreamWriter file = new StreamWriter("bejegyzesek_rendezett.txt");

            List<Bejegyzes> rendezett = bejegyzesek.OrderByDescending(x => x.Likeok).ToList();

            for (int i = 0; i < rendezett.Count; i++)
            {
                Console.WriteLine(rendezett[i].ToString());
                file.WriteLine(rendezett[i].ToString() + "\n");
            }

            file.Close();
        }
    }
}
