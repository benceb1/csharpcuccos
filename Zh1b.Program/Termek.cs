using System;
using System.Collections.Generic;
using System.Text;

namespace Zh1b.Program
{
    public class Termek
    {
        [ImportantProperty("Fontos")]
        public string Megnevezes { get; set; }
        public int Mennyiseg { get; set; }

        public override string ToString()
        {
            return Megnevezes + " " + Mennyiseg;
        }
    }
}
