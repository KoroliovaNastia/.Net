using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Matrix
{
    public class SymmetricMatrix<T>:SquareMatrix<T>
    {
        /// <summary>
        /// Empty initialisation.
        /// </summary>
        public SymmetricMatrix()
        {
        }
        /// <summary>
        /// Ctor initialise matrix using a two-dimensional array.
        /// </summary>
        /// <param name="coeff"></param>
        public SymmetricMatrix(T[,] coeff):base(coeff)
        {
            if(!IsSymmetric(coeff))
                throw new ArithmeticException();
        }
        /// <summary>
        /// Method checks whether it is possible to use an array to build a symmetric matrix
        /// </summary>
        /// <param name="matrix">Array</param>
        /// <returns>True or false</returns>
        private bool IsSymmetric(T[,] matrix)
        {
            bool statement = true;
            for(int i=0;i<matrix.GetLength(0);i++)
                for(int j=0;j<matrix.GetLength(1);j++)
                    if (!Equals(matrix[i, j], matrix[j, i]))
                        statement = false;
            return statement;
        }
    }
}
