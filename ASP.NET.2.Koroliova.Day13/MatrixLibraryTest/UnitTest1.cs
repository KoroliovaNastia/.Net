using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using MatrixLibrary;
using MatrixLibrary.Matrix;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace MatrixLibraryTest
{
    [TestFixture]
    public class MatrixNUnitTest
    {
        [TestCase(new[] { 1, 2, 3, 4, 5 }, Result = 5)]
        [TestCase(null, ExpectedException = typeof(NullReferenceException))]
        public int DiagonalMatrixCreateTest(int[] data)
        {
            var diagonalMatrix = new DiagonalMatrix<int>(data);
            return diagonalMatrix.Dimention;
        }
       
        [Test, TestCaseSource(typeof(MatrixFactoryClass), "CreateSquareMatrixTestCases")]
        public string SquareMatrixCreateTest(int[,] coeff)
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(coeff);

            return matrix.GetStringMatrix();
        }

        [Test, TestCaseSource(typeof(MatrixFactoryClass), "CreateSymmetricMatrixTestCases")]
        public string SymmetrycMatrixCreateTest(char[,] coeff)
        {
            SquareMatrix<char> matrix = new SquareMatrix<char>(coeff);

            return matrix.GetStringMatrix();
        }

        [Test, TestCaseSource(typeof(MatrixFactoryClass), "AddSquareMatrixTestCases")]
        public string MatrixSumTest(IMatrix<double> lhs, IMatrix<double> rhs)
        {
            return lhs.AddMatrix(rhs).GetStringMatrix();
        }

    }

    public class MatrixFactoryClass
    {
        public static IEnumerable<TestCaseData> CreateSquareMatrixTestCases
        {
            get
            {
                yield return new TestCaseData(new int[4, 4]).Returns(new SquareMatrix<int>(new int[4, 4]).GetStringMatrix());
                yield return new TestCaseData(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }).Returns(new SquareMatrix<int>(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }).GetStringMatrix());
                yield return new TestCaseData(new int[1, 2]).Throws(typeof(ArgumentOutOfRangeException));
            }
        }
        public static IEnumerable<TestCaseData> CreateSymmetricMatrixTestCases
        {
            get
            {
                yield return new TestCaseData(new char[4, 4]).Returns(new SymmetricMatrix<char>(new char[4, 4]).GetStringMatrix());
                yield return new TestCaseData(new[,] { { 'A', 'B', 'C' }, { 'B', 'D', 'I' }, { 'C', 'I', 'F' } }).Returns(new SymmetricMatrix<char>(new[,] { { 'A', 'B', 'C' }, { 'B', 'D', 'I' }, { 'C', 'I', 'F' } }).GetStringMatrix());
                yield return new TestCaseData(new char[1, 2]).Throws(typeof(ArgumentOutOfRangeException));
            }
        }
        
        public static IEnumerable<TestCaseData> AddSquareMatrixTestCases
        {
            get
            {
                yield return new TestCaseData(new SquareMatrix<double>(new[,] { { 1.2, 2.4, 3.6 }, { 4.1, 5.6, 6.0 }, { 7.3, 8.8, 9.0 } }), new DiagonalMatrix<double>(new[] { 1.0, 3.3, 4.0 })).Returns(new SquareMatrix<double>(new[,] { { 2.2, 2.4, 3.6 }, { 4.1, 8.9, 6.0 }, { 7.3, 8.8, 13.0 } }).GetStringMatrix());
                yield return new TestCaseData(new SymmetricMatrix<double>(new[,] { { 1.0, 2.0 }, { 2.0, 1.0 } }), new DiagonalMatrix<double>(new[] { 2.0, 3.0 })).Returns(new SquareMatrix<double>(new[,] { { 3.0, 2.0 }, { 2.0, 4.0 } }).GetStringMatrix());
                yield return new TestCaseData(null, new DiagonalMatrix<double>(new double[2, 2])).Throws(typeof(ArgumentNullException));
            }
        }
    }
}
