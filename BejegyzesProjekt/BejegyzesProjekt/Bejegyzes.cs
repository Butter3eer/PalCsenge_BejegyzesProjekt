﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    internal class Bejegyzes
    {
        private string szerzo;
        private string tartalom;
        private int likeok;
        private DateTime letrejott;
        private DateTime szerkesztve;

        public Bejegyzes(string szerzo, string tartalom)
        {
            this.szerzo = szerzo;
            this.tartalom = tartalom;
            this.likeok = 0;
            this.letrejott = DateTime.Now;
            this.szerkesztve = this.letrejott;

        }

        public string Szerzo { get => szerzo; set => szerzo = value; }
        public string Tartalom {get => tartalom; set {tartalom = value; szerkesztve = DateTime.Now;}}
        public int Likeok { get => likeok; set => likeok = value; }
        public DateTime Letrejott { get => letrejott; set => letrejott = value; }
        public DateTime Szerkesztve { get => szerkesztve; set => szerkesztve = value; }

        public void Like()
        {
            likeok++;
        }

        public override string ToString()
        {

            if (letrejott.CompareTo(szerkesztve) != 0)
            {
                return $"{szerzo} - {likeok} - {letrejott}\nSzerkesztve:{szerkesztve}\n{tartalom}\n";
            }
            else
            {
                return $"{szerzo} - {likeok} - {letrejott}\n{tartalom}\n";
            }
        }
    }
}
