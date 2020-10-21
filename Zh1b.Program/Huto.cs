using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Zh1b.Program
{
    class Huto
    {
        [ImportantProperty("Fontos")]
        public string Marka { get; set; }
        public int Kapacitas { get; set; }
        public List<Termek> Termekek { get; set; }
    }
}
