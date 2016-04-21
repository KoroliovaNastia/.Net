using System;
using System.Diagnostics;

namespace GcdAlgorithms
{
    /// <summary>
    /// Class which implements Euclidean and Stains algorithms finding GCD.
    /// </summary>
    public class FindGcd
    {
        /// <summary>
        /// Gcd Delegate which implements Euclidean and Steins algorithms
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public delegate int GcdDelegate(int a, int b);
        # region Methods with Gcd

        /// <summary>
        /// Method finding gcd of two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="func">Gcd delegate</param>
        /// <returns></returns>
        public static int Gcd(int a, int b, GcdDelegate func)
        {
            if (a == 1 || b == 1)return 1;
            if (a == 0) return b;
            if (b == 0) return a;
            return func(a, b);
        }
        /// <summary>
        /// Overriding Gcd method of two numbers with execution time of the algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="time">Execution time of the algorithm</param>
        /// <param name="func">Gcd delegate</param>
        /// <returns></returns>
        public static int Gcd(int a, int b, out long time, GcdDelegate func)
        {
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();
            Gcd(a, b, func);
            time = sWatch.ElapsedTicks;
            return a;
        }
        /// <summary>
        /// Method finding gcd of three numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <param name="func">Gcd delegate</param>
        /// <returns></returns>
        public static int Gcd(int a, int b, int c, GcdDelegate func)
        {
            return func(Gcd(a, b, func), c);
        }
        /// <summary>
        /// Overriding Gcd method of three numbers with execution time of the algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <param name="time">Execution time of the algorithm</param>
        /// <param name="func">Gcd delegate</param>
        /// <returns></returns>
        public static int Gcd(int a, int b, int c, out long time, GcdDelegate func)
        {
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();
            Gcd(a, b, c, func);
            time = sWatch.ElapsedTicks;
            return a;
        }
        /// <summary>
        /// Method finding Gcd with different input parameters
        /// </summary>
        /// <param name="func">Gcd delegate</param>
        /// <param name="list">Numbers</param>
        /// <returns></returns>
        public static int Gcd(GcdDelegate func, params int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                list[0] = func(list[0], list[i]);
            }

            return list[0];
        }
        /// <summary>
        /// Overriding Gcd method of different numbers with execution time of the algorithm
        /// </summary>
        /// <param name="time">Execution time of the algorithm</param>
        /// <param name="func">Gcd delegate</param>
        /// <param name="list">Numbers</param>
        /// <returns></returns>
        public static int Gcd(out long time, GcdDelegate func, params int[] list)
        {
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();
            Gcd(func, list);
            time = sWatch.ElapsedTicks;
            return list[0];
        }
        #endregion

        #region Method with Euclidian Algorithm
        /// <summary>
        /// Euclidian GCD Algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>GCD</returns>
        public static int GcdEuclidian(int a, int b)
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }
       
        #endregion

        #region Method with Steins Algorithm
        /// <summary>
        /// Stains GCD Algorithm
        /// </summary>
        /// <param name="a">Firs number</param>
        /// <param name="b">Second number</param>
        /// <returns>GCD</returns>
        public static int GcdSteins(int a, int b)
        {
            int i;
            if (a == 0) return b;
            if (b == 0) return a;
            for (i = 0; ((a | b) & 1) == 0; ++i)
            {
                a >>= 1;
                b >>= 1;
            }
            while ((a & 1) == 0) a >>= 1;
            do
            {
                while ((b & 1) == 0) b >>= 1;
                if (a > b)
                {
                    int t = a;
                    a = b;
                    b = t;
                }
                b -= a;
            } while (b != 0);
            return a << i;
        }
        #endregion
    }
}


