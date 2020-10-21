using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ZhgyakB
{
    static class Extensions
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string str)
        {
            Console.WriteLine("*** BEGIN " + str);
            foreach (T item in input)
            {
                Console.WriteLine(item.ToString());

            }
            Console.WriteLine("*** END " + str);
            Console.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //HutogepesDbContext ctx = new HutogepesDbContext();
            //ctx.Ingredients.Select(x => x.IngredientName).ToConsole("ingredients");
            Huto h = CreateHuto();

            Console.WriteLine("asd");
        }

        public static Huto CreateHuto()
        {
            XDocument hutoXml = XDocument.Load("huto.xml");

            string hutoMarka = hutoXml.Root.Attribute("brand")?.Value;
            int hutokapacitas = int.Parse(hutoXml.Root.Attribute("capacity")?.Value);

            var q1 = hutoXml.Descendants("product").Select(x =>
            {
                return new
                {
                    Mennyiseg = int.Parse(x.Attribute("quantity")?.Value),
                    Megnevezes = x?.Value
                };
            });

            Huto h = new Huto() { Kapacitas = hutokapacitas, Marka = hutoMarka, Termekek = new List<Termek>() };

            foreach (var item in q1)
            {
                h.Termekek.Add(
                    new Termek() { Megnevezes = item.Megnevezes, Mennyiseg = item.Mennyiseg }
                );
            }

            return h;
        }
    }
}
