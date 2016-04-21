using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NewtonMethod;

namespace NewtonMethodNUnitTest
{
    [TestFixture]
    public class RootOfNumberClassTest
    {

        [TestCase(2, 4, 0.00001)]
        [TestCase(3, 3, 0.0000001)]
        [TestCase(-3, -3, 0.00001)]
        [TestCase(-3, 6, 0.0000001)]
        [TestCase(3, -9, 0.0000001)]

        public void FindRootOfNumber_Test(int pow, double number, double eps)
        {
            double result = RootOfNumber.FindRoot(pow, number, eps);
            double expected = Math.Sign(number) * Math.Pow(Math.Abs(number), 1.0 / pow);
            Assert.True(Math.Abs(expected - result) < eps);
        }

        [TestCase(2, -7, 0.00001)]
        [TestCase(2, Double.NaN, 0.00001)]

        public void FindRootOfNaN_Test(int pow, double number, double eps)
        {
            double result = RootOfNumber.FindRoot(pow, number, eps);
            Assert.AreEqual(Double.NaN, result);
        }
        [TestCase(2, -7, -0.007, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(2, 3, 6.0, ExpectedException = typeof(ArgumentOutOfRangeException))]

        public void FindRootOfException_Test(int pow, double number, double eps)
        {
            double result = RootOfNumber.FindRoot(pow, number, eps);
            Assert.AreEqual(Math.Pow(number, 1.0 / pow), result);
        }
    }
}
