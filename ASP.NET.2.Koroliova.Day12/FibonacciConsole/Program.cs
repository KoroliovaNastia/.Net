using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonacci;

namespace FibonacciConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            int number = 23;
            int number2 = 33;
            long number3=0;

            Console.WriteLine("Fibonacci sequence contain of 23 numbers:\n ");
            foreach (var item in Sequence.GetSequence(number))
            {
                Console.Write(item+" ");
            }
            Console.WriteLine("\nFibonacci sequence contain of 33 numbers:\n ");
            foreach (var item in Sequence.GetSequence(number2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nFibonacci sequence contain of 15 numbers:\n ");
            foreach (var item in Sequence.GetSequence(15,Sequence.Fibonacci()))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nLast fibonacci number of sequence received prior to overflow\n ");
            foreach (var item in Sequence.GetSequence(Int32.MaxValue, Sequence.Fibonacci()))
            {
                number3 = item;
            }

            Console.WriteLine(number3);
            Console.ReadKey();
        }
    }
}
