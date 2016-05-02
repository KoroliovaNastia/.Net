using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLibrary.Matrix;

namespace MatrixLibrary
{
    public static class Extension
    {
        /// <summary>
        /// Extention method of adding matrix.
        /// </summary>
        /// <typeparam name="T">Type which this method extends</typeparam>
        /// <param name="lhsMatrix">Added matrix</param>
        /// <param name="rhsMatrix">Added matrix</param>
        /// <returns>Result of edding</returns>
        public static IMatrix<T> AddMatrix<T>(this IMatrix<T> lhsMatrix, IMatrix<T>rhsMatrix)
        {
            if(lhsMatrix==null ||  rhsMatrix==null)
                throw new ArgumentNullException();
            if(lhsMatrix.Dimention!=rhsMatrix.Dimention)
                throw new ArithmeticException();
            IMatrix<T> tempMatrix=new SquareMatrix<T>(new T[lhsMatrix.Dimention,lhsMatrix.Dimention]);
            for(int i=0; i<lhsMatrix.Dimention;i++)
                for (int j = 0; j < lhsMatrix.Dimention; j++)
                   tempMatrix[i, j] = (dynamic)lhsMatrix[i, j] + (dynamic)rhsMatrix[i, j];
            return tempMatrix;
        }
    }
}
