using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NewtonMethod;

namespace ConsoleNewtonMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers={-1,-2,3,4};
            int[] pow={2,-3,4};
            double eps=0.00000000001;
          
                for (int i = 0; i < pow.Length; i++)
                {
                    foreach (var number in numbers)
                    {
                        try
                        {
                            Console.WriteLine("\nroot n={0} of {1}  our method:\n" + RootOfNumber.FindRoot(pow[i], number, eps),pow[i],number);
                        }
                        catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                
            }
                        Console.WriteLine("\nroot n={0} of {1} Math.Pow method:\n" + Math.Pow(number, 1.0 / pow[i]), pow[i], number);
                   
                }
            }

         
            
            Console.ReadKey();
        }
    }
}
