using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// Sorting class of jagget array with using interface
    /// </summary>
    public class SortJagArray
    {
        /// <summary>
        /// Simple sorting class with standart compare
        /// </summary>
        /// <param name="mass">Merge sorting mass.</param>

        #region Public Methods
        public static void Sort(int[][] mass)
        {
            if (mass == null)
                throw new ArgumentNullException();
            Comparison<int[]> comparison = StandartCompare;
            Sort(mass, comparison);
        }

        /// <param name="m">jagget array</param>
        /// <param name="comparison">delegate</param>
        public static void Sort(int[][] m, Comparison<int[]> comparison)
        {
            if (m == null || comparison == null)
            {
                throw new ArgumentNullException();
            }
            for (int i = 0; i < m.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < m.GetLength(0); j++)
                {
                    if (comparison(m[i], m[j]) > 0)
                        Swap(ref m[i], ref m[j]);
                }
            }
        }
        #endregion

        #region SortMethods
        /// <summary>
        /// Sorting method by max element
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int SortMaxElem(int[] a, int[] b)
        {

            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return 0;
            if (ReferenceEquals(a, null))
                return 1;
            if (ReferenceEquals(b, null))
                return -1;
            if (a.Max() < b.Max())
                return 1;
            if (a.Max() > b.Max())
                return -1;
            return 0;
        }
        /// <summary>
        /// Sorting method by min element
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int SortMinElem(int[] a, int[] b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return 0;
            if (ReferenceEquals(a, null))
                return 1;
            if (ReferenceEquals(b, null))
                return -1;
            if (a.Min() > b.Min())
                return 1;
            if (a.Min() < b.Min())
                return -1;
            return 0;
        }
        /// <summary>
        /// Sorting method by max summ of elements
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int SortMaxSumm(int[] a, int[] b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return 0;
            if (ReferenceEquals(a, null))
                return 1;
            if (ReferenceEquals(b, null))
                return -1;
            if (a.Sum() < b.Sum())
                return 1;
            if (a.Sum() > b.Sum())
                return -1;
            return 0;
        }

        #endregion

        #region PrivateMethods
        /// <summary>
        /// Method with simple comparison
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>Result of comparison</returns>
        private static int StandartCompare(int[] lhs, int[] rhs)
        {
            return SortMaxElem(lhs, rhs);
        }
        /// <summary>
        /// Swap method
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;

        }
        #endregion
    }
}
