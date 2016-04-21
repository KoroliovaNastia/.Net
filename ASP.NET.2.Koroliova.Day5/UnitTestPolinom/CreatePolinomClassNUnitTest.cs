using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Polinom;

namespace UnitTestPolinom
{
    [TestFixture]
    public class CreatePolinomClassNUnitTest
    {
        [Test, TestCaseSource(typeof (PolinomFactoryClass), "CreateTestCases")]
        public CreatePolinom PolinomCreateTest(double[] coef)
        {
            CreatePolinom obj = new CreatePolinom(coef);
            
            return obj;
        }

        [Test, TestCaseSource(typeof (PolinomFactoryClass), "SumTestCases")]
        public CreatePolinom PolinomSumTest(double[] coef1, double[] coef2)
        {
            CreatePolinom p1 = new CreatePolinom(coef1);
            CreatePolinom p2 = new CreatePolinom(coef2);
            return CreatePolinom.Add(p1, p2);
        }

        [Test, TestCaseSource(typeof (PolinomFactoryClass), "DiffTestCases")]
        public CreatePolinom PolinomDiffTest(double[] coef1, double[] coef2)
        {
            CreatePolinom p1 = new CreatePolinom(coef1);
            CreatePolinom p2 = new CreatePolinom(coef2);
            return CreatePolinom.Subtract(p1, p2);
        }

        [Test, TestCaseSource(typeof (PolinomFactoryClass), "MultTestCases")]
        public CreatePolinom PolinomMultTest(double[] coef1, double[] coef2)
        {
            CreatePolinom p1 = new CreatePolinom(coef1);
            CreatePolinom p2 = new CreatePolinom(coef2);
            return CreatePolinom.Multiply(p1, p2);
        }

        [Test, TestCaseSource(typeof(PolinomFactoryClass), "DivQTestCases")]
        public CreatePolinom PolinomDivQTest(double[] coef1, double[] coef2)
        {
            CreatePolinom p1 = new CreatePolinom(coef1);
            CreatePolinom p2 = new CreatePolinom(coef2);
            
            return p1/p2;
        }
        [Test, TestCaseSource(typeof(PolinomFactoryClass), "DivRTestCases")]
        public CreatePolinom PolinomDivRTest(double[] coef1, double[] coef2)
        {
            CreatePolinom p1 = new CreatePolinom(coef1);
            CreatePolinom p2 = new CreatePolinom(coef2);

            return p1% p2;
        }
    }

    public class PolinomFactoryClass
        {

            public static IEnumerable<TestCaseData> CreateTestCases
            {
                get
                {
                    yield return new TestCaseData(new[] { 1, 0, 3, 0.5 }).Returns(new CreatePolinom(1, 0, 3, 0.5));
                    yield return new TestCaseData(null).Throws(typeof(ArgumentNullException));
                }
            }
    
            public static IEnumerable<TestCaseData> SumTestCases
            {
                get
                {
                    yield return
                        new TestCaseData(new[] { 1, 0, 3, 0.5 }, new[] { 0, 2.5, 1, 2 }).Returns(new CreatePolinom(1, 2.5, 4, 2.5))
                        ;
                    yield return
                        new TestCaseData(new[] { 1.0, 0 }, new[] { 0, 2.5, 1, 2 }).Returns(new CreatePolinom(1, 2.5, 1, 2));
                    yield return new TestCaseData(new[] { 1.0, 2 }, new[] { 5, 6555.8 }).Returns(new CreatePolinom(6, 6557.8));
                    yield return new TestCaseData(null, new[] {0, 1.0}).Throws(typeof (ArgumentNullException));
                }
            }

            public static IEnumerable<TestCaseData> DiffTestCases
            {
                get
                {
                    yield return
                        new TestCaseData(new[] { 1, 0, 3, 0.5 }, new[] { 0, 2.5, 1, 2 }).Returns(new CreatePolinom(1, -2.5, 2,
                            -1.5));
                    yield return
                        new TestCaseData(new[] { 1.0, 0 }, new[] { 0, 2.5, 1, 2 }).Returns(new CreatePolinom(1, -2.5, -1, -2));
                    yield return new TestCaseData(new[] { 1.0, 2 }, new[] { 5, 6555.8 }).Returns(new CreatePolinom(-4, -6553.8));
                    yield return new TestCaseData(null, new[] {0, 1.0}).Throws(typeof (ArgumentNullException));
                }
            }

            public static IEnumerable<TestCaseData> MultTestCases
            {
                get
                {
                    yield return
                        new TestCaseData(new[] { 1, 0, 3, 0.5 }, new[] { 0, 2.5, 1, 2 }).Returns(new CreatePolinom(0, 2.5, 1, 9.5,
                            4.25, 6.5, 1));
                    yield return new TestCaseData(new[] { 1.0, 2 }, new[] { 0, 2.5, 1, 2 }).Returns(new CreatePolinom(0, 2.5, 6, 4, 4));
                    yield return new TestCaseData(null, new[] {0, 1.0}).Throws(typeof (ArgumentNullException));
                }
            }

        public static IEnumerable<TestCaseData> DivQTestCases
        {
            get
            {
                yield return new TestCaseData(new[] { 3.0, 4.0, 2.0 }, new[] { 1.0, 2.0 }).Returns(new CreatePolinom(1.5, 1.0));
                yield return new TestCaseData(null, new[] { 0, 1.0 }).Throws(typeof(ArgumentNullException));
            }
        }
                public static IEnumerable<TestCaseData> DivRTestCases
        {
            get
            {
                yield return new TestCaseData(new[] { 3.0, 4.0, 2.0 }, new[] { 1.0, 2.0 }).Returns(new CreatePolinom(1.5));
                yield return new TestCaseData(null, new[] { 0, 1.0 }).Throws(typeof(ArgumentNullException));
            }
        }
    }
    
}
