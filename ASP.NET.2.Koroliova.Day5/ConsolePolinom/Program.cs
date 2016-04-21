using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polinom;


namespace ConsolePolinom
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatePolinom p1 = new CreatePolinom(3, 4, 2);
            CreatePolinom p2 = new CreatePolinom(1, 2);
            Console.WriteLine("Quotient: " + p1 / p2);
            Console.WriteLine("Remainder: " + p1 % p2);
            Console.WriteLine(p1[p1.Degree]);
            Console.WriteLine(p2[p2.Degree]);
            Console.WriteLine(CreatePolinom.Multiply(p1, p2));
            Console.WriteLine(p1.Colculate(3));
            Console.ReadKey();
        }
    }
}
