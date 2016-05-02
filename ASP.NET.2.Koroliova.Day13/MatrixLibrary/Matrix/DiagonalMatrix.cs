using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Matrix
{
    public class DiagonalMatrix<T>:SymmetricMatrix<T>
    {
        /// <summary>
        /// Ctor initialise matrix using a two-dimensional array.
        /// </summary>
        /// <param name="coeff"></param>
        public DiagonalMatrix(T[,] coeff) : base(coeff)
        {
            if(!IsDioganal(coeff))
                throw new ArgumentNullException();
        }
        /// <summary>
        /// Ctor initialise matrix using the array of diagonal elements.
        /// </summary>
        /// <param name="diagonalcoeff"></param>
        public DiagonalMatrix(T[] diagonalcoeff):this(new T[diagonalcoeff.Length,diagonalcoeff.Length])
        {
            if(diagonalcoeff==null)
                throw new ArgumentNullException();
            for (int i=0; i < Dimention; i++)
                this[i, i] = diagonalcoeff[i];
        }
        /// <summary>
        /// Method checks whether it is possible to use an array to build a diagonal matrix
        /// </summary>
        /// <param name="coeff">Array</param>
        /// <returns>True or false</returns>
        private bool IsDioganal(T[,] coeff)
        {
            bool statement = true;
            for(int i=0;i<coeff.GetLength(0);i++)
                for(int j=i+1;j<coeff.GetLength(1);j++)
                    if (!Equals(coeff[i, j], default(T)))
                        statement = false;
            return statement;
        }
    }
}
