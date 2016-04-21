using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;

namespace Task1NUnitTest
{

    [TestFixture]
    public class SortingClassTest
    {
#region DelegateMethods
        public int SortMaxAbs(long lhs, long rhs)
        {
            if (Math.Abs(lhs) < Math.Abs(rhs)) return -1;
            if (Math.Abs(lhs) == Math.Abs(rhs)) return 0;
            if (Math.Abs(lhs) > Math.Abs(rhs)) return 1;
            return 0;
        }

        public int SortMin(long lhs, long rhs)
        {
            if (lhs > rhs) return -1;
            if (lhs == rhs) return 0;
            if (lhs < rhs) return 1;
            return 0;
        }
#endregion
        [Test, TestCaseSource(typeof(SortingFactoryClass), "SortingSimpleTestCases")]
        public long[] SortingSimpleTest(long[] arr)
        {
            Sorting.SortMerge(arr);
            return arr; 
        }

        [Test, TestCaseSource(typeof(SortingFactoryClass), "SortingSortMaxAbsTestCases")]
        public long[] SortingSortMaxAbsTest(long[] arr)
        {
            Sorting.SortMerge(arr, SortMaxAbs);
            return arr;
        }
        [Test, TestCaseSource(typeof(SortingFactoryClass), "SortingSortMinTestCases")]
        public long[] SortingSortMinTest(long[] arr)
        {
            Sorting.SortMerge(arr, SortMin);
            return arr;
        }
        [TestCase(new long[] { 1, 2, 5, 8, 11, 9 }, ExpectedException = typeof(ArgumentNullException))]
        public void SortingNullTest(long[] arr)
        {

            Sorting.SortMerge(arr, null);
            CollectionAssert.AreEqual(new long[] { 1, 2, 5, 8, 9, 11 }, arr);
           
        }
    }

    public class SortingFactoryClass
    {

        public static IEnumerable<TestCaseData> SortingSimpleTestCases
        {
            get
            {
                yield return new TestCaseData(new long[] {1, 0, 3, 5}).Returns(new long[]{0, 1, 3, 5});
                yield return new TestCaseData(null).Throws(typeof (ArgumentNullException));
            }
        }

        public static IEnumerable<TestCaseData> SortingSortMaxAbsTestCases
        {
            get
            {
                yield return new TestCaseData(new long[] { -1, 0, 3, -7,-9, 2 }).Returns(new long[] { 0, -1, 2, 3, -7, -9 });
                yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            }
        }
        public static IEnumerable<TestCaseData> SortingSortMinTestCases
        {
            get
            {
                yield return new TestCaseData(new long[] { -1, 0, 3, -7, -9, 2 }).Returns(new long[] {3, 2, 0, -1, -7, -9 });
                yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
            }
        }

    }
}
