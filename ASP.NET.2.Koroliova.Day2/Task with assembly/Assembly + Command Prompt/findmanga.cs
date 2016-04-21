using System;
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
