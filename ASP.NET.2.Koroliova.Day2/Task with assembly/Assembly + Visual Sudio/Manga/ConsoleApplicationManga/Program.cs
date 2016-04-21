using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manga;

namespace ConsoleApplicationManga
{
    class Program
    {
        static void Main(string[] args)
        {
            JapanesManga manga1 = new JapanesManga("Steins;Gate", "SARACHI Yomi", "PG-13");
            Console.WriteLine(manga1.ToString());
        }
    }
}
