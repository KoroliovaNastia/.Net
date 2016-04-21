using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NewtonMethod;
using System.Diagnostics;

namespace TestNewtonMethod
{
    [TestFixture]
    public class UnitTestRootOfNumber
    {
     
        
        [TestCase(3, 2, 0.001)]
        [TestCase(3, 2, -0.1, ExpectedException = typeof (ArgumentOutOfRangeException))]
        [TestCase(3, -2, 0.001)]
        [TestCase(2, -2, 0.001, ExpectedException = typeof(ArgumentException))]
        [TestCase(5, -2, 0.001)]

        [TestMethod]
        public void Newton_Method(int n, double x, double eps)
        {

            double result = RootOfNumber.FindRoot(n, x, eps);
            double result1 = Math.Pow(x, 1.0 / n);
            NUnit.Framework.Assert.AreEqual(result, result1, eps);

        
        }
    }
}
