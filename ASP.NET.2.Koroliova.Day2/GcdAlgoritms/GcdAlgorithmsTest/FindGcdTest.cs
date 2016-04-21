using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GcdAlgorithms;

namespace GcdAlgorithmsTest
{
    [TestClass]
    public class FindGcdTest
    {
        #region GcdEuclidianTests
        [TestMethod]
        
        public void GcdEuclidianWithTwoNumbersZeroFirstTest()
        {
            //Arrange
            int a = 0, b = 256;
            //Act
            int result = FindGcd.Gcd(a, b, FindGcd.GcdEuclidian);
            //Assert
            Assert.AreEqual(256, result);
        }
         [TestMethod]
        public void GcdEuclidianWithTwoNumbersZeroSecondTest()
        {
            //Arrange
            int a = 122, b = 0;
            //Act
            int result = FindGcd.Gcd(a, b, FindGcd.GcdEuclidian);
            //Assert
            Assert.AreEqual(122, result);
        }
        [TestMethod]
        public void GcdEuclidianWithTwoNumbersTest()
        {
            //Arrange
            int a = 134, b = 256;
            //Act
            int result = FindGcd.Gcd(a, b, FindGcd.GcdEuclidian);
            //Assert
            Assert.AreEqual(2,result);
        }
        [TestMethod]
        public void GcdEuclidianWithTwoNumbersOneTest()
        {
            //Arrange
            int a = 1, b = 256;
            //Act
            int result = FindGcd.Gcd(a, b, FindGcd.GcdEuclidian);
            //Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void GcdEuclidianWithThreeNumbersTest()
        {
            //Arrange
            int a = 504, b = 313, c = 732;
            //Act
            int result = FindGcd.Gcd(a, b, c, FindGcd.GcdEuclidian);
            //Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void GcdEuclidianWithParamsNumbersTest()
        {
            //Arrange
            int[] param={212,68,44,200};
            //Act
            int result = FindGcd.Gcd( FindGcd.GcdEuclidian, param);
            //Assert
            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void GcdEuclidianWithParamsNumbersWithTimeTest()
        {
            //Arrange
            int[] param = { 212, 68, 44, 200 };
            long time;
            //Act
            int result = FindGcd.Gcd(out time, FindGcd.GcdEuclidian, param);
            //Assert
            Assert.AreEqual(4, result);
            Assert.IsNotNull(time);
        }
        #endregion

        
        #region GcdSteinsTests

        [TestMethod]
        public void GcdSteinsWithTwoNumbersFirsZeroTest()
        {
            //Arrange
            int a = 0, b = 256;
            //Act
            int result = FindGcd.Gcd(a, b, FindGcd.GcdSteins);
            //Assert
            Assert.AreEqual(256, result);
        }
        [TestMethod]
        public void GcdSteinsWithTwoNumbersSecondZeroTest()
        {
            //Arrange
            int a = 134, b = 0;
            //Act
            int result = FindGcd.Gcd(a, b, FindGcd.GcdSteins);
            //Assert
            Assert.AreEqual(134, result);
        }
        [TestMethod]
        public void GcdSteinsWithTwoNumbersTest()
        {
            //Arrange
            int a = 134, b = 256;
            //Act
            int result = FindGcd.Gcd(a, b, FindGcd.GcdSteins);
            //Assert
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void GcdSteinsWithTwoNumbersOneTest()
        {
            //Arrange
            int a = 134, b = 1;
            //Act
            int result = FindGcd.Gcd(a, b, FindGcd.GcdSteins);
            //Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void GcdSteinsWithThreeNumbersTest()
        {
            //Arrange
            int a = 504, b = 313, c = 732;
            //Act
            int result = FindGcd.Gcd(a, b, c, FindGcd.GcdSteins);
            //Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void GcdSteinsWithParamsNumbersTest()
        {
            //Arrange
            int[] param = { 212, 68, 44, 200 };
            //Act
            int result = FindGcd.Gcd(FindGcd.GcdSteins, param);
            //Assert
            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void GcdSteinsWithParamsNumbersWithTimeTest()
        {
            //Arrange
            int[] param = { 212, 68, 44, 200 };
            long time;
            //Act
            int result = FindGcd.Gcd(out time, FindGcd.GcdSteins, param);
            //Assert
            Assert.AreEqual(4, result);
            Assert.IsNotNull(time);
        }
        #endregion
    }
}
