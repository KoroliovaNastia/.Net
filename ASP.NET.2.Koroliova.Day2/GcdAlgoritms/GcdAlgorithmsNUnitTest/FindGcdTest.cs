using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GcdAlgorithms;

namespace GcdAlgorithmsNUnitTest
{
    public class FindGcdTest
    {
        #region EuclidianTests

        [TestCase(212,44, Result = 4)]
        [TestCase(96,444, Result = 12)]
        [TestCase(0, 555, Result = 555)]
        [TestCase(43, 1, Result = 1)]
        [TestCase(3333, 0, Result = 3333)]

        public int FindGcdEuclAlg(int a, int b)
        {
            return FindGcd.Gcd(a, b, FindGcd.GcdEuclidian);;
        }



        #endregion

        #region EuclidianTests
        [TestCase(212,44, Result = 4)]
        [TestCase(96,444, Result = 12)]
        [TestCase(0, 555, Result = 555)]
        [TestCase(43, 1, Result = 1)]
        [TestCase(3333, 0, Result = 3333)]

        public int FindGcdSteinAlg(int a, int b)
        {
            return FindGcd.Gcd(a, b, FindGcd.GcdSteins); ;
        }
        #endregion
    }
}
