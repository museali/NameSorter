using System;
using System.Collections.Generic;

/*
 * This class provides a static method Print
 * to print lines of text to the console.
 */
namespace NameSorter
{
    public class ConsoleOutput
    {
        public static void Print(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
