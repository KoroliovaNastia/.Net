using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting;

namespace ConsoleSorting
{
    class Program
    {


        static void Show(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write(a[i][j]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }
        static void Main(string[] args)
        {

            int[][] array = new int[3][];
            array[0] = new[] { 2, 6, 7, 9, 10 };
            array[1] = new[] { 7, -1, 11, 4 };
            array[2] = new[] { -2, 8, 5, 9, 13 };
            int[][] jaggetArray =
            {
                new[] {0, 9, -4, 7, 2, 4},
                new[] {11, -3, 6, -7, 12},
                new[] {4, 5, 3},
                new[] {2, 2, -5, -6, 10}
            };
            Console.WriteLine("Max sorting\n");
            SortJagArray.Sort(array);
            Show(array);
            Console.WriteLine("Min sorting\n");
            SortJagArray.Sort(array, SortJagArray.SortMinElem);
            Show(array);
            Console.WriteLine("Sum sorting\n");
            SortJagArray.Sort(array, SortJagArray.SortMaxSumm);
            Show(array);

            Console.WriteLine("Max sorting\n");
            SortJagArray.Sort(jaggetArray);
            Show(jaggetArray);
            Console.ReadKey();
           
        }
    }
}
