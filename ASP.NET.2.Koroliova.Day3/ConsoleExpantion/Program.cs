using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expantion;

namespace ConsoleExpantion
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = 225, a2 = -1, a3 = 255, a4 = -225;
            
                Console.WriteLine("Hex representation of number 225 in standar format 'x': " + a1.ConvertToHex());
            try
            {
                Console.WriteLine("\nHex representation of number -1 in strange format 'limbo' : ");
                Console.WriteLine( a2.ConvertToHex("limbo"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exeption {0}", e);
            }
            Console.WriteLine("\nHex representation of number -1 in standart format 'x' : " + a2.ConvertToHex());
                Console.WriteLine("\nHex representation of number 255 in standart format 'x' : " + a3.ConvertToHex("x"));
                Console.WriteLine("\nHex representation of number 255 in apper standart format 'X' : " +
                                  a3.ConvertToHex("X"));
                Console.WriteLine("\nHex representation of number 255 in  standart format 'X4' : " + a3.ConvertToHex("X4"));
                Console.WriteLine("\nHex representation of number -255 in standart format 'x' : " + a4.ConvertToHex("x"));
            try
            {
                Console.WriteLine("\nHex representation of number -255 in null format : ");
                Console.WriteLine(a4.ConvertToHex(null));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exeption {0}",e);
                
            }
            Console.ReadKey();
        }
    }
}
