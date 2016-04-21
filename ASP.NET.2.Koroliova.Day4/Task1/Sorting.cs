using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Sorting class
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Simple sorting class with standart compare
        /// </summary>
        /// <param name="mass">Merge sorting mass.</param>
        #region Public Methods
        public static void SortMerge(long[] mass)
        {
            if (mass == null)
                throw new ArgumentNullException();
          // Comparison<long> comparison = StandartCompare;
           SortMerge(mass, 0, mass.Length - 1, StandartCompare);
        }
        /// <summary>
        /// Sorting with any comparision delegate
        /// </summary>
        /// <param name="mass">Merge sorting mass.</param>
        /// <param name="comparison">Delegate which encapsulate some compare method</param>
        public static void SortMerge(long[] mass, Comparison<long> comparison)
        {
            if (mass == null || comparison==null)
                throw new ArgumentNullException();
            SortMerge(mass, 0, mass.Length-1, comparison);
        }
        /// <summary>
        /// Method with simple comparison
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>Result of comparison</returns>
        public static int StandartCompare(long lhs, long rhs)
        {
            return lhs.CompareTo(rhs);
        }
#endregion
        /// <summary>
        /// Merge sort with delegate
        /// </summary>
        /// <param name="mass">The accepted array</param>
        /// <param name="lhs">Left border of array</param>
        /// <param name="rhs">Right border of array</param>
        /// <param name="comparison">Delegate</param>
        #region Private Methods
        private static void SortMerge(long[] mass, long lhs, long rhs, Comparison<long> comparison)
        {
            if (mass == null)
                throw new NullReferenceException();
            if (lhs < rhs)
            {
                long middle = (lhs + rhs) / 2;
                SortMerge(mass, lhs, middle, comparison);
                SortMerge(mass, middle + 1, rhs, comparison);
                Merge(mass, lhs, middle, rhs, comparison);
            }
        }
        /// <summary>
        /// Merge sort with delegate
        /// </summary>
        /// <param name="mass">The accepted array</param>
        /// <param name="lhs">Left border of array</param>
        /// <param name="middle">Array middle</param>
        /// <param name="rhs">Right border of array</param>
        /// <param name="comparison">Delegate</param>
        private static void Merge(long[] mass, long lhs, long middle, long rhs, Comparison<long> comparison)
        {
            long firstPos = lhs;
            long secondPos = middle + 1;
            long tempPos = 0;
            long[] temp = new long[rhs - lhs + 1];
            while (firstPos <= middle && secondPos <= rhs)
            {
                if (comparison(mass[firstPos], mass[secondPos]) < 0)

                    temp[tempPos++] = mass[firstPos++];

                else
                    temp[tempPos++] = mass[secondPos++];

            }
            while (secondPos <= rhs)
            {
                temp[tempPos++] = mass[secondPos++];

            }
            while (firstPos <= middle)
            {
                temp[tempPos++] = mass[firstPos++];

            }

            temp.CopyTo(mass, lhs);
        }
#endregion
    }
}
