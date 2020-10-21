using System;
using System.Collections.Generic;
using System.Text;

namespace Zh1b.Program
{
    static class Operations
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string header)
        {
            Console.WriteLine($"***************{header}***************");
            foreach (var item in input) Console.WriteLine(item);
            Console.WriteLine($"***************{header}***************");
            Console.WriteLine();
        }
    }
}
