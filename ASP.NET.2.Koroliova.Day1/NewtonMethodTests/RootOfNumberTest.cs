using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewtonMethod;

namespace NewtonMethodTests
{
    [TestClass]
    public class RootOfNumberTest
    {
        [TestMethod]
        public void FindEvenPosisiveRootEvenPositiveNumberTest()
        {
            //Arrange
            double number = 34;
            int root = 6;
            double eps = 0.000000001;
            //Act
            double result = RootOfNumber.FindRoot(root, number, eps);
            //Assert
            Assert.AreEqual(Math.Pow(number,1.0/root),result);
        }
        [TestMethod]
        public void FindEvenNegativRootEvenPositiveNumberTest()
        {
            //Arrange
            double number = 54;
            int root = -12;
            double eps = 0.000000001;
            //Act
            double result = RootOfNumber.FindRoot(root, number, eps);
            //Assert
            Assert.AreEqual(1.0/Math.Pow(number, 1.0 / Math.Abs(root)), result);
        }
        [TestMethod]
        public void FindEvenPositiveRootEvenNegativeNumberTest()
        {
            //Arrange
            double number = -16;
            int root = 4;
            double eps = 0.000000001;
            //Act
            double result = RootOfNumber.FindRoot(root, number, eps);
            //Assert
            Assert.AreEqual(Math.Pow(number, 1.0 / root), result);
        }
        [TestMethod]
        public void FindEvenPositiveRootOddNegativeNumberTest()
        {
            //Arrange
            double number = -17;
            int root = 4;
            double eps = 0.000000001;
            //Act
            double result = RootOfNumber.FindRoot(root, number, eps);
            //Assert
            Assert.AreEqual(Math.Pow(number, 1.0 / root), result);
        }
        [TestMethod]
        public void FindOddPositiveRootOddNegativeNumberTest()
        {
            //Arrange
            double number = -17;
            int root = 5;
            double eps = 0.000000001;
            //Act
            double result = RootOfNumber.FindRoot(root, number, eps);
            //Assert
            Assert.AreEqual(-Math.Pow(Math.Abs(number), 1.0 / root), result);
        }
        [TestMethod]
        public void FindOddNagativeRootOddNegativeNumberTest()
        {
            //Arrange
            double number = -21;
            int root = -3;
            double eps = 0.000000001;
            //Act
            double result = RootOfNumber.FindRoot(root, number, eps);
            //Assert
            Assert.AreEqual(-Math.Pow(Math.Abs(number), 1.0 / root), result);
        }
        [TestMethod]
        public void FindOddPositiveRootOddPositiveNumberTest()
        {
            //Arrange
            double number = 91;
            int root = 7;
            double eps = 0.000000001;
            //Act
            double result = RootOfNumber.FindRoot(root, number, eps);
            //Assert
            Assert.AreEqual(Math.Pow(number, 1.0 / root), result);
        }
        [TestMethod]
        public void FindOddNegativeRootOddPositiveNumberTest()
        {
            //Arrange
            double number = 111;
            int root = -13;
            double eps = 0.000000001;
            //Act
            double result = RootOfNumber.FindRoot(root, number, eps);
            //Assert
            Assert.AreEqual(Math.Pow(number, 1.0 / root), result);
        }
    }
}
