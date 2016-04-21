using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace ConsoleTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] mass = {12, -5, 4, 8, 3 , 13};
            //Comparison<long> comparison;
            Sorting.SortMerge(mass);
            foreach (var index in mass)
            {
                Console.Write(index);
            }
            Console.ReadKey();
        }
    }
}
