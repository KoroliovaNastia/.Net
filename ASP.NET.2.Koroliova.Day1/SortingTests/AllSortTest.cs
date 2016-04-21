using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using Sorting;

//using NUnit.Framework;

namespace SortingTests
{
    [TestClass]
    public class AllSortTest
    {
        [TestMethod]
        public void SortingMaxElementsMethod()
        {
            //Arrange
            int[][] jaggetArray ={ new[] {0, 9, -4, 7, 2, 4},  new[] {11, -3, 6, -7, 12}, new[] {4, 5, 3},  new[] {2, 2, -5, -6, 10}};
            int[][] temp = { new[] { 11, -3, 6, -7, 12 }, new[] { 2, 2, -5, -6, 10 } , new[] { 0, 9, -4, 7, 2, 4 },  new[] { 4, 5, 3 } };
            int[][] j = null;
            //Act
            SortJagArray.Sort(jaggetArray, SortJagArray.SortMaxElem);
            //Assert
            CollectionAssert.AreEquivalent(temp[0],jaggetArray[0]);
            CollectionAssert.AreEquivalent(temp[1], jaggetArray[1]);
            CollectionAssert.AreEquivalent(temp[2], jaggetArray[2]);
            CollectionAssert.AreEquivalent(temp[3], jaggetArray[3]);
        }
        [TestMethod]
        public void SortingMinElementsMethod()
        {
            //Arrange
            int[][] jaggetArray = { new[] { 0, 9, -4, 7, 2, 4 }, new[] { 11, -3, 6, -7, 12 }, new[] { 4, -5, 3 }, new[] { 2, 2, -5, -6, 10 } };
            int[][] temp = { new[] { 11, -3, 6, -7, 12 }, new[] { 2, 2, -5, -6, 10 }, new[] { 4, -5, 3 }, new[] { 0, 9, -4, 7, 2, 4 } };
            //Act
            SortJagArray.Sort(jaggetArray, SortJagArray.SortMinElem);
            //Assert
            CollectionAssert.AreEquivalent(temp[0], jaggetArray[0]);
            CollectionAssert.AreEquivalent(temp[1], jaggetArray[1]);
            CollectionAssert.AreEquivalent(temp[2], jaggetArray[2]);
            CollectionAssert.AreEquivalent(temp[3], jaggetArray[3]);
        }
        [TestMethod]
        public void SortingSummElementsMethod()
        {
            //Arrange
            int[][] jaggetArray = { new[] { 0, 9, -4, 7, 2, 4 }, new[] { 11, -3, 6, -7, 12 }, new[] { 4, 5, 3 }, new[] { 2, 2, -5, -6, 10 } };
            int[][] temp = { new[] { 11, -3, 6, -7, 12 }, new[] { 0, 9, -4, 7, 2, 4 }, new[] { 4, 5, 3 } , new[] { 2, 2, -5, -6, 10 }};
            //Act
            SortJagArray.Sort(jaggetArray, SortJagArray.SortMaxSumm);
            //Assert
            CollectionAssert.AreEquivalent(temp[0], jaggetArray[0]);
            CollectionAssert.AreEquivalent(temp[1], jaggetArray[1]);
            CollectionAssert.AreEquivalent(temp[2], jaggetArray[2]);
            CollectionAssert.AreEquivalent(temp[3], jaggetArray[3]);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        
        public  void SortingNullArray()
        {
            //Arrange
            int[][] j = {new[]{1,2},new []{5,8,0}};
            //Act
            SortJagArray.Sort(null, SortJagArray.SortMinElem);
            SortJagArray.Sort(j, null);
            //SortJagArray.Sort(j, SortJagArray.SortMaxSumm);
            SortJagArray.Sort(null);
        }
    }
}
