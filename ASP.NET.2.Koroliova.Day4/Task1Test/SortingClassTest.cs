using System;
using System.Runtime.Remoting.Lifetime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1Test
{
    [TestClass]
    public class SortingClassTest
    {
        public int SortMaxAbs(long lhs, long rhs)
        {
            if (Math.Abs(lhs) < Math.Abs(rhs)) return -1;
            if (Math.Abs(lhs) == Math.Abs(rhs)) return 0;
            if (Math.Abs(lhs) > Math.Abs(rhs)) return 1;
            return 0;
        }

        [TestMethod]
        public void MergeSortingStandartCompare()
        {
            //Arange
            long[] arr = {12, 45, 24, 7, 9, -3, 4, -2};
            //Act
            Sorting.SortMerge(arr);
            //Assert
            CollectionAssert.AreEqual(new long[]{-3, -2, 4, 7, 9, 12, 24, 45},arr);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSortingNullCompare()
        {
            //Arange
            long[] arr = { 12, 45, 24, 7, 9, -3, 4, -2 };
            //Act
            Sorting.SortMerge(arr,null);
            //Assert
            CollectionAssert.AreEqual(new long[] { -3, -2, 4, 7, 9, 12, 24, 45 }, arr);
        }
        [TestMethod]
        public void MergeSortingCompareTo()
        {
            //Arange
            long[] arr = { 12, -45, -24, 7, 9, -3, 2 };
            //Act
            Sorting.SortMerge(arr,SortMaxAbs);
            //Assert
            CollectionAssert.AreEqual(new long[] { 2, -3, 7, 9, 12, -24, -45 }, arr);
        }
    }
}
