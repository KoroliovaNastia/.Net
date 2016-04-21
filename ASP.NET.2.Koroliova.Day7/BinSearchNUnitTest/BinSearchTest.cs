using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinSearch;
using NUnit.Framework.Constraints;

namespace BinSearchNUnitTest
{

    [TestFixture]
    public class BinSearchTest
    {
        public int SortMin(int lhs, int rhs)
        {
            if (lhs > rhs) return -1;
            if (lhs == rhs) return 0;
            if (lhs < rhs) return 1;
            return 0;
        }
        [Test, TestCaseSource(typeof(BinSearchFactoryClass), "FindElementDoubleCase")]
        public int FindDefComparerTest(double[] mass, Comparer<double> comparer)
        {
            int a = SearchMass<double>.Search(mass, 13, comparer);
            return a;
        }
        [Test, TestCaseSource(typeof(BinSearchFactoryClass), "FindElementIntCase")]
        public int FindSotrMinComparerTest(int[] mass, int x)
        {
            Comparer<int> comparer = Comparer<int>.Create(SortMin);
            int a = SearchMass<int>.Search(mass, x, comparer);
            return a;
        }
        public class BinSearchFactoryClass
        {

            public static IEnumerable<TestCaseData> FindElementDoubleCase
            {
                get
                {
                    yield return new TestCaseData(new double[] { 1, 3, 5, 7, 9, 12, 23, 45 }, null).Returns(-1);
                    yield return new TestCaseData(new double[] { 2, 4, 5, 7, 13, 16, 20 }, null).Returns(4);
                    yield return new TestCaseData(new double[] { 13, 14, 15, 16, 17 }, null).Returns(0);
                    yield return new TestCaseData(new[] { 11, 12, 12.5, 13, 13, 13 }, null).Returns(3);
                    yield return new TestCaseData(new double[] { 0 }, null).Returns(-1);
                    yield return new TestCaseData(new double[] { 0, 1 }, null).Returns(-1);
                    yield return new TestCaseData(new double[] { }, null).Returns(-1);
                    yield return new TestCaseData(null, null).Throws(typeof(NullReferenceException));
                    yield return new TestCaseData(new double[] { 1, 3, 5, 7, 9, 12 }, null).Returns(-1);
                    yield return new TestCaseData(new double[] { 14, 15, 16, 17 }, null).Returns(-1);
                    yield return new TestCaseData(new double[] { 1, 8, 4, 2, 7, 5, 0 }, null).Throws(typeof(ArgumentException));
                }
            }

            public static IEnumerable<TestCaseData> FindElementIntCase
            {
                get
                {
                    yield return new TestCaseData(new[] { 9, 8, 7, 6, 5, 4, 3, 2 }, 6).Returns(3);
                    yield return new TestCaseData(new[] { 23, 14, 13, 10, 9, 7, 3 }, 10).Returns(3);
                    yield return new TestCaseData(new[] { 17, 17, 15, 14, 13, 12, }, 17).Returns(0);
                    yield return new TestCaseData(new[] { 12, 11, 10, 9, 8, 7, 4, 3 }, 5).Returns(-1);
                    yield return new TestCaseData(new[] { 0, 0, 0, 0, 0, 0 }, 7).Returns(-1);
                    yield return new TestCaseData(new int[] { }, 4).Returns(-1);
                    yield return new TestCaseData(null, 3).Throws(typeof(NullReferenceException));
                    yield return new TestCaseData(new[] { 12, 11, 10, 9, 8, 7 }, 13).Returns(-1);
                    yield return new TestCaseData(new[] { 17, 16, 15, 14, 13 }, 12).Returns(-1);
                    yield return new TestCaseData(new double[] { 1, 8, 4, 2, 7, 5, 0 }, null).Throws(typeof(ArgumentException));
                }
            }
        }
    }
}
