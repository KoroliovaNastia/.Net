using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace Sorting.NUnitTests
{
    [TestFixture]
    public class AllSortingFunctionsTest
    {
        [Test, TestCaseSource(typeof(SortingJaggetArrayClass), "MaxSortTestCases")]
        public bool JaggetArraySortMaxElemTest(int[][] arr, int[][] expected)
        {
            SortJagArray.Sort(arr, SortJagArray.SortMaxElem);
            return IsEquals(arr, expected);
        }

        [Test, TestCaseSource(typeof(SortingJaggetArrayClass), "MinSortTestCases")]
        public bool JaggetArraySortMinElemTest(int[][] arr, int[][] expected)
        {
            SortJagArray.Sort(arr, SortJagArray.SortMinElem);
            return IsEquals(arr, expected);
        }

        [Test, TestCaseSource(typeof(SortingJaggetArrayClass), "MaxSummSortTestCases")]
        public bool JaggetArraySortSummElemTest(int[][] arr, int[][] expected)
        {
            SortJagArray.Sort(arr, SortJagArray.SortMaxSumm);
            return IsEquals(arr, expected);
        }

        private bool IsEquals(int[][] lhs, int[][] rhs)
        {
            if (lhs.GetLength(0) != rhs.GetLength(0)) return false;

            for (int i = 0; i < lhs.GetLength(0); i++)
            {
                if ((lhs[i] == null || rhs[i] == null) && !(lhs[i] == null && rhs[i] == null))
                {
                        return false;
                }

                if (lhs[i].Length != rhs[i].Length)
                {
                    return false;
                }
                for (int j = 0; j < lhs[i].Length; j++)
                {
                    if (lhs[i][j] != rhs[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    public class SortingJaggetArrayClass
    {
        public static IEnumerable<TestCaseData> MaxSortTestCases
        {
            get
            {
                yield return new TestCaseData(null, null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new[] { null, new[] { 1, 6, 3, 9 }, new[] { 10, 5, -3, 7, 4 } }, new[] { new[] { 10, 5, -3, 7, 4 }, new[] { 1, 6, 3, 9 }, null }).Returns(true);
                yield return new TestCaseData(new[] { new[] { 0, 9, -4, 7, 2, 4 }, new[] { 11, -3, 6, -7, 12 }, new[] { 4, 5, 3 }, new[] { 2, 2, -5, -6, 10 } }, new[] { new[] { 11, -3, 6, -7, 12 }, new[] { 2, 2, -5, -6, 10 }, new[] { 0, 9, -4, 7, 2, 4 }, new[] { 4, 5, 3 } }).Returns(true);
            }
        }
        public static IEnumerable<TestCaseData> MinSortTestCases
        {
            get
            {
                yield return new TestCaseData(null, null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new[] { null, new[] { 1, 6, 3, 9 }, new[] { 10, 5, -3, 7, 4 } }, new[] { new[] { 10, 5, -3, 7, 4 }, new[] { 1, 6, 3, 9 }, null }).Returns(true);
                yield return new TestCaseData(new[] { new[] { 0, 9, -4, 7, 2, 4 }, new[] { 11, -3, 6, -7, 12 }, new[] { 4, 5, 3 }, new[] { 2, 2, -5, -6, 10 } }, new[] { new[] { 11, -3, 6, -7, 12 }, new[] { 2, 2, -5, -6, 10 }, new[] { 0, 9, -4, 7, 2, 4 }, new[] { 4, 5, 3 } }).Returns(true);
            }
        }
        public static IEnumerable<TestCaseData> MaxSummSortTestCases
        {
            get
            {
                yield return new TestCaseData(null, null).Throws(typeof(ArgumentNullException));
                yield return new TestCaseData(new[] { null, new[] { 1, 6, 3, 9 }, new[] { 10, 5, -3, 7, 4 } }, new[] { new[] { 10, 5, -3, 7, 4 }, new[] { 1, 6, 3, 9 }, null }).Returns(true);
                yield return new TestCaseData(new[] { new[] { 0, 9, -4, 7, 2, 4 }, new[] { 11, -3, 6, -7, 12 }, new[] { 4, 5, 3 }, new[] { 2, 2, -5, -6, 10 } }, new[] { new[] { 11, -3, 6, -7, 12 }, new[] { 0, 9, -4, 7, 2, 4 }, new[] { 4, 5, 3 }, new[] { 2, 2, -5, -6, 10 } }).Returns(true);
            }
        }
    }
}
