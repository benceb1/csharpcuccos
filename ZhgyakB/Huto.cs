using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ZhgyakB
{
    class Huto
    {
        [ImportantProperty("Fontos")]
        public string Marka { get; set; }
        public int Kapacitas { get; set; }
        
        public List<Termek> Termekek { get; set; }

        public Huto()
        {

        }
    }
}
