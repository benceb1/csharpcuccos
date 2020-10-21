using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Zh1b.Program.Models;

namespace Zh1b.Program
{
    class Program
    {

        

        static Huto xmlBolHuto()
        {
            XDocument xdoc = XDocument.Load(@"https://users.nik.uni-obuda.hu/prog3/_docs/prog3_new_exercise_zh1b_fridge.xml");
            Huto h = new Huto
            { 
                Marka = xdoc.Root.Attribute("brand").Value,
                Kapacitas =int.Parse(xdoc.Root.Attribute("capacity").Value),
                Termekek = new List<Termek>(),
            };
            foreach (var item in xdoc.Descendants("product"))
            {
                h.Termekek.Add(new Termek {Megnevezes = item.Value, Mennyiseg = int.Parse(item.Attribute("quantity").Value)});
            }
            return h;
        }

        static void Main(string[] args)
        {
            ReceptekContext Rc = new ReceptekContext();

            Console.WriteLine("\nA:");
            var a = Rc.Recipes.Select(x => x.Id).Count();
            Console.WriteLine(a);

            Console.WriteLine("\nB:");
            var b = Rc.Recipes.Where(x => x.IsFavourite == true).Select(x => x.RecipeName);
            foreach (var item in b)
            {
                Console.WriteLine(item);
            }

            var c = from i in Rc.Ingredients
                    join r in Rc.Recipes on i.RecipeId equals r.Id
                    orderby r.Price descending
                    where i.IngredientName == "Olaj"
                    select new { r.RecipeName, r.Price };

            c.ToConsole("C");

            var d = from i in Rc.Ingredients
                    group i by i.IngredientName into g
                    select new {Alapanyag = g.Key, Db = g.Sum(x => x.Amount) };

            d.OrderBy(x=>x.Db).ToConsole("D");



            Huto huto = xmlBolHuto();
            huto.Termekek.ToConsole(huto.Marka + " " + huto.Kapacitas);
            Console.WriteLine();

            Helper.Help(huto);
            foreach (var item in huto.Termekek)
            {
                Helper.Help(item);
            }

            Console.WriteLine("Adja meg a receptet:");
            string keres = Console.ReadLine();
            var keresetR = Rc.Recipes.Single(x => x.RecipeName.ToLower().Contains(keres.ToLower()));
            var e1 = from i in Rc.Ingredients
                     where i.RecipeId == keresetR.Id
                     select i;

            Func< IEnumerable<Ingredients>, IEnumerable<Termek>,bool> func = 
                (x1, x2) => {
                    foreach (var konyvben in x1)
                    {
                        foreach (var hutoben in x2)
                        {
                            if (konyvben.IngredientName.Equals(hutoben.Megnevezes))
                            {
                                if (konyvben.IngredientName.Equals(hutoben.Megnevezes))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    return true;
                };

            Console.WriteLine("Van elég alapanyag: "+func?.Invoke(e1,huto.Termekek));

            List<Ingredients> lista = new List<Ingredients>();
            foreach (var item in d)
            {
                lista.Add(new Ingredients {IngredientName = item.Alapanyag, Amount =  item.Db});
            }
            
            Console.WriteLine("Van elég alapanyag az összes ételhez: " + func?.Invoke(lista, huto.Termekek));
        }
    }
}