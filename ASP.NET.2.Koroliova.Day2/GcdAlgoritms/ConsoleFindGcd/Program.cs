using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GcdAlgorithms;

namespace ConsoleFindGcd
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=32, b=64, c=126;
            int[] list = {27, 84, 36, 98, 21};
            long time;
            Console.WriteLine("Euclidian algorithm for {0} and {1} without lead time :\n" + "Gcd :" + FindGcd.Gcd(a, b,FindGcd.GcdEuclidian), a, b);
            Console.WriteLine("Euclidian algorithm for {0} and {1} without lead time :\n" + "Gcd :" + FindGcd.Gcd(0, 0, FindGcd.GcdEuclidian), 0, 0);
            Console.WriteLine("Euclidian algorithm for {0},{1} and {2} with lead time :\n" + "Gcd :" + FindGcd.Gcd(a, b, c, out time, FindGcd.GcdEuclidian) + " time :" + time, a, b, c);
            Console.WriteLine("Euclidian algorithm for list {27, 84, 36, 98, 21} with lead time :\n" + "Gcd :" + FindGcd.Gcd(out time, FindGcd.GcdEuclidian,list) + " time :" + time);
            
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Stein's algorithm for {0} and {1} without lead time :\n" + "Gcd :" + FindGcd.Gcd(a, b,FindGcd.GcdSteins), a, b);
            Console.WriteLine("Euclidian algorithm for {0} and {1} without lead time :\n" + "Gcd :" + FindGcd.Gcd(0, 0, FindGcd.GcdSteins), 0, 0);
            Console.WriteLine("Stein's algorithm for {0},{1} and {2} with lead time :\n" + "Gcd :" + FindGcd.Gcd(a, b, c, out time, FindGcd.GcdSteins) + " time :" + time, a, b, c);
            Console.WriteLine("Stein's algorithm for list {27, 84, 36, 98, 21} with lead time :\n" + "Gcd :" + FindGcd.Gcd(out time,FindGcd.GcdSteins, list) + " time :" + time);
            
            Console.ReadKey();

        }
    }
}
