using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Zh1b.Program
{
    class Helper
    {
        public static string Help(object obj)
        {
            PropertyInfo[] pi = obj.GetType().GetProperties();
            var t = pi.Where(prop => prop.IsDefined(typeof(ImportantPropertyAttribute), false));
            string s = "";
            foreach (var item in t)
            {
                s+=item.GetValue(obj).ToString();
            }
            return  s;
        }
    }
}
